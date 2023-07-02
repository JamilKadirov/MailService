using MailService.Entities;

namespace MailService.Models
{
    /// <summary>
    /// Модель отображения данных сообщения
    /// </summary>
    public class MailDto
    {
        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string? Body { get; set; }

        /// <summary>
        /// Список адресатов сообщения
        /// </summary>
        public ICollection<RecipientDto> Recipients { get; set; } = new List<RecipientDto>();

        /// <summary>
        /// Дата и время создания сообщения
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Результат отправки сообщения - OK, Failed
        /// </summary>
        public MailResultEnum Result { get; set; }

        /// <summary>
        /// Текст ошибки, если сообщение не отправилось. Пустая строка, если отправка успешна
        /// </summary>
        public string? FailedMessage { get; set; }
    }
}
