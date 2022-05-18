using System.Threading.Tasks;
using Caliburn.Micro;

namespace TRMDesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private LoginViewModel _loginVM;

        public ShellViewModel(LoginViewModel loginVm)
        {
            _loginVM = loginVm;
            Task.Run(async () => await ActivateItemAsync(_loginVM));
        }
    }
}