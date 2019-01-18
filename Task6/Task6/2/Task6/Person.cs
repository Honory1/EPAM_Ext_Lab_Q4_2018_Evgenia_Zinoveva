namespace PersonDelegate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Person
    {
        public Person(string name)
        {
            this.PersonName = name;
        }

        public Person(string name, int time)
        {
            this.PersonName = name;
            this.TimeOfArrival = time;
        }

        public delegate void OfficeEntrance(string name, int time, Queue<Person> employees);

        public delegate void Message(string name, Queue<Person> employees);

        public event Message Come;

        public event Message Leave;        

        public int TimeOfArrival { get; set; }

        public string PersonName { get; set; }

        public void Coming(string name, Queue<Person> employees)
        {
            if (this.Come != null)
            {
                Console.WriteLine($"[{name} came to work]");
            }
        }

        public void Leaving(string name, Queue<Person> employees)
        {
            if (this.Leave != null)
            {
                Person personAway = employees.Dequeue();
                Console.WriteLine($"[{name} left work]");
            }
        }

        public void ComingToWork(string name, int time, Queue<Person> employees)
        {
            Person person = new Person(name);
            OfficeEntrance comingPerson = new OfficeEntrance(person.Greet);
            person.Come += this.Coming;
            person.Coming(name, employees);
            person.Greet(name, time, employees);
            employees.Enqueue(person);
        }

        public void LeavingWork(string name, Queue<Person> employees)
        {
            Person person = new Person(name);
            Message leavingPerson = new Message(person.Farewell);
            person.Leave += this.Leaving;
            person.Leaving(name, employees);
            person.Farewell(name, employees);
        }

        public void Greet(string anotherPerson, int time, Queue<Person> employees)
        {
            if (time < 12)//todo pn хардкод
            {
                foreach (Person person in employees)
                {
                    Console.WriteLine("'Good morning, {0}!', - {1} said", anotherPerson, person.PersonName);
                }
            }
            else if (time >= 12 && time < 17)
            {
                foreach (Person person in employees)
                {
                    Console.WriteLine("'Good day, {0}!', - {1} said", anotherPerson, person.PersonName);
                }
            }
            else if (time >= 17)
            {
                foreach (Person person in employees)
                {
                    Console.WriteLine("'Good evening, {0}!', - {1} said", anotherPerson, person.PersonName);
                }
            }
        }

        public void Farewell(string anotherPerson, Queue<Person> employees)
        {
            foreach (Person person in employees)
            {
                Console.WriteLine("'Goodbay, {0}!', - {1} said.", anotherPerson, person.PersonName);
            }
        }
    }
}
