using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Person_Manager_Program
{
    internal class Person
    {
        #region Properties
        private static List<Person> NewList = new List<Person>();
        private static List<Person> Compare = new List<Person>();
        private static int countp;
        private int _id;
        private int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        private string _name;
        private string? Name
        {
            get
            {
                return _name;
            }
            set
            {
                for (int i = 0; i < NewList.Count; i++)
                {
                    if (NewList[i].Name == value)
                    {
                        Console.WriteLine($"Enter Any Name Else : ");
                        value = Console.ReadLine();
                        i = -1;
                    }
                }
                _name = value;
            }
        }
        private string? City { get; set; }
        private int Age { get; set; }
        private string? Phone { get; set; }
        #endregion

        #region Constructor
        public Person()
        {
            countp += 1;
        }
        private Person(int id, string name, string city, int age, string phone)
        {
            Id = id;
            Name = name;
            City = city;
            Age = age;
            Phone = phone;
        }

        #endregion

        #region Static Function 
        public static void AddPerson()
        {

            NewList.Add(new Person());
            Console.WriteLine("Enter your data ");
            Console.WriteLine("".PadRight(20, '='));
            NewList[countp - 1].Id = countp;
            Console.WriteLine($"Enter your Name : ");
            string _name = Console.ReadLine();
            NewList[countp - 1].Name = _name;
            Console.WriteLine($"Enter your City : ");
            NewList[countp - 1].City = Console.ReadLine();
            int _age;
            do
            {
                Console.WriteLine("Enter Your Age : ");
            } while (!int.TryParse(Console.ReadLine(), out _age));
            NewList[countp - 1].Age = _age;
            Console.WriteLine($"Enter your Phone : ");
            NewList[countp - 1].Phone = Console.ReadLine();
            Console.WriteLine($"Your Id is => {countp}");
        }
        public static string ViewByID(int id)
        {

            if (NewList is not null && NewList.Count >= id)
            {
                for (int i = 0; i < NewList.Count; i++)
                {
                    if (NewList[i].Id == id)
                    {
                        return $"ID : {NewList[i].Id},Name : {NewList[i].Name},City : {NewList[i].City}, Age : {NewList[i].Age},Phone {NewList[i].Phone}";
                    }

                }
            }

            return "ID not found";
        }
        public static string ViewByName(string name)
        {

            if (NewList is not null && name is not null)
            {
                for (int i = 0; i < NewList.Count; i++)
                {
                    if (NewList[i].Name == name)
                    {
                        return $"ID : {NewList[i].Id},Name : {NewList[i].Name},City : {NewList[i].City}, Age : {NewList[i].Age},Phone {NewList[i].Phone}";
                    }

                }
            }

            return "ID not found";
        }
        public static void Print()
        {
            if (NewList is not null && NewList.Count!=0)
            {
                foreach (Person p in NewList)
                {
                    Person.PrintPerson(p);
                }
            }
            else
                Console.WriteLine("There is No Persons ");

        }
        public static void DeleteAll()
        {
            if (NewList is not null)
            {
                NewList.Clear();
                countp = 0;
                string strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                string fileName = "Persons_Data.txt";
                string path = Path.Combine(strPath, fileName);
                File.WriteAllText(path, String.Empty);
                Console.WriteLine("Persons Has Been Deleted Successfully ");
            }
            else
                Console.WriteLine("There is No Persons To delete ");
        }
        public static void EditPerson(int id)
        {
            if (NewList is not null && NewList.Count >= id)
            {
                for (int i = 0; i < NewList.Count; i++)
                {
                    if (NewList[i].Id == id)
                    {
                        Person.PrintPerson(NewList[i]);
                        char Check;
                        do
                        {
                            Console.WriteLine("If You want to Modifiy Enter Y IF not Enter N");
                            Check = char.Parse(Console.ReadLine().ToLower());
                            if (Check == 'n')
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("for Change press\n" +
                                    "1- For Name \n2- for City \n3- for Age \n4- for Phone ");
                                int Num;
                                do
                                {
                                    Console.WriteLine($"Enter your Number : ");
                                } while (!int.TryParse(Console.ReadLine(), out Num));
                                switch (Num)
                                {
                                    case 1:
                                        Console.WriteLine($"Enter your Name : ");
                                        string _name = Console.ReadLine();
                                        NewList[id-1].Name = _name;
                                        break;
                                    case 2:
                                        Console.WriteLine($"Enter your City : ");
                                        NewList[id-1].City = Console.ReadLine();
                                        break;
                                    case 3:
                                        int _age;
                                        do
                                        {
                                            Console.WriteLine("Enter Your Age : ");
                                        } while (!int.TryParse(Console.ReadLine(), out _age));
                                        NewList[id - 1].Age = _age;
                                        break;
                                    case 4:
                                        Console.WriteLine($"Enter your Phone : ");
                                        NewList[id - 1].Phone = Console.ReadLine();
                                        break;

                                }

                            }
                            Console.WriteLine($"Your Data is => {NewList[i]}");
                        } while (Check == 'y');

                    }

                }
            }
            else
                Console.WriteLine("This Person is Not Found");
        }
        public static void Remove(int id)
        {
            if (NewList is not null && NewList.Count >= id)
            {

                for (int i = 0; i < NewList.Count; i++)
                {
                    if (NewList[i].Id == id)
                    {
                        NewList[i] = null;
                        Console.WriteLine("The Person Has Been Deleted Succesfully");
                        Rearrange(i);
                        break;
                    }
                }
                ///for (int i = NewList.Count - 1; i >= 0; i--)
                ///{
                ///    if (NewList[i] != null && NewList[i].GetType() == typeof(Person))
                ///    {
                ///        continue;
                ///    }
                ///    else
                ///    {
                ///        for (int j = NewList.Count - 1; j >= i; j--)
                ///        {
                ///            Person Temp;
                ///            if (NewList[j - 1] != null)
                ///            {
                ///                Temp = NewList[j - 1];
                ///                NewList[j - 1] = NewList[j];
                ///                NewList[j - 1].Id--;
                ///                if (NewList[j - 2] == NewList[i])
                ///                {
                ///                    NewList[j - 2] = Temp;
                ///                    NewList[j - 2].Id--;
                ///                    NewList.RemoveAt(NewList.Count - 1);
                ///                    countp--;
                ///                    break;
                ///                }
                ///                else
                ///                {
                ///                    NewList[j - 2] = Temp;
                ///                }
                ///            }
                ///            else
                ///            {
                ///                NewList[j - 1] = NewList[j];
                ///                NewList[j - 1].Id--;
                ///                NewList.RemoveAt(NewList.Count - 1);
                ///                countp--;
                ///                break;
                ///            }
                ///        }
                ///    }
                ///}
                /// NewList.RemoveAll(item => item == null || item.GetType() != typeof(Person));
                ///countp = NewList.Count;

            }
            else
                Console.WriteLine("The ID Is not Found");
        }
        public static void Exit()
        {
            string strPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = "Persons_Data.txt";
            string path = Path.Combine(strPath, fileName);
            string[] lines = NewList.ConvertAll(p => p.ToString()).ToArray();
            if (lines != null && lines.Length > 0)
            {
                if (Compare.Count == 0)
                {
                    File.WriteAllLines(path, lines);
                }
                else
                {
                    for (int i = 0; i < NewList.Count; i++)
                    {
                        if (NewList.Count == Compare.Count && NewList[i].Equals(Compare[i]))
                        {
                            continue;
                        }
                        else
                        {
                            File.WriteAllText(path, String.Empty);
                            File.WriteAllLines(path, lines);
                            break;
                        }
                    }
                }
            }
                Console.WriteLine($"Data written to {path}");
        }
        public static void LoadList()
        {
            string file = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string fileName = "Persons_Data.txt";
            string path = Path.Combine(file, fileName);
            if (File.Exists(path))
            {

                string[] lines = File.ReadAllLines(path);
                
                foreach (string ln in lines)
                {
                    string[] parts = ln.Split(new[] { "," }, StringSplitOptions.None);

                    Compare.Add(new Person());
                    Compare[countp - 1].Id = int.Parse(parts[0]);
                    Compare[countp - 1].Name = parts[1];
                    Compare[countp - 1].City = parts[2];
                    Compare[countp - 1].Age = int.Parse(parts[3]);
                    Compare[countp - 1].Phone = parts[4];
                   
                }
                countp = 0;
                NewList.Clear();
                foreach (var person in Compare)
                {
                    Person newPerson = new Person
                    {
                        Id = person.Id,
                        Name = person.Name,
                        City = person.City,
                        Age = person.Age,
                        Phone = person.Phone
                    };
                    NewList.Add(newPerson);
                }
            }
        }
        private static void Rearrange(int index)
        {
            for (int i = index + 1; i < NewList.Count; i++)
            {
                NewList[i - 1] = NewList[i];
                NewList[i - 1].Id--;
            }
            NewList[NewList.Count - 1] = default;
            int newSize = NewList.Count - 1;
            NewList.RemoveAt(NewList.Count - 1);
            List<Person> newArray = new List<Person>(newSize);
            newArray.AddRange(NewList);
            NewList = newArray != null ? newArray : new List<Person>();
            countp--;
        }
        private static void PrintPerson(Person p)
        {
            Console.WriteLine($"ID : {p.Id},Name : {p.Name},City : {p.City}, Age : {p.Age},Phone {p.Phone}");
        }
        #endregion

        #region OverRide Function
        public override string ToString()
        {
            return $"{Id},{Name},{City},{Age},{Phone}"; 
        }
        public override bool Equals(object? obj)
        {
            if(obj is Person p1)
            {
                return this.Id == p1.Id && this.Name == p1.Name
                           && this.City == p1.City && this.Age == p1.Age && this.Phone == p1.Phone;
            }
            else
                return false;
           
        }
        #endregion

    }
}