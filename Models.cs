using System;
using System.Collections.Generic;

namespace GradeApp
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }

    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() => Name;
    }

    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int GroupId { get; set; }
        public override string ToString() => FullName;
    }

    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DisciplineId { get; set; }
        public int? Value { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
    }

    public static class SampleData
    {
        public static List<Discipline> Disciplines = new List<Discipline>
        {
            new Discipline { Id = 1, Name = "Математика" },
            new Discipline { Id = 2, Name = "Физика" },
            new Discipline { Id = 3, Name = "Информатика" },
            new Discipline { Id = 4, Name = "Программирование" },
            new Discipline { Id = 5, Name = "Базы данных" },
        };

        public static List<Group> Groups = new List<Group>
        {
            new Group { Id = 1, Name = "ИС-21" },
            new Group { Id = 2, Name = "ИС-22" },
            new Group { Id = 3, Name = "ПР-21" },
        };

        public static List<Student> Students = new List<Student>
        {
            new Student { Id = 1, FullName = "Петров П.П.", GroupId = 1 },
            new Student { Id = 2, FullName = "Сидоров С.С.", GroupId = 1 },
            new Student { Id = 3, FullName = "Кузнецова А.А.", GroupId = 1 },
            new Student { Id = 4, FullName = "Смирнов Д.Д.", GroupId = 2 },
            new Student { Id = 5, FullName = "Волкова Е.Е.", GroupId = 2 },
        };

        public static List<Grade> Grades = new List<Grade>
        {
            new Grade { Id = 1, StudentId = 1, DisciplineId = 1, Value = 5, Date = DateTime.Now.AddDays(-10), Type = "Контрольная" },
            new Grade { Id = 2, StudentId = 1, DisciplineId = 1, Value = 4, Date = DateTime.Now.AddDays(-5),  Type = "Тест" },
            new Grade { Id = 3, StudentId = 1, DisciplineId = 3, Value = 5, Date = DateTime.Now.AddDays(-3),  Type = "Лабораторная" },
            new Grade { Id = 4, StudentId = 2, DisciplineId = 1, Value = 3, Date = DateTime.Now.AddDays(-10), Type = "Контрольная" },
            new Grade { Id = 5, StudentId = 2, DisciplineId = 1, Value = 4, Date = DateTime.Now.AddDays(-5),  Type = "Тест" },
            new Grade { Id = 6, StudentId = 3, DisciplineId = 1, Value = 5, Date = DateTime.Now.AddDays(-10), Type = "Контрольная" },
            new Grade { Id = 7, StudentId = 1, DisciplineId = 4, Value = 5, Date = DateTime.Now.AddDays(-2),  Type = "Курсовая" },
        };
    }
}