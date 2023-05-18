using PersonNP;


namespace PersonIteratorNP
{

    public interface IIterator
    {
        bool HasNext();
        Person Next();
    }
    public class PersonIterator : IIterator
    {
        private List<Person> _persons;
        private int _position = 0;

        public PersonIterator(List<Person> persons)
        {
            _persons = persons;
        }

        public bool HasNext()
        {
            return _position < _persons.Count;
        }

        public Person Next()
        {
            Person person = _persons[_position];
            _position++;
            return person;
        }
    }

}

