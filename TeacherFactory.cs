using PersonNP;
using TeacherNP;
using IPersonFactoryNP;

namespace TeacherFactoryNP
{
    public class TeacherFactory : IPersonFactory
    {
        public Person CreatePerson()
        {

            Console.Write("Enter Teacher ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter Teacher Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter teacher TeachingSubject: ");
            string teachingSubject = Console.ReadLine();

            return new Teacher(id, name, teachingSubject);
        }
    }
}
