using System;
using System.Collections.Generic;

namespace Birthday_Celebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> birthdays = new List<string>();
            List<string> bornList = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] personalData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (personalData[0] == "Robot")
                {
                    string model = personalData[1];
                    string id = personalData[2];
                    Robot currRobot = new Robot(model, id);
                }
                else if (personalData[0] == "Citizen")
                {
                    string name = personalData[1];
                    int age = int.Parse(personalData[2]);
                    string id = personalData[3];
                    string birthday = personalData[4];
                    Citizen currPerson = new Citizen(name, age, id, birthday);
                    birthdays.Add(birthday);
                }
                else if (personalData[0] == "Pet")
                {
                    string name = personalData[1];
                    string birthday = personalData[2];
                    Pet currPet = new Pet(name, birthday);
                    birthdays.Add(birthday);
                }
            }
            string year = Console.ReadLine();
            foreach (var date in birthdays)
            {
                if (date.EndsWith(year))
                {
                    bornList.Add(date);
                }
            }
            if (bornList.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, bornList));
            }
           
        }
    }
}
