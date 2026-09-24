using System;

namespace Lab2
{
    public class Student : Person
    {
        private string name;
        private int Age;
        private string nativePlace;
        private string id;

        public Student() { }

        public Student(string name, int age, string nativePlace, string id)
        {
            this.name = name;
            this.Age = age;
            this.nativePlace = nativePlace;
            this.id = id;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int age
        {
            get { return Age; }
            set { Age = value; }
        }

        public string NativePlace
        {
            get { return nativePlace; }
            set { nativePlace = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public void input()
        {
            Console.Write("Nhap ID: ");
            id = Console.ReadLine();
            Console.Write("Nhap ten: ");
            name = Console.ReadLine();
            Console.Write("Nhap tuoi: ");
            Age = int.Parse(Console.ReadLine());
            Console.Write("Nhap que quan (nativePlace): ");
            nativePlace = Console.ReadLine();
        }

        public void display()
        {
            Console.WriteLine($"ID: {id} | Ten: {name} | Tuoi: {Age} | Que quan: {nativePlace}");
        }
    }
}
