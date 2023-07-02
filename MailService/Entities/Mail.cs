using System.ComponentModel.DataAnnotations;

namespace MailService.Entities
{
    /// <summary>
    /// Сущность сообщения
    /// </summary>
    public class Mail
    {
        /// <summary>
        /// ID сообщения
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тема сообщения. Максимальная длина 50 символов
        /// </summary>
        [MaxLength(50)]
        public string? Subject { get; set; }

        /// <summary>
        /// Текст сообщения. Максимальная длина 200 символов
        /// </summary>
        [MaxLength(200)]
        public string? Body { get; set; }

        /// <summary>
        /// Список адресатов сообщения
        /// </summary>
        public ICollection<Recipient> Recipients { get; set; } = new List<Recipient>();

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
        public string FailedMessage { get; set; } = string.Empty;
    }
}
