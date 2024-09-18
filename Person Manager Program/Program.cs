using Person_Manager_Program;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person.LoadList();
            int Select, id;
            do
            {
                string s = "Welcome To Person Manager System";
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
                Console.WriteLine();
                Console.WriteLine($"Main Menu\n" +
                    $"1-Add Person\n" +
                    $"2-View Person By ID\n" +
                    $"3-View Person By Name\n" +
                    $"4-Print All\n" +
                    $"5-Delete Person By ID\n" +
                    $"6-Delete All\n" +
                    $"7-Edit Person\n" +
                    $"8-Exit");
                Console.WriteLine();
                do
                {
                    Console.Write("Please Enter Number Of Process: ");
                } while (!int.TryParse(Console.ReadLine(), out Select));
                Console.Clear();
                switch (Select)
                {
                    case 1:
                        Person.AddPerson();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        do
                        {
                            Console.WriteLine("Please Enter Your ID : ");
                        } while (!int.TryParse(Console.ReadLine(), out id));
                        Person.ViewByID(id);
                        Console.WriteLine(Person.ViewByID(id));
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Please Enter Your Name : ");
                        string name = Console.ReadLine();
                        Person.ViewByName(name);
                        Console.WriteLine(Person.ViewByName(name));
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        Person.Print();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        do
                        {
                            Console.WriteLine("Please Enter The ID : ");
                        } while (!int.TryParse(Console.ReadLine(), out id));
                        Person.Remove(id);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        Person.DeleteAll();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 7:
                        do
                        {
                            Console.WriteLine("Please Enter Your ID : ");
                        } while (!int.TryParse(Console.ReadLine(), out id));
                        Person.EditPerson(id);
                        Console.Clear();
                        break;
                    case 8:
                        Person.Exit();
                        Thread.Sleep(5000);
                        break;
                }
            } while (Select != 8);
            Environment.Exit(0);
            
        }
    }
}