using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> listIDs = new List<string>();
            List<string> fakeIDs = new List<string>();
            string input;
            while ((input=Console.ReadLine())!="End")
            {
                string[] personalData = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (personalData.Length==2)
                {
                    string id = personalData[1];
                    Robot currRobot = new Robot(personalData[0], id);
                    listIDs.Add(id);
                }
                else if (personalData.Length==3)
                {
                    string id = personalData[2];
                    int age = int.Parse(personalData[1]);
                    Citizen currPerson = new Citizen(personalData[0], age, id);
                    listIDs.Add(id);
                }
            }
            string fakeSeriaDigits = Console.ReadLine();
           
            foreach (var id in listIDs)
            {
        
                if (id.EndsWith(fakeSeriaDigits))
                {
                    fakeIDs.Add(id);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine,fakeIDs));

        }
    }
}
