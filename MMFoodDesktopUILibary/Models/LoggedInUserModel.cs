using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibary.Models
{
    public class LoggedInUserModel : ILoggedInUserModel
    {
        public string Token { get; set; }
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }

        public void ResetUserModel()
        {
            Token = "";
            Id = "";
            Username = "";
            Email = "";
            CreateDate = DateTime.MinValue;
        }
    }
}
