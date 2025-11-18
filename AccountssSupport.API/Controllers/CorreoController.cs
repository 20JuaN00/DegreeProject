using AccountsSupport.Core.Mail.Interfaz;
using AccountsSupport.Core.Mail.Model;
using AccountsssSupport.API.Models;
using Microsoft.AspNetCore.Mvc;
using AccountssSupport.API.Models.AccountsssSupport.API.Models;
using MimeKit;
namespace AccountsssSupport.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CorreoController : ControllerBase
    {
        private readonly Interface_SMTP _smtpService;
        private readonly Interface_IMAP _imapService;
        private readonly ILogger<CorreoController> _logger;
        public CorreoController(
            Interface_SMTP smtpService,
            Interface_IMAP imapService,
            ILogger<CorreoController> logger)
        {
            _smtpService = smtpService;
            _imapService = imapService;
            _logger = logger;
        }

        /// <summary>
        /// Envía un correo electrónico
        /// </summary>
        /// <param name="request">Datos del correo a enviar</param>
        /// <returns>Respuesta con el resultado del envío</returns>
        [HttpPost("enviar")]
        [ProducesResponseType(typeof(ApiResponse<DTO_SMTP_respuesta>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EnviarCorreo([FromBody] DTO_SMTP_envio request)
        {
            try
            {
                var recipientCount = request?.Recipients?.Count ?? 0;
                _logger.LogInformation("Iniciando envío de correo a {Count} destinatarios", recipientCount);

                if (request == null)
                {
                    return BadRequest(ApiResponse<object>.ErrorResponse(
                        "La solicitud no puede ser nula",
                        "Datos inválidos"
                    ));
                }

                if (request.Recipients == null || request.Recipients.Count == 0)
                {
                    return BadRequest(ApiResponse<object>.ErrorResponse(
                        "Debe proporcionar al menos un destinatario",
                        "Destinatarios requeridos"
                    ));
                }

                if (string.IsNullOrWhiteSpace(request.Subject))
                {
                    return BadRequest(ApiResponse<object>.ErrorResponse(
                        "El asunto es requerido",
                        "Asunto requerido"
                    ));
                }

                if (string.IsNullOrWhiteSpace(request.Body))
                {
                    return BadRequest(ApiResponse<object>.ErrorResponse(
                        "El cuerpo del mensaje es requerido",
                        "Cuerpo requerido"
                    ));
                }

                var resultado = await _smtpService.SendEmailAsync(request);

                if (resultado.Success)
                {
                    _logger.LogInformation("Correo enviado exitosamente");
                    return Ok(ApiResponse<DTO_SMTP_respuesta>.SuccessResponse(
                        resultado,
                        "Correo enviado correctamente"
                    ));
                }
                else
                {
                    var errorMsg = resultado.Error ?? "Error desconocido";
                    _logger.LogWarning("Error al enviar correo: {Error}", errorMsg);
                    return BadRequest(ApiResponse<DTO_SMTP_respuesta>.ErrorResponse(
                        errorMsg,
                        resultado.Message
                    ));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Excepción al enviar correo");
                return StatusCode(500, ApiResponse<object>.ErrorResponse(
                    ex.Message,
                    "Error interno del servidor"
                ));
            }
        }

        /// <summary>
        /// Obtiene correos filtrados por asunto
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda por asunto</param>
        /// <returns>Lista de correos que coinciden con el filtro</returns>
        [HttpPost("recibir")]
        [ProducesResponseType(typeof(ApiResponse<List<EmailDetailResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecibirCorreos([FromBody] DTO_IMAP_filtro filtro)
        {
            try
            {
                var filterValue = filtro?.SubjectFilter ?? "sin filtro";
                _logger.LogInformation("Buscando correos con filtro: {Filtro}", filterValue);

                if (filtro == null || string.IsNullOrWhiteSpace(filtro.SubjectFilter))
                {
                    return BadRequest(ApiResponse<object>.ErrorResponse(
                        "Debe proporcionar un filtro de búsqueda",
                        "Filtro requerido"
                    ));
                }

                List<MimeMessage> correos = await _imapService.GetEmailsBySubjectAsync(filtro);

                if (correos == null || correos.Count == 0)
                {
                    return Ok(ApiResponse<List<EmailDetailResponse>>.SuccessResponse(
                        new List<EmailDetailResponse>(),
                        "No se encontraron correos con ese filtro"
                    ));
                }

                var emailsResponse = new List<EmailDetailResponse>();

                foreach (var msg in correos)
                {
                    var email = new EmailDetailResponse
                    {
                        From = msg.From != null ? msg.From.ToString() : "Desconocido",
                        To = msg.To != null ? msg.To.ToString() : "Desconocido",
                        Subject = msg.Subject ?? "Sin asunto",
                        Body = msg.TextBody ?? msg.HtmlBody ?? "Sin contenido",
                        Date = msg.Date.DateTime
                    };

                    if (msg.Attachments != null)
                    {
                        email.HasAttachments = msg.Attachments.Any();
                        email.Attachments = msg.Attachments
                            .Select(a => a.ContentType?.Name ?? "sin nombre")
                            .ToList();
                    }
                    else
                    {
                        email.HasAttachments = false;
                        email.Attachments = new List<string>();
                    }

                    emailsResponse.Add(email);
                }

                _logger.LogInformation("Se encontraron {Count} correos", emailsResponse.Count);

                return Ok(ApiResponse<List<EmailDetailResponse>>.SuccessResponse(
                    emailsResponse,
                    string.Format("Se encontraron {0} correo(s)", emailsResponse.Count)
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener correos");
                return StatusCode(500, ApiResponse<object>.ErrorResponse(
                    ex.Message,
                    "Error al obtener correos"
                ));
            }
        }

        /// <summary>
        /// Obtiene el último correo que coincide con el asunto proporcionado
        /// </summary>
        /// <param name="request">Datos de búsqueda del último correo</param>
        /// <returns>Detalles del último correo encontrado</returns>
        [HttpPost("ultimo")]
        [ProducesResponseType(typeof(ApiResponse<EmailDetailResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObtenerUltimoCorreo([FromBody] DTO_IMAP_getlast request)
        {
            try
            {
                var subjectValue = request?.Subject ?? "sin asunto";
                _logger.LogInformation("Buscando último correo con asunto: {Subject}", subjectValue);

                if (request == null || string.IsNullOrWhiteSpace(request.Subject))
                {
                    return BadRequest(ApiResponse<object>.ErrorResponse(
                        "Debe proporcionar un asunto para buscar",
                        "Asunto requerido"
                    ));
                }

                var mensaje = await _imapService.GetLastEmailAsync(request);

                if (mensaje == null)
                {
                    return NotFound(ApiResponse<object>.ErrorResponse(
                        "No se encontró ningún correo con ese asunto",
                        "Correo no encontrado"
                    ));
                }

                var emailResponse = new EmailDetailResponse
                {
                    From = mensaje.From != null ? mensaje.From.ToString() : "Desconocido",
                    To = mensaje.To != null ? mensaje.To.ToString() : "Desconocido",
                    Subject = mensaje.Subject ?? "Sin asunto",
                    Body = mensaje.TextBody ?? mensaje.HtmlBody ?? "Sin contenido",
                    Date = mensaje.Date.DateTime
                };

                if (mensaje.Attachments != null)
                {
                    emailResponse.HasAttachments = mensaje.Attachments.Any();
                    emailResponse.Attachments = mensaje.Attachments
                        .Select(a => a.ContentType?.Name ?? "sin nombre")
                        .ToList();
                }
                else
                {
                    emailResponse.HasAttachments = false;
                    emailResponse.Attachments = new List<string>();
                }

                _logger.LogInformation("Último correo encontrado: {Subject}", emailResponse.Subject);

                return Ok(ApiResponse<EmailDetailResponse>.SuccessResponse(
                    emailResponse,
                    "Último correo encontrado"
                ));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener último correo");
                return StatusCode(500, ApiResponse<object>.ErrorResponse(
                    ex.Message,
                    "Error al obtener último correo"
                ));
            }
        }

        /// <summary>
        /// Verifica el estado de la API
        /// </summary>
        [HttpGet("health")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        public IActionResult Health()
        {
            var healthData = new { status = "healthy", timestamp = DateTime.UtcNow };
            return Ok(ApiResponse<object>.SuccessResponse(
                healthData,
                "API funcionando correctamente"
            ));
        }
    }
}