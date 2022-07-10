using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    if (input == "Cat")
                    {
                        string[] animalArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        string name = animalArgs[0];
                        string gender = animalArgs[2];
                        int age = int.Parse(animalArgs[1]);
                        Cat newCat = new Cat(name, age, gender);
                        Console.WriteLine(newCat);
                        Console.WriteLine(newCat.ProduceSound());
                    }
                    else if (input == "Dog")
                    {
                        string[] animalArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        string name = animalArgs[0];
                        string gender = animalArgs[2];
                        int age = int.Parse(animalArgs[1]);
                        Dog newDog = new Dog(name, age, gender);
                        Console.WriteLine(newDog);
                        Console.WriteLine(newDog.ProduceSound());
                    }
                    else if (input == "Frog")
                    {
                        string[] animalArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        string name = animalArgs[0];
                        string gender = animalArgs[2];
                        int age = int.Parse(animalArgs[1]);
                        Frog newFrog = new Frog(name, age, gender);
                        Console.WriteLine(newFrog);
                        Console.WriteLine(newFrog.ProduceSound());
                    }
                    else if (input == "Kitten")
                    {
                        string[] animalArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        string name = animalArgs[0];
                        int age = int.Parse(animalArgs[1]);
                        Kitten newKitten = new Kitten(name, age);
                        Console.WriteLine(newKitten);
                        Console.WriteLine(newKitten.ProduceSound());
                    }
                    else if (input == "Tomcat")
                    {
                        string[] animalArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        string name = animalArgs[0];
                        int age = int.Parse(animalArgs[1]);
                        Tomcat newTomcat = new Tomcat(name, age);
                        Console.WriteLine(newTomcat);
                        Console.WriteLine(newTomcat.ProduceSound());
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }
            }
        }
    }
}
