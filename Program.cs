using Newtonsoft.Json;

namespace ApplicationConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // string json = File.ReadAllText(args[0]);
            // Program obj = JsonConvert.DeserializeObject<Program>(json);

            // Instantiation de la classe Student
            Student student1 = new Student();
            

            student1.Id = 1;
            student1.FirstName = "Dupont";
            student1.LastName = "Jean";
            student1.DateBirth = new DateTime(2000, 1, 1);
            student1.AddGrade("Maths", 12.5, "Peut mieux faire");
            student1.AddGrade("Anglais", 15.0, "Bien");
            student1.AddGrade("Français", 10.0, "Insuffisant");

            Console.WriteLine("La moyenne est de l'éléve " + student1.LastName + " " + student1.FirstName + " est de : " + student1.Average());

            // Instantiation de la classe Course
            Course course1 = new Course();

            course1.Id = 1;
            course1.Name = "Maths";
            Course.AddCourse(course1);

            Course course2 = new Course();

            course2.Id = 2;
            course2.Name = "Français";
            Course.AddCourse(course2);

            Course course3 = new Course();

            course3.Id = 3;
            course3.Name = "Anglais";
            Course.AddCourse(course3);

            Course.ListCourse();

            Course.RemoveCourse(1);

            Console.WriteLine(" La liste des cours après la supression du cours nméro 1 est : ");

            Course.ListCourse();

            // =======================================test=========================================

            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("Information sur l'élève : ");

            // Ask the user to choice between course and student.

            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\ts - Student");
            Console.WriteLine("\tc - Course");
            Console.Write("Your option ? : ");

            // Use a switch statement
            switch (Console.ReadLine())
            {
                case "s":
                    Console.WriteLine($"La moyenne est de l'éléve " + student1.LastName + " " + student1.FirstName + " est de : " + student1.Average());
                    break;
                case "c":
                    Console.WriteLine($" La liste des cours après la supression du cours nméro 1 est : ");
                    Course.ListCourse();
                    break;
            }
            //------------------------------------------------------------------------------------------------
            //14/06 MODIFS












        }
    }
}