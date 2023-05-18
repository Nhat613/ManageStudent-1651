using PersonNP;
using PersonManageNP;

using IPersonFactoryNP;
using PersonIteratorNP;
using StudentNP;
using StudentFactoryNP;

using TeacherNP;
using TeacherFactoryNP;

class Menu
{
    static void Main(string[] args)
    {
        PersonManage manager = new PersonManage();

        while (true)
        {
            Console.WriteLine("\n -- Classroom Management --");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Show all teacher and student");
            Console.WriteLine("2. Add new teacher or student");
            Console.WriteLine("3. Edit teacher or student");
            Console.WriteLine("4. Delete teacher or student");
           
            Console.Write("\nEnter option (0 -> 4): ");

            int option = 0;

            try
            {
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:

                        IIterator iterator = manager.CreateIterator();

                        if (iterator.HasNext())
                        {
                            Console.WriteLine("\nLIST STUDENT: ");
                            Console.WriteLine(
                                "{0,-10} {1,-20} {2,-30} {3,-30} {4,-20}", "    ", "ID", "Name", "Grade / Teaching Subject ", "Phone");
                            Console.WriteLine("=================================================================================================");

                            while (iterator.HasNext())
                            {
                                Person person = iterator.Next();

                                Console.WriteLine("{0,-10} {1,-20} {2,-30} {3,-30} {4,-20}",
                                    person is Teacher ? "TEACHER:" : "STUDENT:", person.Id, person.Name,
                                    person is Teacher ? ((Teacher)person).TeachingSubject : ((Student)person).Grade,
                                    person is Teacher ? "       " : ((Student)person).Phone);

                            }
                        }
                        else
                        {
                            Console.WriteLine("\nList is empty!");
                        }

                        break;
                    case 2:
                        {
                            Console.WriteLine("Please enter infomation:");
                            Console.Write("Enter choice (1:Teacher - OR - 2:Student): ");
                            int choice = int.Parse(Console.ReadLine());

                            if (choice == 2)
                            {
                                IPersonFactory studentFactory = new StudentFactory();
                                Person student = studentFactory.CreatePerson();
                                manager.AddPerson(student);
                                Console.WriteLine("\nAdded student to the list!");
                            }
                            else
                            {
                                IPersonFactory teacherFactory = new TeacherFactory();
                                Person teacher = teacherFactory.CreatePerson();
                                manager.AddPerson(teacher);
                                Console.WriteLine("\nAdded teacher to the list!");
                            }

                        }

                        break;

                    case 3:
                        Console.WriteLine("\nPLEASE ENTER NEW INFOMATION!");
                        Console.Write("Enter person ID to Update: ");
                        string idUpdate = Console.ReadLine();
                        manager.Update(idUpdate);
                        break;
                    case 4:
                        Console.Write("Enter person ID to Delete: ");
                        string idDelete = Console.ReadLine();
                        manager.DeletepersonById(idDelete);
                        break;
                    case 0:
                        Console.WriteLine("Exiting program...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nInvalid option!");
                        break;
                }


            }
            catch (FormatException)
            {
                Console.WriteLine("\nYou entered the wrong option of NUMBER format, please re-enter!");
            }  

        }
    }
}


