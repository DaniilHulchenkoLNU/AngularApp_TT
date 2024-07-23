
using AngularApp_TT.Server.Models.Entity;

namespace AngularApp_TT.Server.Models.Auth
{
    public class Accounts : DbBase<int>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<СryptoRate> UserHistoryList { get; set; }
    }

}
