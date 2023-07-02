using MailService.DbContexts;
using MailService.Entities;
using Microsoft.EntityFrameworkCore;

namespace MailService.Services
{
    /// <summary>
    ///  Реализирует методы интерфейса IMailServiceRepository для работы с репозиторием сообщений
    /// </summary>
    public class MailServiceRepository : IMailServiceRepository
    {
        private readonly MailServiceContext _context;

        /// <summary>
        /// Конструктор, принимающий контекст БД сервиса
        /// </summary>
        /// <param name="context">Контекст БД</param>
        /// <exception cref="ArgumentNullException">Проверка входного параметра на null</exception>
        public MailServiceRepository(MailServiceContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Метод, получает все сообщения и адресаты из репозитория
        /// и сортирует их по убыванию даты создания
        /// </summary>
        /// <returns>Список сообщений со всеми данными</returns>
        public async Task<IEnumerable<Mail>> GetMailsAsync()
        {
            return await _context.Mails.Include(mail => mail.Recipients)
                .OrderByDescending(mail => mail.CreatedAt).ToListAsync();
        }
    }
}
