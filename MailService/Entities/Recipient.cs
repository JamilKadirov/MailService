using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MailService.Entities
{
    /// <summary>
    /// Сущность адресата сообщения
    /// </summary>
    public class Recipient
    {
        /// <summary>
        /// ID адресата
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ФИО адресата. Максимальная длина 50 символов
        /// </summary>
        [MaxLength(50)]
        public string? Name { get; set; }

        /// <summary>
        /// Адрес эл.почты адресата. Задана проверка соответствия формату email адреса
        /// </summary>
        [EmailAddress(ErrorMessage = "Неверный формат email адреса.")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Сообщение, предназначенное для адресата. Игнорируется при сериализации в JSON
        /// </summary>
        [JsonIgnore]
        public Mail? Mail { get; set; }
        /// <summary>
        /// ID сообщения, предназначенного для адресата
        /// </summary>
        public int MailId { get; set; }

        /// <summary>
        /// Конструктор, принимает адрес эл.почты адресата и записывает его в свойство EmailAddress
        /// </summary>
        /// <param name="emailAddress">Адрес эл.почты адресата</param>
        public Recipient(string emailAddress)
        {
            EmailAddress = emailAddress;
        }
    }
}
