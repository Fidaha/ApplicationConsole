using System.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ApplicationConsole
{
    public class Student
    {
        public int Id { get; }
        public string LastName { get; }
        public string FirstName { get; }
        public string DateOfBirth { get; }
        public List<Grade> Grades { get; }

        public Student(int id, string lastName, string firstName, string dateOfBirth)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
            Grades = new List<Grade>();
        }

        public double GetAverage()
        {
            if (Grades.Count == 0)
            {
                return 0;
            }

            double sum = Grades.Sum(g => g.Score);
            return sum / Grades.Count;
        }
    }

}
