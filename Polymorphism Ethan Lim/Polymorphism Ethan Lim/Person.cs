using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_Ethan_Lim
{
    public class Person
    {
        string first;
        string last;
        string date_of_birth;
        string email;
        public Person(string f,string l,string dob, string e)
        {
            first = f;
            last = l;
            date_of_birth = dob;
            email = e;
        }
       
        public virtual void Age()
        {
            DateTime time =  DateTime.Now;
            string stime = time.Year.ToString();
            Console.WriteLine(stime);
            int itime = int.Parse(stime);
            int age = itime - dobconvert();
            Console.WriteLine($"Users age is {age}");
            if (age < 18) 
                Console.WriteLine("Too young");
            
        }
        internal protected void Valid()
        {
            bool valid = true;
            try
            {
                List<int> test = ((from i in date_of_birth.Split('/') select int.Parse(i))).ToList();
            }
            catch(FormatException e)
            {
                Console.WriteLine("The date you entered is not just numbers");
                valid = false;
            }
            finally
            {
                if (!valid)
                    throw new FormatException("Date you entered contains things other than numbers");
                

            }
            List<int> date = ((from i in date_of_birth.Split('/') select int.Parse(i))).ToList();
            if (date.Count() != 3)
                throw new Exception("you have entered too many/little");
            else if (date[0] < 0 || date[0] > 31)
                throw new Exception("Day is invalid");
            else if (date[1] < 0 || date[1] > 12)
                throw new Exception("Month is invalid");
            else if (date[2] < 0)
                throw new Exception("Year is invalid");
            else
                Console.WriteLine("Date of birth is valid");
        }
        public virtual string Screen_Name()
        {
            List<string> date = date_of_birth.Split('/').ToList(); //3 elements, 2 max val
            Random ran = new Random();
            string join = string.Empty;
            List<string> result = new List<string>();
            
            for (int i = 0; i < 3; ++i)
            {
                join = join+ date[ran.Next(1, 2)];
            }
            string name = first+join;
            Console.WriteLine($"Screen name is {name}");
            return name;

            
        }
        public virtual int dobconvert()
        {
            //Valid();
            List<string> full = date_of_birth.Split('/').ToList();
            return int.Parse(full[2]);
        }
        public virtual string chinese_sign()
        {
            List<string> signs = new List<string> { "Rooster", "Dog", "Pig" ,"Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep", "Monkey" };
            int year = find("year");
            int result = year%12;
            Console.WriteLine($"result is {result}");
            Console.WriteLine($"Chinese sign is {signs[result - 1]}");
            return signs[result - 1];
        }
        public virtual bool birthday()
        {
            DateTime current = DateTime.Now;
            int month_now = current.Month;
            int day_now = current.Day;
            if (find("month") == month_now && find("day") == day_now)
            {
                Console.WriteLine("HAPPY BIRTHDAY");
                return true;
            }
            else
                return false;
        }
        public int find(string a)
        {
            List<int> dates = (from x in date_of_birth.Split('/') select int.Parse(x)).ToList();
            if (a == "year")
                return dates[2];
            else if (a == "month")
                return dates[1];
            else if (a == "day")
                return dates[0];
            else
                return 404;
        }

    }
    class Student : Person
    {
        string year_group;
        public Student(string f, string l, string dob, string e, string y) : base(f,l,dob,e)
        {
            year_group = y;
        }
        
      
        public override string Screen_Name()
        {
            return base.Screen_Name()+$" year group is: {year_group}";
        }
    }
    class Teacher : Person
    {
        string subject;
        public Teacher(string f, string l, string dob, string e, string s) : base(f,l,dob,e)
        {
            subject = s;
        }
        public override string Screen_Name()
        {
            return base.Screen_Name()+ $"Member of staff {subject}";
        }
       
    }
}
