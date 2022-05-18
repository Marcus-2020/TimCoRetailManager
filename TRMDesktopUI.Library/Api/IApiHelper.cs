using System.Threading.Tasks;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.Library.Api
{
    public interface IApiHelper
    {
        Task<AuthenticatedUser> Authtenticate(string username, string password);
        Task GetLoggedInUserData(string accessToken);
    }
}