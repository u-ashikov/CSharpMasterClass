namespace Equality
{
    public struct CatStruct
    {
        public CatStruct(string name, int age, string color)
        {
            this.Name = name;
            this.Age = age;
            this.Color = color;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Color { get; set; }
    }
}
