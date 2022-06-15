using MMFoodDesktopUILibary.Models;
using System.Threading.Tasks;

namespace MMFoodDesktopUILibary.Api
{
    public interface IAccountEndPoint
    {
        Task CreateAccount(RegisterBindingModel newUser);
    }
}