using MMFoodDesktopUI.Models;
using System.Threading.Tasks;

namespace MMFoodDesktopUI.Helper
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}