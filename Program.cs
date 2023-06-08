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

           

            // Instantiation de la classe Course
          
        }
    }
}