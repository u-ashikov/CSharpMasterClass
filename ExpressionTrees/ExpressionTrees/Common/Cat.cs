namespace Common
{
    public class Cat
    {
        public Cat() { }

        public Cat(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public Owner Owner { get; set; }

        public string SayMeow(int num) => $"Meow!{num}";
    }
}
