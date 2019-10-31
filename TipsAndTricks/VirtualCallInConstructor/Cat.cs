using System;
using System.Text;

namespace VirtualCallInConstructor
{
    public class Cat : Animal
    {
        private readonly StringBuilder stringBuilder;

        public Cat(string name, int age) 
            : base(name, age)
        {
            this.stringBuilder = new StringBuilder();
        }

        public override void IntroduceYourself()
        {
            this.stringBuilder.AppendLine($"Hello, my name is {this.Name}. I am {this.Age} years old.");

            Console.WriteLine(this.stringBuilder.ToString());
        }
    }
}
