using MailKit.Net.Smtp;
using MailService.DbContexts;
using MailService.Entities;
using MailService.Models;
using MimeKit;

namespace MailService.Services
{
    /// <summary>
    /// Реализация метода интерфейса IMailSenderService для отсылки сообщений
    /// </summary>
    public class MailSenderService : IMailSenderService
    {
        private readonly MailConfiguration _mailConfiguration;
        private readonly MailServiceContext _context;

        /// <summary>
        ///  Конструктор, принимает конфигурацию сервиса и контекст БД сервиса
        /// </summary>
        /// <param name="mailConfiguration">Конфигурацию сервиса (Отправитель)</param>
        /// <param name="context">Контекст БД</param>
        /// <exception cref="ArgumentNullException">Проверка входных параметров на null</exception>
        public MailSenderService(MailConfiguration mailConfiguration,
            MailServiceContext context)
        {
            _mailConfiguration = mailConfiguration ??
                throw new ArgumentNullException(nameof(mailConfiguration));
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Метод, который отправляет сообщение с заданными параметрами
        /// и сохраняет результат в БД
        /// </summary>
        /// <param name="mail">Модель данных для отсылки сообщения</param>
        /// <returns></returns>
        public async Task SendMailAsync(MailSenderDto mail)
        {
            // Создаем объект MimeMessage из модели данных mail
            var emailMessage = CreateEmailMessage(mail);

            // Создаем объект SmtpClient для отсылки сообщений
            using (var client = new SmtpClient())
            {
                try
                {
                    // Подключаемся к SMTP-серверу с заданными параметрами
                    await client.ConnectAsync(_mailConfiguration.SmtpServer, _mailConfiguration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_mailConfiguration.UserName, _mailConfiguration.Password);

                    // Отправляем сообщение
                    await client.SendAsync(emailMessage);

                    // Создаем объект Mail для сохранения в БД с результатом OK
                    var updatedMailEntity = new Mail
                    {
                        Subject = mail.Subject,
                        Body = mail.Body,
                        CreatedAt = DateTime.Now,
                        Result = MailResultEnum.OK,
                        Recipients = mail.Reciepents.Select(r => new Recipient(r)).ToList()
                    };

                    // Добавляем объект Mail в контекст БД
                    _context.Mails.Add(updatedMailEntity);
                }
                catch (Exception ex)
                {
                    // Если произошла ошибка при отправке сообщения,
                    // создаем объект Mail для сохранения в БД с результатом Failed
                    // и сообщением об ошибке
                    var updatedMailEntity = new Mail
                    {
                        Subject = mail.Subject,
                        Body = mail.Body,
                        CreatedAt = DateTime.Now,
                        Result = MailResultEnum.Failed,
                        FailedMessage = ex.Message,
                        Recipients = mail.Reciepents.Select(r => new Recipient(r)).ToList()
                    };

                    // Добавляем объект Mail в контекст БД
                    _context.Mails.Add(updatedMailEntity);
                }
                finally
                {
                    // Отключаемся от SMTP-сервера и освобождаем ресурсы
                    await client.DisconnectAsync(true);
                    client.Dispose();

                    // Сохраняем изменения в БД асинхронно
                    await _context.SaveChangesAsync();
                }
            }
        }

        // Метод, который создает объект MimeMessage из модели данных MailSenderDto
        private MimeMessage CreateEmailMessage(MailSenderDto mail)
        {
            var emailMessage = new MimeMessage();

            // Устанавливаем адрес отправителя из конфигурации сервиса
            emailMessage.From.Add(new MailboxAddress("email", _mailConfiguration.From));

            // Устанавливаем адресатов из модели данных MailSenderDto
            var recipients = mail.Reciepents.Select(r => new MailboxAddress(r, r)).ToList();
            emailMessage.To.AddRange(recipients);

            // Устанавливаем тему и текст сообщения из модели данных MailSenderDto
            emailMessage.Subject = mail.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = mail.Body };

            return emailMessage;
        }
    }
}
