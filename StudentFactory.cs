using PersonNP;
using StudentNP;
using IPersonFactoryNP;


namespace StudentFactoryNP
{

    public class StudentFactory : IPersonFactory
    {
        public Person CreatePerson()
        {

            float grade = 0;

            Console.Write("Enter student ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter student Phone: ");
            string phone = Console.ReadLine();

            try
            {
                Console.Write("Enter student Grade: ");
                grade = float.Parse(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine("\nYou entered the wrong Student's Grade, please re-enter it!");
                Console.Write("Enter student Grade: ");
                grade = float.Parse(Console.ReadLine());
            }

            return new Student(id, name, grade, phone);
        }
    }
}
