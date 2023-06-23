using System.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ApplicationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
         // Exemple d'instanciation d'un étudiant
         //  Student student = new Student(1, "Doe", "John", "01/01/2000");
         // Exemple d'instanciation d'un cours
         // Course course = new Course(1, "Mathématiques");

           /* if (args.Length < 1)
            {
                Console.WriteLine("Veuillez fournir le chemin du fichier JSON de données en argument.");
                return;
             } */

            string filePath = "C:/Users/hafid/ApplicationConsole/data.json";
            Notebook notebook = LoadNotebook(filePath);

            Console.WriteLine("Bienvenue dans mon application !");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Menu principal :");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("1. Elèves");
                Console.WriteLine(" ");
                Console.WriteLine("2. Cours");
                Console.WriteLine(" ");
                Console.WriteLine("3. Quitter");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine(" ");
                Console.Write("Votre choix : ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowStudentMenu(notebook);
                        break;
                    case "2":
                        ShowCourseMenu(notebook);
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }

            SaveNotebook(notebook, filePath);
        }

        // Menu Etudiant
        static void ShowStudentMenu(Notebook notebook)
        {
            bool backToMain = false;

            while (!backToMain)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Menu Elèves :");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("1. Lister les élèves");
                Console.WriteLine(" ");
                Console.WriteLine("2. Créer un nouvel élève");
                Console.WriteLine(" ");
                Console.WriteLine("3. Consulter un élève existant");
                Console.WriteLine(" ");
                Console.WriteLine("4. Ajouter une note et une appréciation");
                Console.WriteLine(" ");
                Console.WriteLine("5. Revenir au menu principal");
                Console.WriteLine(" ");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.Write("Votre choix : ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListStudents(notebook);
                        break;
                    case "2":
                        CreateStudent(notebook);
                        break;
                    case "3":
                        ShowStudentDetails(notebook);
                        break;
                    case "4":
                        AddGrade(notebook);
                        break;
                    case "5":
                        backToMain = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }
        }

        // Menu Cours
        static void ShowCourseMenu(Notebook notebook)
        {
            bool backToMain = false;

            while (!backToMain)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Menu Cours :");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("1. Lister les cours");
                Console.WriteLine(" ");
                Console.WriteLine("2. Ajouter un nouveau cours");
                Console.WriteLine(" ");
                Console.WriteLine("3. Supprimer un cours");
                Console.WriteLine(" ");
                Console.WriteLine("4. Revenir au menu principal");
                Console.WriteLine(" ");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.Write("Votre choix : ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListCourses(notebook);
                        break;
                    case "2":
                        AddCourse(notebook);
                        break;
                    case "3":
                        DeleteCourse(notebook);
                        break;
                    case "4":
                        backToMain = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }
        }

        // Liste des étudiants
        static void ListStudents(Notebook notebook)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Liste des élèves :");
            Console.WriteLine(" ");

            foreach (var student in notebook.Students)
            {
                Console.WriteLine($"- {student.LastName} {student.FirstName}");
            }
        }

        // Créer un étudiant
        static void CreateStudent(Notebook notebook)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Création d'un nouvel élève :");
            Console.WriteLine(" ");
            Console.Write("Entrez le nom : ");
            Console.WriteLine(" ");
            string lastName = Console.ReadLine();
            Console.Write("Entrez le prénom : ");
            Console.WriteLine(" ");
            string firstName = Console.ReadLine();
            Console.Write("Entrez la date de naissance : ");
            Console.WriteLine(" ");
            string dateOfBirth = Console.ReadLine();

            int maxId = notebook.Students.Count > 0 ? notebook.Students.Max(s => s.Id) : 0;
            int newId = maxId + 1;

            var student = new Student(newId, lastName, firstName, dateOfBirth);
            notebook.Students.Add(student);

            Console.WriteLine("Nouvel élève créé avec succès.");
        }

        //Afficher un étudiant
        static void ShowStudentDetails(Notebook notebook)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Consultation d'un élève existant :");
            Console.WriteLine(" ");
            Console.Write("Entrez l'identifiant de l'élève : ");
            Console.WriteLine(" ");
            int studentId;

            while (!int.TryParse(Console.ReadLine(), out studentId))
            {
                Console.Write("Veuillez entrer un identifiant valide : ");
            }

            var student = FindStudentById(notebook, studentId);

            if (student == null)
            {
                Console.WriteLine("Aucun élève trouvé avec cet identifiant.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine(" ");
            Console.WriteLine("Informations sur l'élève :");
            Console.WriteLine(" ");
            Console.WriteLine($"Nom               : {student.LastName}");
            Console.WriteLine($"Prénom            : {student.FirstName}");
            Console.WriteLine($"Date de naissance : {student.DateOfBirth}");
            Console.WriteLine(" ");

            Console.WriteLine();
            Console.WriteLine("Résultats scolaires :");
            Console.WriteLine(" ");

            if (student.Grades.Count == 0)
            {
                Console.WriteLine("Aucune note enregistrée pour cet élève.");
            }
            else
            {
                foreach (var grade in student.Grades)
                {
                    Console.WriteLine();
                    Console.WriteLine($"        Cours : {grade.CourseName}");
                    Console.WriteLine($"        Note : {grade.Score}/20");
                    Console.WriteLine($"        Appréciation : {grade.Appreciation}");
                }

                double average = student.GetAverage();
                Console.WriteLine();
                Console.WriteLine($"    Moyenne : {average}/20");
            }
        }

        // Ajouter une note
        static void AddGrade(Notebook notebook)
        {
            Console.WriteLine("Ajout d'une note et d'une appréciation :");
            Console.Write("Entrez l'identifiant de l'élève : ");
            int studentId;

            while (!int.TryParse(Console.ReadLine(), out studentId))
            {
                Console.Write("Veuillez entrer un identifiant valide : ");
            }

            var student = FindStudentById(notebook, studentId);

            if (student == null)
            {
                Console.WriteLine("Aucun élève trouvé avec cet identifiant.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Cours disponibles :");

            foreach (var cour in notebook.Courses)
            {
                Console.WriteLine($"- {cour.Name}");
            }

            Console.Write("Entrez le nom du cours : ");
            string courseName = Console.ReadLine();

            var course = FindCourseByName(notebook, courseName);

            if (course == null)
            {
                Console.WriteLine("Aucun cours trouvé avec ce nom.");
                return;
            }

            Console.Write("Entrez la note (sur 20) : ");
            double score;

            while (!double.TryParse(Console.ReadLine(), out score) || score < 0 || score > 20)
            {
                Console.Write("Veuillez entrer une note valide (entre 0 et 20) : ");
            }

            Console.Write("Entrez l'appréciation : ");
            string appreciation = Console.ReadLine();

            var grade = new Grade(courseName, score, appreciation);
            student.Grades.Add(grade);

            Console.WriteLine("Note et appréciation ajoutées avec succès.");
        }

        // Lister les cours
        static void ListCourses(Notebook notebook)
        {
            Console.WriteLine("");
            Console.WriteLine("Liste des cours :");
            Console.WriteLine("");

            foreach (var course in notebook.Courses)
            {
                Console.WriteLine($"- {course.Name}");
            }
        }

        // Ajouter un cours
        static void AddCourse(Notebook notebook)
        {
            Console.WriteLine("");
            Console.WriteLine("Ajout d'un nouveau cours :");
            Console.WriteLine("");
            Console.Write("Entrez le nom du cours : ");
            string courseName = Console.ReadLine();

            int maxId = notebook.Courses.Count > 0 ? notebook.Courses.Max(c => c.Id) : 0;
            int newId = maxId + 1;

            var course = new Course(newId, courseName);
            notebook.Courses.Add(course);

            Console.WriteLine("Nouveau cours ajouté avec succès.");
        }

        // Supprimer un cours
        static void DeleteCourse(Notebook notebook)
        {
            Console.WriteLine("Suppression d'un cours :");
            Console.Write("Entrez l'identifiant du cours : ");
            int courseId;

            while (!int.TryParse(Console.ReadLine(), out courseId))
            {
                Console.Write("Veuillez entrer un identifiant valide : ");
            }

            var course = FindCourseById(notebook, courseId);

            if (course == null)
            {
                Console.WriteLine("Aucun cours trouvé avec cet identifiant.");
                return;
            }

            Console.WriteLine($"Voulez-vous vraiment supprimer le cours '{course.Name}' ? (O/N)");
            string confirmation = Console.ReadLine();

            if (confirmation.ToUpper() == "O")
            {
                notebook.Courses.Remove(course);
                RemoveCourseFromStudents(notebook, course.Name);
                Console.WriteLine("Cours supprimé avec succès.");
            }
        }

        static void RemoveCourseFromStudents(Notebook notebook, string courseName)
        {
            foreach (var student in notebook.Students)
            {
                student.Grades.RemoveAll(g => g.CourseName == courseName);
            }
        }

        // Trouver un Etudiant avec son Id
        static Student FindStudentById(Notebook notebook, int id)
        {
            return notebook.Students.FirstOrDefault(s => s.Id == id);
        }


        //Trouver un cours avec son nom

        static Course FindCourseByName(Notebook notebook, string name)
        {
            return notebook.Courses.FirstOrDefault(c => c.Name == name);
        }

        // trouver un cours avec son Id
        static Course FindCourseById(Notebook notebook, int id)
        {
            return notebook.Courses.FirstOrDefault(c => c.Id == id);
        }

        // Gestion du fichier json

        static void SaveNotebook(Notebook notebook, string filePath)
        {
            //string json = JsonConvert.SerializeObject(notebook);
            string json = JsonConvert.SerializeObject(notebook, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        static Notebook LoadNotebook(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Notebook>(json);
            }
            else
            {
                return new Notebook();
            }
        }
    }

   

  


}