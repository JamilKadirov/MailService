using MailService.Models;

namespace MailService.Services
{
    /// <summary>
    /// Интерфейс, определяющий методы для отправки сообщений
    /// </summary>
    public interface IMailSenderService
    {
        /// <summary>
        /// Асинхронно отправляет сообщение с заданными параметрами
        /// </summary>
        /// <param name="mail">Модель данных для отправки сообщения</param>
        Task SendMailAsync(MailSenderDto mail);
    }
}
