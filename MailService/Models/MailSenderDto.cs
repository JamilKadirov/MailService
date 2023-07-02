namespace MailService.Models
{
    /// <summary>
    /// Модель данных для отправки сообщения
    /// </summary>
    public class MailSenderDto
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
        /// Список адресатов
        /// </summary>
        public ICollection<string> Reciepents { get; set; } = new List<string>();
    }
}
