namespace Birthday_Celebrations
{
    public class Pet : IBirthday
    {
        public Pet(string name, string birthday)
        {
            this.name = name;
            this.Birthday = birthday;
        }
        private string name;
        public string Birthday { get; private set; }
    }
}
