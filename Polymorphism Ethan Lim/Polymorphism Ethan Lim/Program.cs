using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_Ethan_Lim
{
    class Program
    {
        static void Main(string[] args)
        { //when putting function in base class, mark bass class function as virtual, screen name will be virtual, want it to be fromteacher method or student not person
            //use virtual to run method inside derived class, use it for lists. derived classes should be virtual.
            Person person = new Person("E", "D", "11/03/1991", "S");
            person.chinese_sign();
            person.birthday();
            Person person1 = new Person("E", "D", "w3/03/19e1", "S");
            //person1.Valid(); works
            person.Age();
            Console.WriteLine("Onto students");
            Student student = new Student("E", "D", "11/03/1991", "S","5th");
            //Console.WriteLine(student.date_of_birth);
           
            student.Screen_Name();
            Console.ReadKey();
        }
    }
}
