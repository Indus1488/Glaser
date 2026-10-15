using System.Linq;
using System.Windows;

namespace GradeApp
{
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();

            const int currentStudentId = 1;

            GradesGrid.ItemsSource = SampleData.Grades
                .Where(g => g.StudentId == currentStudentId)
                .Select(g => new
                {
                    Disc = SampleData.Disciplines.First(d => d.Id == g.DisciplineId).Name,
                    g.Date,
                    g.Type,
                    g.Value
                })
                .ToList();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
    }
}