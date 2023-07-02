using AutoMapper;
using MailService.Models;
using MailService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MailService.Controllers
{
    /// <summary>
    /// Контроллер для формирования, рассылки и получения истории сообщений
    /// </summary>
    [Route("api/mails")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IMailServiceRepository _mailServiceRepository;
        private readonly IMailSenderService _mailSender;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор репозитория сообщений, автомаппера и сервиса рассылки сообщений
        /// </summary>
        /// <param name="mailServiceRepository">Репозиторий сообщений</param>
        /// <param name="mailSender">Сервис формирования и рассылки сообщений</param>
        /// <param name="mapper">Автомаппер</param>
        /// <exception cref="ArgumentNullException">Проверяет входные параметры на null</exception>
        public MailsController(IMailServiceRepository mailServiceRepository,
            IMailSenderService mailSender,
            IMapper mapper)
        {
            _mailServiceRepository = mailServiceRepository ??
                throw new ArgumentNullException(nameof(mailServiceRepository));
            _mailSender = mailSender ??
                throw new ArgumentNullException(nameof(mailSender));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Получает информацию/историю о сформированных сообщениях
        /// </summary>
        /// <returns>Список всех сформированных сообщений из базы</returns>
        [HttpGet("getmailshistory")]
        public async Task<ActionResult<IEnumerable<MailDto>>> GetMails()
        {
            var sentMails = await _mailServiceRepository.GetMailsAsync();
            return Ok(_mapper.Map<IEnumerable<MailDto>>(sentMails));
        }

        /// <summary>
        /// Формирует и рассылает сообщения
        /// </summary>
        /// <param name="mail">Модель данных для отправки сообщения</param>
        [HttpPost("generatemaildistribution")]
        public async Task GenerateMailDistribution(MailSenderDto mail)
        {
            await _mailSender.SendMailAsync(mail);
        }
    }
}
