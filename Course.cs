using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationConsole
{
    public class Course
    {
        // Les attributs
        public int Id;
        public string Name;

        public static List<Course> liste_course = new List<Course>();


        //Les méthodes

        // Lister les cours existants
        public static void ListCourse()
        {
            foreach (var course in liste_course)
            {
                Console.WriteLine(course.Id + " - " + course.Name);
            }
        }

        // Ajouter un nouveau cours au programme
        public static void AddCourse(Course course)
        {
            liste_course.Add(course);
        }

        // Supprimer un cours par son identifiant
        public static void RemoveCourse(int id) 
        {
            foreach(var course in liste_course)
            {
                if (course.Id == id)
                {
                    liste_course.Remove(course);
                    break;
                }
            }
        }





    }
}
