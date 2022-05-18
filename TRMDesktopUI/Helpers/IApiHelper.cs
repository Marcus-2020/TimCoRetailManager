using System.Net.Http;
using System.Threading.Tasks;
using TRMDesktopUI.Models;

namespace TRMDesktopUI.Helpers
{
    public interface IApiHelper
    {
        Task<AuthenticatedUser> Authtenticate(string username, string password);
    }
}