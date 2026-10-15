using System.Windows;
using System.Windows.Controls;

namespace GradeApp
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var role = (RoleCombo.SelectedItem as ComboBoxItem)?.Content?.ToString();

            Window next;
            if (role == "Студент")
                next = new StudentWindow();
            else
                next = new TeacherWindow();

            next.Show();
            Close();
        }
    }
}