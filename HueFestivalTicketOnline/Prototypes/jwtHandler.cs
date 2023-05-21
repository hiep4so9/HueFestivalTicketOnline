
using System.Security.Cryptography;

namespace HueOnlineTicketFestival.Prototypes
{
    public class jwtHandler
    {

        public jwtHandler()
        {

        }

        public static string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
    }
}