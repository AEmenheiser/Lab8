using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {   
            Dictionary<int, Student> studentInfo = new Dictionary<int, Student>();

            
            studentInfo.Add(1, new Student("Hilary", "Paris", "Tuna"));
            studentInfo.Add(2, new Student("Frank", "Detroit", "Salad"));
            studentInfo.Add(3, new Student("Billy", "Buenos Aires", "French Fries"));
            studentInfo.Add(4, new Student("CHarlie", "Tokyo", "Sushi"));
            studentInfo.Add(5, new Student("Chris", "Mumbai", "Popcorn"));
            studentInfo.Add(6, new Student("Justin", "Jarkata", "Pizza"));
            studentInfo.Add(7, new Student("Eleni", "Detroit", "Pad Thai"));
            studentInfo.Add(8, new Student("Nick", "Chicago", "Indian Food"));
            studentInfo.Add(9, new Student("Henry", "LA", "Fried Rice"));
            studentInfo.Add(10, new Student("Tara", "Dallas", "Tacos"));

            
            int userInput;
            Console.WriteLine("Welcome to our C# class.");
        Start:
            Console.WriteLine("Which student would like to learn more about? (enter a number 1 - 10): ");
            do
            {
                try
                {
                    userInput = int.Parse(Console.ReadLine());
                    if ((userInput > 10) || (userInput < 1))
                    {
                        Console.WriteLine("There's no student with that number. Please enter 1 to 10: ");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.Write("You entered the wrong information. Please a number from 1 to 10: ");
                    continue;
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong. Please try again.");
                }
            } while (true);

            Student student;
            bool success = studentInfo.TryGetValue(userInput, out student);
           
            if (success)
            {
                Console.Write($"Student {userInput} is {student.Name}. What would you like to know about {student.Name}? (enter favorite food or city of residence): ");
            }
            else
            {
                Console.WriteLine("That student doesn't exist.");
            }


            string nextQuestion = Console.ReadLine();
            while ((nextQuestion != "favorite food") || (nextQuestion != "city of residence"))
            {
                bool Either = userQuestion(nextQuestion);
                if (Either)
                {
                    if (nextQuestion == "favorite food")
                    {
                        Console.WriteLine($"{student.Name} loves to eat {student.FavoriteFood}");
                    }
                    else if (nextQuestion == "city of residence")
                    {
                        Console.WriteLine($"{student.Name} lives in {student.FavoriteFood}.");
                    }

                    break;
                }
                else
                {
                    Console.Write("We don't have that data. Please enter city of residence or favorite food: ");
                    nextQuestion = Console.ReadLine();
                }
            }
            Console.WriteLine("Would you like information about another student? (y/n): ");
            string userResponse = Console.ReadLine();
            if (userResponse == "y")
            {
                goto Start;
            }
        }

        public static bool userQuestion(string text)
        {
            if ((text == "favorite food") || (text == "city of residence"))
                return true;

            return false;
        }
        class Student
        {
            private string name;
            private string City;
            private string favoriteFood;

            public Student(string name, string City, string favoriteFood)
            {
                this.name = name;
                this.City = City;
                this.favoriteFood = favoriteFood;
            }

            public string Name
            {
                get { return name; }
            }

            public string FavoriteTeam
            {
                get { return this.City; }
            }

            public string FavoriteFood
            {
                get { return this.favoriteFood; }
            }
        }
    }
}


  