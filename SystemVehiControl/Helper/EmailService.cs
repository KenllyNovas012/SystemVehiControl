using System.Net;
using System.Net.Mail;

namespace SystemVehiControl.Helper
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpHost = "smtp.tu-servidor.com"; // Cambia aquí
        private readonly int _smtpPort = 587; // Cambia si usas otro puerto
        private readonly string _smtpUser = "tu-email@dominio.com"; // Cambia aquí
        private readonly string _smtpPass = "tu-contraseña"; // Cambia aquí

        public async Task<bool> EnviarCorreoAsync(string destinatario, string asunto, string cuerpo)
        {
            try
            {
                var mensaje = new MailMessage();
                mensaje.From = new MailAddress(_smtpUser);
                mensaje.To.Add(destinatario);
                mensaje.Subject = asunto;
                mensaje.Body = cuerpo;
                mensaje.IsBodyHtml = false;

                using var client = new SmtpClient(_smtpHost, _smtpPort)
                {
                    Credentials = new NetworkCredential(_smtpUser, _smtpPass),
                    EnableSsl = true
                };

                await client.SendMailAsync(mensaje);
                return true;
            }
            catch
            {
                // Aquí puedes loguear el error si quieres
                return false;
            }
        }
    }
}
