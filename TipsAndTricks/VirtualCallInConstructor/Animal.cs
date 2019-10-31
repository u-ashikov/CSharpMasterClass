namespace VirtualCallInConstructor
{
    public abstract class Animal
    {
        protected Animal(string name, int age)
        {
            this.Name = name;
            this.Age = age;

            this.IntroduceYourself();
        }

        public string Name { get; }

        public int Age { get; }

        public abstract void IntroduceYourself();
    }
}
