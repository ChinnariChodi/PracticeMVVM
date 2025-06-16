using PatientApplication.WPF.Commands;
using PatientApplication.WPF.State;
using PatientApplication.WPF.State.Authenticator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PatientApplication.WPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
		private string _username; //= "username"
        public string UserName
		{
			get { return _username; }
			set { 
				_username = value;
                OnPropertyChanged(nameof(UserName));
                OnPropertyChanged(nameof(CanLogin));
            }
        }

        private string _realText = "";
        private bool _isPasswordVisible = false;

        public string RealText
        {
            get => _realText;
            set
            {
                _realText = value;
                OnPropertyChanged(nameof(RealText));
                UpdateDisplayedText();
            }
        }

        private string _displayedText;
        public string DisplayedText
        {
            get => _displayedText;
            set
            {
                _displayedText = value;
                OnPropertyChanged(nameof(DisplayedText));
            }
        }

        public string ToggleIcon => _isPasswordVisible ? "🙈" : "👁";

        public ICommand ToggleVisibilityCommand { get; }

        private void ToggleVisibility()
        {
            _isPasswordVisible = !_isPasswordVisible;
            UpdateDisplayedText();
            OnPropertyChanged(nameof(ToggleIcon));
        }

        public void InsertCharacter(string input, int index)
        {
            if (index >= 0 && index <= RealText.Length)
            {
                RealText = RealText.Insert(index, input);
            }
        }

        public void DeleteCharacterAt(int index)
        {
            if (index >= 0 && index < RealText.Length)
            {
                RealText = RealText.Remove(index, 1);
            }
        }

        private void UpdateDisplayedText()
        {
            DisplayedText = _isPasswordVisible ? RealText : new string('*', RealText.Length);
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected void OnPropertyChanged(string propName) =>
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

    //private string _password;      
    //      public string PassWord
    //{
    //	get { return _password; }
    //	set { 
    //		_password = value;
    //              OnPropertyChanged(nameof(PassWord));
    //              OnPropertyChanged(nameof(CanLogin));
    //	}
    //}
    //  public PasswordChanded<RoutedEventArgs> PasswordChangedCommand { get; private set; }
        public bool CanLogin => !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(RealText);

		public MessageViewModel ErrorMessageVM { get; }

		public string ErrorMessage
		{
			set => ErrorMessageVM.Message = value;
		}
		public ICommand LoginCommand { get; set; }

        public LoginViewModel(IAuthenticator authenticator,IRenavigator renavigator)
        {
			ErrorMessageVM = new MessageViewModel();

            //  PasswordChangedCommand = new PasswordChanded<RoutedEventArgs>(OnPasswordChanged);
            ToggleVisibilityCommand = new PasswordCommand(ToggleVisibility);
            UpdateDisplayedText();
            LoginCommand = new LoginCommand(this, authenticator,renavigator);
        }

        //private void OnPasswordChanged(RoutedEventArgs e)
        //{
        //    var passwordBox = e.Source as PasswordBox;
        //    if (passwordBox != null)
        //    {
        //        PassWord = passwordBox.Password;  // Sync PasswordBox value to ViewModel
        //    }
        //}

        public override void Dispose()
        {
            ErrorMessageVM.Dispose();

            base.Dispose();
        }

    }
}
