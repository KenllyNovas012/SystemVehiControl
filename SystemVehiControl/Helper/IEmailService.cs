namespace SystemVehiControl.Helper
{
    public interface IEmailService
    {
        Task<bool> EnviarCorreoAsync(string destinatario, string asunto, string cuerpo);
    }
}
