using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Planner.Data.Domain;
using Planner.Data.Models;
using Planner.DTOs;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Planner.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AuthService(
            IMapper mapper,
            DataContext context
        )
        {
            _mapper = mapper;
            _context = context;
        }

        public UserDto GetUser(string token)
        {
            var user = _context.Users.FirstOrDefault(u => u.Token == token);

            return _mapper.Map<UserDto>(user);
        }

        public string Create(UserDto userDto)
        {
            if (_context.Users.Any(u => u.UserName == userDto.UserName))
                return "The user already exists";

            string token = GenerateToken(userDto.UserName);
            userDto.Token = token;
            userDto.Password = CreateMD5(userDto.Password);

            _context.Users.Add(_mapper.Map<User>(userDto));
            _context.SaveChanges();

            return token;
        }

        public static string CreateMD5(string password)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public string Login(LoginUser loginUser)
        {
            string encodedPassword = CreateMD5(loginUser.Password);
            User user = _context.Users.FirstOrDefault(u => u.UserName == loginUser.UserName && u.Password == encodedPassword);

            if (user == null)
                return "Wrong UserName or Password";

            user.Token = GenerateToken(loginUser.UserName);
            _context.SaveChanges();

            return user.Token;
        }

        public string Logout(string token)
        {
            User user = _context.Users.FirstOrDefault(u => u.Token == token);
            if (user == null)
                return "";


            user.Token = "";
            _context.SaveChanges();
            return "Logout succesfully";
        }

        private static string GenerateToken(string userName)
        {
            var mySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var myIssuer = "auth.plannerapi.com";
            var myAudience = "api.plannerapi.com";

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, userName),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = myIssuer,
                Audience = myAudience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateCurrentToken(string token)
        {
            var mySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var myIssuer = "auth.plannerapi.com";
            var myAudience = "api.plannerapi.com";

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = myIssuer,
                    ValidAudience = myAudience,
                    IssuerSigningKey = mySecurityKey
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
