using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    delegate int FirstDelegate(string str);
    delegate void SecondDelegate(string str, int a);

    delegate void MyEventHandler();
    class Calendar
    {
        public int yearDay = 0;

        public void AddDay()
        {

            yearDay++;

            if (yearDay == 61)
                Spring?.Invoke();
           
            if (yearDay == 365)
                yearDay = 0;

        }

        public event MyEventHandler Spring = null;

    }
    class Program
    {
        static Calendar c1;
        static void M()
        {
            Console.WriteLine("Cats!!!");
            //c1.Spring -= M;


        }
        static void Main(string[] args)
        {

            c1 = new Calendar();
            c1.Spring += M;

            c1.AddDay();
            c1.AddDay();

            //c1.Spring?.Invoke();

            for (int i = 0; i< 1000; i++)
                c1.AddDay();






            FirstDelegate first; //= new FirstDelegate(Class1.GetLength);
            first = Class1.GetLength;
            first += Class1.GetLength;
            first -= Class1.GetLength;
            first += Class1.DoubleLength;

            Func<string, int> second = Class1.GetLength;
            second += Class1.GetLength;
            second -= Class1.GetLength;
            second += Class1.DoubleLength;

            SecondDelegate third = Class1.Length5;

            Class1 o = new Class1();
            first += o.Length4;

            //Class1.GetLength("Mama mila ramu");
            int a;
            if (first != null)
                a = first("Mama mila ramu");
        }

        
    }
}

class Class1
{
    public static int GetLength(string s)
    {
        return s.Length;
    }

    public static void Length5(string s, int r)
    {
        
    }

    public static int DoubleLength(string t)
    {
        return 2 * t.Length;
    }

    public int Length4(string t)
    {
        return 4 * t.Length;
    }
}
