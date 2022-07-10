
namespace Border_Control
{
    public class Citizen : IId
    {
        public Citizen(string name,int age,string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Id { get; private set; }
        private string Name { get;  set; }
        private int Age { get;  set; }
       
    }
}
