using System;

namespace InstancesAndInvocations
{
    public class Cat : ICat
    {
        private int age;

        public Cat(string name, int age)
        {
            this.Name = name;
            this.Age = age;
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

        public string Eat(string food) => $"Mmmm so yummy, {food}.";

        public override string ToString() => $"My name is {this.Name}, {this.Age} years old.";
    }
}
