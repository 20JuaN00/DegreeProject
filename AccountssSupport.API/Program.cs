using AccountsSupport.Core.Mail.Interfaz;
using AccountsSupport.Core.Mail.Servicios;
using AccountsSupport.Core.Mail.Settings;

var builder = WebApplication.CreateBuilder(args);

// ===== CONFIGURACIÓN DE SERVICIOS =====

// 1. Configurar Settings_Mail desde appsettings.json
builder.Services.AddSingleton(sp =>
{
    var config = builder.Configuration.GetSection("MailSettings");
    return new Settings_Mail
    {
        SmtpServer = config["SmtpServer"],
        SmtpPort = int.Parse(config["SmtpPort"]),
        SmtpUseSsl = bool.Parse(config["SmtpUseSsl"]),
        SmtpUsername = config["SmtpUsername"],
        SmtpPwd = config["SmtpPwd"],
        ImapServer = config["ImapServer"],
        ImapPort = int.Parse(config["ImapPort"]),
        ImapUseSsl = bool.Parse(config["ImapUseSsl"]),
        ImapUsername = config["ImapUsername"],
        ImapPwd = config["ImapPwd"]
    };
});

// 2. Registrar servicios de negocio
builder.Services.AddScoped<Interface_SMTP, Service_SMTP>();
builder.Services.AddScoped<Interface_IMAP, Service_IMAP>();

// 3. Agregar controladores
builder.Services.AddControllers();

// 4. Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "AccountsSupport Mail API",
        Version = "v1",
        Description = "API para envío y recepción de correos electrónicos mediante SMTP e IMAP"
    });
});

// 5. Configurar CORS
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()
                     ?? new[] { "*" };

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// ===== CONSTRUCCIÓN DE LA APP =====
var app = builder.Build();

// ===== CONFIGURACIÓN DEL PIPELINE =====

// 1. Swagger (solo en desarrollo)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AccountsSupport Mail API v1");
        c.RoutePrefix = string.Empty; // Swagger en la raíz
    });
}

// 2. Redirección HTTPS
app.UseHttpsRedirection();

// 3. CORS
app.UseCors("AllowSpecificOrigins");

// 4. Autorización
app.UseAuthorization();

// 5. Mapear controladores
app.MapControllers();

// ===== INICIAR LA APP =====
app.Run();