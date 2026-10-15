using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GradeApp
{
    public partial class TeacherWindow : Window
    {
        public TeacherWindow()
        {
            InitializeComponent();

            DisciplineList.ItemsSource = SampleData.Disciplines;
            DisciplineList.SelectedIndex = 0;

            GroupCombo.ItemsSource = SampleData.Groups;
            GroupCombo.SelectedIndex = 0;

            StudentViewCombo.ItemsSource = SampleData.Students;
            StudentViewCombo.SelectedIndex = 0;

            GroupViewCombo.ItemsSource = SampleData.Groups;
            GroupViewCombo.SelectedIndex = 0;
        }

        private void GroupCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupCombo.SelectedItem is Group g)
            {
                StudentCombo.ItemsSource = SampleData.Students.Where(s => s.GroupId == g.Id).ToList();
                if (StudentCombo.Items.Count > 0) StudentCombo.SelectedIndex = 0;
            }
        }

        private void StudentCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshGrades();
        }

        private void DisciplineList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshGrades();
        }

        private void RefreshGrades()
        {
            if (DisciplineList.SelectedItem is Discipline d &&
                StudentCombo.SelectedItem is Student st)
            {
                GradesGrid.ItemsSource = SampleData.Grades
                    .Where(g => g.StudentId == st.Id && g.DisciplineId == d.Id)
                    .ToList();
            }
        }

        private void SaveGrade_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(GradeBox.Text))
                MessageBox.Show("Оценка пустая — запись будет удалена (заглушка).");
            else
                MessageBox.Show("Оценка «" + GradeBox.Text + "» сохранена (заглушка).");
        }

        private void StudentViewCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StudentViewCombo.SelectedItem is Student st)
            {
                StudentAllGradesGrid.ItemsSource = SampleData.Grades
                    .Where(g => g.StudentId == st.Id)
                    .Select(g => new
                    {
                        Disc = SampleData.Disciplines.First(d => d.Id == g.DisciplineId).Name,
                        g.Date,
                        g.Type,
                        g.Value
                    })
                    .ToList();
            }
        }

        private void GroupViewCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupViewCombo.SelectedItem is Group grp)
            {
                var ids = SampleData.Students
                    .Where(s => s.GroupId == grp.Id)
                    .Select(s => s.Id)
                    .ToList();

                GroupGradesGrid.ItemsSource = SampleData.Grades
                    .Where(g => ids.Contains(g.StudentId))
                    .Select(g => new
                    {
                        Student = SampleData.Students.First(s => s.Id == g.StudentId).FullName,
                        Disc = SampleData.Disciplines.First(d => d.Id == g.DisciplineId).Name,
                        g.Date,
                        g.Value
                    })
                    .ToList();
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }
    }
}