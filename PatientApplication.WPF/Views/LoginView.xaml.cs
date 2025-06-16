using PatientApplication.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PatientApplication.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void PasswordTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                int caret = PasswordTextBox.CaretIndex;
                vm.InsertCharacter(e.Text, caret);

                // Force TextBox to show new value
                PasswordTextBox.Text = vm.DisplayedText;
                PasswordTextBox.CaretIndex = caret + 1;
                e.Handled = true;
            }
        }

        private void PasswordTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                int caret = PasswordTextBox.CaretIndex;

                if (e.Key == Key.Back && caret > 0)
                {
                    vm.DeleteCharacterAt(caret - 1);
                    PasswordTextBox.Text = vm.DisplayedText;
                    PasswordTextBox.CaretIndex = caret - 1;
                    e.Handled = true;
                }
                else if (e.Key == Key.Delete && caret < vm.RealText.Length)
                {
                    vm.DeleteCharacterAt(caret);
                    PasswordTextBox.Text = vm.DisplayedText;
                    PasswordTextBox.CaretIndex = caret;
                    e.Handled = true;
                }
            }
        }

    }
}
