using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibrary.Models
{
    public class AuthenticatedUser
    {
        public string access_token { get; set; }
        public string userName { get; set; }
    }
}
