using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Delegates_Events.DelegateDemo;

namespace Delegates_Events
{
    internal class DelegateDemo
    {
        // we will declare delegate in the namespace
        public delegate int MyDelegate(int x, int y);// variable name can be same or diff

        public delegate string Mydelegate2(string name);
        public class Calculator
        {
            public int Add(int a, int b)
            {
                return a + b;
            }
            public int Sub(int a, int b)
            {
                return a - b;
            }
            public int Multiply(int a, int b)
            {
                return a * b;
            }
        }

        public class User
        {
            public string AcceptName(string name)
            {
                return name.ToUpper();
            }
        }


        //static void Main(string[] args)
        //{
        //    Calculator c = new Calculator();
        //    // delegate object
        //    MyDelegate obj = new MyDelegate(c.Multiply);// added method ref
        //                                                //int result=obj.Invoke(20, 30);
        //                                                //Console.WriteLine(result);
        //    obj += new MyDelegate(c.Sub); // += add in to the invocation list
        //    obj += new MyDelegate(c.Add);

        //    obj -= new MyDelegate(c.Sub); // -= will remove method from invocation list

        //    // Delegate will create the invocationList 
        //    // invocationList hold methods refer in the same sequence that we have added
        //    // basic need of multicast delegate is --> to invoke methods in a sequence.

        //    Delegate[] list = obj.GetInvocationList();
        //    foreach (Delegate item in list)
        //    {
        //        Console.WriteLine(item.Method);
        //        Console.WriteLine(item.DynamicInvoke(45, 33));
        //    }
        //    //User u = new User();
        //    //Mydelegate2 obj2 = new Mydelegate2(u.AcceptName);
        //    //Console.WriteLine(obj2.Invoke("ThinkQuotient"));
        //    //c.Add(20, 30);
        //}

    }
}

