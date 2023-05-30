using HueFestivalTicketOnline.Data;
using System.Security.Cryptography;

namespace HueFestivalTicketOnline.Helpers
{
    public class GenerateRefreshToken
    {
        public static RefreshToken CreateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }
    }
}
