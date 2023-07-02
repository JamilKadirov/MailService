namespace MailService.Entities
{
    /// <summary>
    /// Перечисление возможных результатов отправки сообщения
    /// </summary>
    public enum MailResultEnum
    {
        /// <summary>
        /// Учпешно отправлено
        /// </summary>
        OK,

        /// <summary>
        /// Не удалось отправить
        /// </summary>
        Failed
    }
}
