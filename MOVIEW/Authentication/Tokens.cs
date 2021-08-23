using Microsoft.IdentityModel.Tokens;
using MOVIEW.Context;
using MOVIEW.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MOVIEW.Authentication
{
    public class Tokens
    {
        MoviewDbContext _context;

        public Tokens(MoviewDbContext context)
        {
            _context = context;
        }

        public string LoginUser(string Username, string Password)
        {
            string username = Username;
            string pass = Password;
            var user = _context.registers.SingleOrDefault(x => x.Username == username && x.Password == pass);

            //Authenticate User, Check if its a registered user in DB  - JRozario
            if (user == null)
                return null;

            var key = Encoding.ASCII.GetBytes("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");

            var JWToken = new JwtSecurityToken(
                issuer: "",
                audience: "",
                claims: GetUserClaims(user),
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,

                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            var strusername = user.Username;

            return token;
        }




        private IEnumerable<Claim> GetUserClaims(Register user)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;
            _claim = new Claim(ClaimTypes.Name, user.Username);
            claims.Add(_claim);
            //_claim = new Claim(ClaimTypes.Role, user.Role);
            //claims.Add(_claim);
            return claims.AsEnumerable<Claim>();
        }
    }
}
