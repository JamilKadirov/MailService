using AutoMapper;

namespace MailService.Profiles
{
    /// <summary>
    /// Профиль для маппинга между классами Recipient и RecipientDto
    /// </summary>
    public class RecipientProfile : Profile
    {
        /// <summary>
        /// Создаем правила маппинга в конструкторе
        /// </summary>
        public RecipientProfile()
        {
            CreateMap<Entities.Recipient, Models.RecipientDto>();
        }
    }
}
