using MailService.Entities;

namespace MailService.Services
{
    /// <summary>
    /// Интерфейс, определяющий методы для работы с репозиторием сообщений
    /// </summary>
    public interface IMailServiceRepository
    {
        /// <summary>
        /// Асинхронно получает все сообщения из репозитория
        /// </summary>
        /// <returns>Список сообщений</returns>
        Task<IEnumerable<Mail>> GetMailsAsync();
    }
}
