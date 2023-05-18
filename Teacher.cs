using PersonNP;
using System.Xml.Linq;

namespace TeacherNP
{
    public class Teacher : Person
    {
        public string TeachingSubject { get; set; }

        public Teacher(string id, string name, string teachingSubject)
        {
            Id = id;
            Name = name;
            TeachingSubject = teachingSubject;
        }

    }

}

