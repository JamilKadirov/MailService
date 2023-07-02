using AutoMapper;

namespace MailService.Profiles
{
    /// <summary>
    /// Профиль для маппинга между классами Mail и MailDto
    /// </summary>
    public class MailProfile : Profile
    {
        /// <summary>
        /// Создаем правила маппинга в конструкторе
        /// </summary>
        public MailProfile()
        {
            CreateMap<Entities.Mail, Models.MailDto>();
            CreateMap<Models.MailSenderDto, Entities.Mail>();
        }
    }
}
