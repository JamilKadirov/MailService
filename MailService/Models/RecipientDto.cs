namespace MailService.Models
{
    /// <summary>
    /// Модель данных для адресата сообщения
    /// </summary>
    public class RecipientDto
    {
        /// <summary>
        /// ФИО адресата. Пустая строка, если не указано
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Адрес эл.почты адресата
        /// </summary>
        public string? EmailAddress { get; set; }
    }
}
