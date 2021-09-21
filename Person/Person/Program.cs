using System;

namespace Person
{
    class Person
    {
        public string name = "Денис";
        public int age = 18;

        public void GetInfo()
        {
            System.Console.WriteLine($"name: {name}, age: {age}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World");
            Person Denis = new Person();
            Denis.GetInfo();
            System.Console.ReadKey();


            Denis.name = "Денис";
            Denis.age = 18;
            Denis.GetInfo();
            System.Console.ReadKey();

        }


    }


}
