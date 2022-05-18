using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using TRMDesktopUI.Helpers;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        private IApiHelper _apiHelper;
        private string _errorMessage;
        private bool _isLoading = false;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (value == _isLoading) return;
                _isLoading = value;
                NotifyOfPropertyChange(() => IsLoading);
            }
        }


        public bool IsErrorVisible
        {
            get
            {
                bool output = ErrorMessage?.Length > 0;
                return output;
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (value == _errorMessage) return;
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        public LoginViewModel(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (value == _userName) return;
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }
        
        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool CanLogIn
        {
            get
            {
                bool output = UserName?.Length > 0 && Password?.Length > 0;
                return output;
            }
        }

        public async Task LogIn()
        {
            try
            {
                LoadingStart();
                await Task.Delay(1000);
                if (ErrorMessage?.Length > 0) ErrorMessage = string.Empty;
                var result = await _apiHelper.Authtenticate(UserName, Password);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                LoadingFinish();
            }
        }

        private void LoadingStart()
        {
            IsLoading = true;
        }
        
        private void LoadingFinish()
        {
            IsLoading = false;
        }
    }
}