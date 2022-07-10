namespace Border_Control
{
    public class Robot : IId
    {
        public Robot(string model,string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Id { get; private set; }
        private string Model { get;  set; }
     
    }
}
