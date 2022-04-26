using MMFoodDesktopUILibrary.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibrary.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLogedinUserInfo(string token);
        HttpClient ApiClient { get; }
    }
}