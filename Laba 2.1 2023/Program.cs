using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        // Читаємо список студентів з файлу за шляхом ...\bin\Debug\net6.0
        List<Student> students = new List<Student>();
        using (StreamReader sr = new StreamReader("students.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                Student student = new Student { Name = parts[0], Grade = int.Parse(parts[1]) };
                students.Add(student);
            }
        }

        // Фільтруємо студентів за оцінками
        List<Student> filteredStudents = students.Where(s => s.Grade >= 80 && s.Grade <= 100).ToList();

        // Виводимо результати фільтрації
        Console.WriteLine("Список студентiв з оцiнками вiд 80 до 100:");
        foreach (Student student in filteredStudents)
        {
            Console.WriteLine("{0}, {1}", student.Name, student.Grade);
        }
    }
}
