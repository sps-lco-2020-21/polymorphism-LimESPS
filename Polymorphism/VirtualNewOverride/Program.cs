using System;
using System.Collections.Generic;


namespace VirtualNewOverride
{
    class Program
    {
        // based on the example here: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords 
        static void Main(string[] args)
        {
            #region 1
            // Step 1 create the instances of the objects 
            BaseClass bc = new BaseClass();
            DerivedClass dc = new DerivedClass();
            //protected accessible within any class that is derived form it
            // this is the one that's going to mess with your heads. 
            BaseClass bcdc = new DerivedClass();
            //internal, accessible within an interface

            Console.WriteLine("bc 1/2");
            bc.Method1();
            bc.Method2();
            bc.EthanT();
            Console.WriteLine("\ndc 1/2");
            dc.Method1();
            dc.Method2();

            Console.WriteLine("\nbcdc 1/2");
            bcdc.Method1();
            #endregion

            #region 3 predict the output 
            //// #3            
            bcdc.Method2();

            #endregion

            #region 7 lists

            // step 7 - putting them in a list 

            // List<BaseClass> lb = new List<BaseClass> { bc, dc, bcdc };
            // List<DerivedClass> ld = new List<DerivedClass> {  bc, dc, bcdc};

            #endregion


            #region 8 
            // step 8 method 3 - will work with ld, but not with lb
            #endregion

            #region 9 abstract
            // step 9 note we've not even talked about abstract ... 
            #endregion

            Console.ReadKey();
        }
        public class test
        {
            public void EthanT()
            {
                Console.WriteLine("Works");
            }
        }
        /// <summary>
        /// A base class which implements 2 functions 
        /// </summary>
        class BaseClass : test //base class is derived from test
        {
            #region 5 virtual 
            // step 5 - what effect does the virtual keyword have? 
            // the importance of new vs override in the derived class. 
            public virtual void Method1() 
            {
                Console.WriteLine("Base - Method1");
            }
            #endregion

            #region 2 method 2 - a straight method (not virtual - see later, #5) 
            // step 2 - a straight function - base.method2 is always coming here 
            public void Method2()
            {
                Console.WriteLine("Base - Method2");
            }
            #endregion

        }

        /// <summary>
        /// a derived class, which inherits from the base class 
        /// </summary>
        class DerivedClass : BaseClass
        {
            #region 6 override 
            // // #6
            public override void Method1()
            {
                Console.WriteLine("Derived - Method1");
            }
            #endregion

            #region 4 new 
            // #4 new 
            #endregion
            public new void Method2() 
            {                
                Console.WriteLine("Derived - Method2");
            }

            public void Method3()
            {
                Console.WriteLine("Derived - Method3");

            }
        }
    }
}
