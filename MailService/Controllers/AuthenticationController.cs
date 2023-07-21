using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MailService.Controllers
{
    /// <summary>
    /// Контроллер для аутентификации пользователя
    /// </summary>
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Класс с данными пользователя
        /// </summary>
        public class AuthenticationRequestBody
        {
            /// <summary>
            /// Имя пользователя
            /// </summary>
            public string? UserName { get; set; }

            /// <summary>
            /// Пароль пользователя
            /// </summary>
            public string? Password { get; set; }
        }

        private class MailServiceUser
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }

            public MailServiceUser(
                int userId,
                string username,
                string firstName,
                string lastName,
                string city)
            {
                UserId = userId;
                UserName = username;
                FirstName = firstName;
                LastName = lastName;
                City = city;
            }
        }

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration ?? 
                throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Метод для аутентификации пользователя
        /// </summary>
        /// <param name="authenticationRequestBody">Данные пользователя</param>
        /// <returns>Возвращает имя пользователя и пароль</returns>
        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate(
            AuthenticationRequestBody authenticationRequestBody)
        {
            // Валидируем пользователя и пароль
            var user = ValidateUserCredentials(
                authenticationRequestBody.UserName,
                authenticationRequestBody.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            // Создаем токен
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
            claimsForToken.Add(new Claim("given_name", user.FirstName));
            claimsForToken.Add(new Claim("family_name", user.LastName));
            claimsForToken.Add(new Claim("city", user.City));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        private MailServiceUser ValidateUserCredentials(string? userName, string? password)
        {
            return new MailServiceUser(
                1,
                userName ?? "",
                "Ayrat",
                "Yarullin",
                "Kazan");
        }
    }
}
