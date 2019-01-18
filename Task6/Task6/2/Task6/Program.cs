namespace PersonDelegate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        private static Queue<Person> employees = new Queue<Person>();

        public static void Entrance(string name, int time)
        {
            Person person = new Person(name, time);
            person.ComingToWork(name, time, employees);
            Console.WriteLine();
        }

        public static void Exit(string name)
        {
            Person person = new Person(name);
            person.LeavingWork(name, employees);
            Console.WriteLine();
        }
  
        public static void Main(string[] args)
        {
            Entrance("Bill", 6);
            Entrance("Lola", 12);
            Entrance("John", 19);

            Exit("Bill");
            Exit("Lola");
            Exit("John");//todo pn консоль открылась и закрылсь :)
        }        
    }
}
