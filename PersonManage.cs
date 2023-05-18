using PersonNP;

using PersonIteratorNP;

using StudentNP;

using TeacherNP;

namespace PersonManageNP
{

    public interface IPersonManage
    {
        IIterator CreateIterator();
    }

    public class PersonManage : IPersonManage
    {
        private List<Person> _persons = new List<Person>();

        public void AddPerson(Person Person)
        {
            _persons.Add(Person);
        }

        public IIterator CreateIterator()
        {
            return new PersonIterator(_persons);
        }

        public void DeletepersonById(string id)
        {
            // Browse through the person list
            for (int i = 0; i < _persons.Count; i++)
            {
                if (_persons[i].Id == id)
                {
                    _persons.RemoveAt(i);
                    Console.WriteLine("Removed person with ID = {0}", id);
                    return;
                }
            }
            Console.WriteLine("No person found with ID = {0}", id);
        }

        // person update function
        public void Update(string id)
        {
            // Find the person with the given id
            Person personToUpdate = null;

            foreach (Person person in _persons)
            {
                if (person.Id == id)
                {
                    personToUpdate = person;
                    break;
                }
            }

            if (personToUpdate == null)
            {
                Console.WriteLine($"Can't find Id = {id}");
                return;
            }

            // Update the person based on its type
            if (personToUpdate is Teacher)
            {
                Teacher teacherToUpdate = (Teacher)personToUpdate;

                try
                {
                    // Prompt the user to enter the new Teacher information
                    Console.Write("Enter Teacher ID: ");
                    string idT = Console.ReadLine();

                    Console.Write("Enter Teacher Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter teacher TeachingSubject: ");
                    string teachingSubject = Console.ReadLine();
                    // Update the Teacher object with the new information
                    teacherToUpdate.Id = idT;
                    teacherToUpdate.Name = name;
                    teacherToUpdate.TeachingSubject = teachingSubject;


                    Console.WriteLine("Teacher updated successfully.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nYou entered the wrong Teacher's new information, please re-enter it!");
                }

            }
            else if (personToUpdate is Student)
            {
                // Cast the person to a Toy object
                Student studentToUpdate = (Student)personToUpdate;

                try
                {
                    Console.Write("Enter student ID: ");
                    string idS = Console.ReadLine();

                    Console.Write("Enter student Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter student Grade: ");
                    float grade = float.Parse(Console.ReadLine());

                    Console.Write("Enter student Phone: ");
                    string phone = Console.ReadLine();

                    // Update the toy object with the new information
                    studentToUpdate.Id = idS;
                    studentToUpdate.Name = name;
                    studentToUpdate.Grade = grade;
                    studentToUpdate.Phone = phone;

                    Console.WriteLine("Student updated successfully!!!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nYou entered the wrong Student's new information, please re-enter it!");
                }

            }

        }

    }

}
