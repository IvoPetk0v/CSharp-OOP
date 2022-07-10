using _6.Food_Shortage.Interfacces;

namespace _6.Food_Shortage.Models
{
    public class Rebel:IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;

        public Rebel(string name,int age,string group)
        {
            this.name = name;
            this.age = age;
            this.group = group;
            this.Food = 0;
        }
        public int Food { get => this.food; set => this.food = value; }
        public string Name { get => this.name; }
        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
