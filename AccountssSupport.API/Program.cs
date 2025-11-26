using AccountsSupport.Core.Mail.Interfaz;
using AccountsSupport.Core.Mail.Servicios;
using AccountsSupport.Core.Mail.Settings;

var builder = WebApplication.CreateBuilder(args);


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

builder.Services.AddScoped<Interface_SMTP, Service_SMTP>();
builder.Services.AddScoped<Interface_IMAP, Service_IMAP>();

builder.Services.AddControllers();

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


var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()
                     ?? new[] { "*" };

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AccountsSupport Mail API v1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();