
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace raspaditaAPi.seguridad
{
   
    public class JwtUtils : IJwtUtils
    {
        private readonly IConfiguration _configuration;
        public JwtUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(usuarioResponse user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyconfiguration = _configuration.GetSection("JWT");
            var key = Encoding.ASCII.GetBytes(keyconfiguration["key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(5), //  DateTime.UtcNow.AddHours(0.5),//DateTime.UtcNow.AddDays(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public int? ValidateToken(string token)
        {
            int userId = 0;
            if(token == null)
                return null;

            if(token == "null")
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var keyconfiguration = _configuration.GetSection("JWT");
            var key = Encoding.ASCII.GetBytes(keyconfiguration["key"]);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                //// Will get the time stamp in unix time
                //var utcExpiryDate = long.Parse(jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
                //// we convert the expiry date from seconds to the date
                //var expDate = UnixTimeStampToDateTime(utcExpiryDate);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch(SecurityTokenExpiredException exp)
            {
                if(exp.Expires < DateTime.Now)
                {
                    userId = -1;
                    return userId;
                }
                else
                {
                    return null;
                }

            }
        }

    }
}
