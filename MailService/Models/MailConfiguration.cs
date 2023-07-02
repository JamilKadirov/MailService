namespace MailService.Models
{
    /// <summary>
    /// Класс конфигурации сервиса для библиотеки MailKit. (Отправитель)
    /// </summary>
    public class MailConfiguration
    {
        /// <summary>
        /// Адрес эл.почты отправителя
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Адрес SMTP-сервера для отправки сообщения
        /// </summary>
        public string SmtpServer { get; set; }

        /// <summary>
        /// Порт SMTP-сервера для отправки почты
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Имя пользователя для аутентификации на SMTP-сервере
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Пароль для аутентификации на SMTP-сервере
        /// </summary>
        public string Password { get; set; }
    }
}
