using System;

namespace SystemTypeMethods
{
    public class Cat : ICat
    {
        private int age;

        public Cat(string name, int age, string color)
        {
            this.Name = name;
            this.Age = age;
            this.Color = color;
        }

        protected Cat()
        {

        }

        public string Name { get; private set; }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value < default(int))
                {
                    throw new ArgumentException("The value of the age cannot be negative.");
                }

                this.age = value;
            }
        }

        public string Color { get; private set; }

        protected internal string MyProtectedInternalProperty { get; set; }

        public string IntroduceYourself() => $"Hi, my name is {this.Name} and I am {this.Age} years old, with {this.Color} color of the fur.";

        [Obsolete]
        public static void ObsoleteMethod()
        {
        }

        private static void PrivateStaticMethod()
        {
        }
    }
}
