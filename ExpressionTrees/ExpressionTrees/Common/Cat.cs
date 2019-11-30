namespace Common
{
    public class Cat
    {
        public Cat() { }

        public Cat(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.SomeImportantProp = "Some Very Important Value";
            this.ImportantField = 100;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public Owner Owner { get; set; }

        private string SomeImportantProp { get; set; }

        private int ImportantField;

        public string SayMeow(int num) => $"Meow!{num}";

        private string Introduce() => $"Hi my name is {this.Name}, I am {this.Age} years old.";
    }
}
