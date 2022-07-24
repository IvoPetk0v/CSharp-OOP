namespace ValidationAttributes.Models
{
    using Attributes;

    class Person
    {
        private const int AgeMinValue = 12;
        private const int AgeMaxValue = 90;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        [MyRequired]
        public string Name { get; set; }
        [MyRange(AgeMinValue, AgeMaxValue)]
        public int Age { get; set; }
    }
}
