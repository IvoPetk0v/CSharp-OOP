
using _6.Food_Shortage.Interfacces;

namespace Birthday_Celebrations
{
    public class Citizen : IId,IBirthday,IBuyer
    {
        private int age;
        private string name;
        private int food;
        public Citizen(string name,int age,string id,string birthday)
        {
            this.name = name;
            this.age = age;
            this.Id = id;
            this.Birthday = birthday;
            this.Food = 0;
        }
        public string Name { get => this.name; }
        public string Id { get; private set; }     
        public string Birthday { get; private set; }
        public int Food { get => this.food; set => this.food = value; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
