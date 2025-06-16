using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using NavigationMVVM.ViewModel.Commands;

namespace PatientApplication.WPF.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : BaseViewModel;

    public class BaseViewModel : INotifyPropertyChanged
    {
        public virtual void Dispose() { }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BaseViewModel()
        {
            Minimize = new MinimizeCloseCommands(ExecuteMinimizeCommand);
            Close = new MinimizeCloseCommands(ExecuteCloseCommand);
            Maximize = new MinimizeCloseCommands(ExecuteMaximizeCommand);
        }

        public ICommand Maximize { get; }
        public ICommand Minimize { get; }
        public ICommand Close { get; }

        private void ExecuteMinimizeCommand(object parameter)
        {
            var window = Application.Current.Windows[0]; // Assuming single-window application
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void ExecuteCloseCommand(object parameter)
        {
            var window = Application.Current.Windows[0]; // Assuming single-window application
            if (window != null)
            {
                window.Close();
            }
        }

        private void ExecuteMaximizeCommand(object parameter)
        {
            var window = Application.Current.Windows[0]; // Assuming single-window application
            if (window != null)
            {
                if (window.WindowState == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                }
                else
                {
                    window.WindowState = WindowState.Maximized;
                }
            }
        }
    }
}
