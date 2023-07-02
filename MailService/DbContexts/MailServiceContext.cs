using MailService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MailService.DbContexts
{
    /// <summary>
    /// Класс DbContext, представляющий базу данных сформированных сообщений
    /// </summary>
    public class MailServiceContext : DbContext
    {
        /// <summary>
        /// Свойство, представляющее таблицу сообщений в БД
        /// </summary>
        public DbSet<Mail> Mails { get; set; } = null!;

        public MailServiceContext(DbContextOptions<MailServiceContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// Метод, который настраивает модель для БД
        /// </summary>
        /// <param name="modelBuilder">Позволяет сформировать и построить модель БД</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Заполняем в БД первые данные для сообщений и адресатов
            modelBuilder.Entity<Mail>()
                  .HasData(
                new Mail()
                {
                    Id = 1,
                    Subject = "The best subject ever",
                    Body = "Here's to be a CTA text or some random text",
                    CreatedAt = DateTime.Now,
                    Result = 0

                },
                new Mail()
                {
                    Id = 2,
                    Subject = "Самый продающий текст",
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed quis nisl vitae nisi tincidunt pretium. Phasellus auctor, magna id consequat malesuada, leo augue mattis massa, quis aliquet sapien nisi quis nunc",
                    CreatedAt = DateTime.Now,
                    Result = MailResultEnum.Failed
                });

            // Преобразуем числовое(enum) значение Result в string для записи в БД
            modelBuilder.Entity<Mail>().Property(msg => msg.Result)
                .HasConversion(new EnumToStringConverter<MailResultEnum>());

            modelBuilder.Entity<Recipient>()
                  .HasData(
                new Recipient("Иванов И.И.")
                {
                    Id = 1,
                    MailId = 2,
                    EmailAddress = "username@example.ru"
                },
                new Recipient("Lee Sam")
                {
                    Id = 2,
                    MailId = 1,
                    EmailAddress = "username1@example.com"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
