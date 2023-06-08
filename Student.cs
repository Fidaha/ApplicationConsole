﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationConsole
{
    internal class Student
    {
        // Les attributs de la classe Student
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateTime DateBirth { get; set; }

        public Dictionary<string, List<(double grade,string appreciation)>> grades = new Dictionary<string,
        List<(double grade, string appreciation)>>();


        // Les méthodes

        // Ajouter une note
        public void AddGrade(string course, double grade, string appreciation)
        {
            if (!grades.ContainsKey(course))
            {
                grades[course] = new List<(double grade, string appreciation)>();
            }
            grades[course].Add((grade, appreciation));
        }

        // Calculer la moyenne
        public double Average()
        {
         
        }






    }
}