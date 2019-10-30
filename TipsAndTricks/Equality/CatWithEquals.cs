namespace Equality
{
    public class CatWithEquals : Cat
    {
        public CatWithEquals(string name, int age, string color)
            : base(name, age, color)
        {
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            return this.Equals((Cat)obj);
        }

        public override int GetHashCode()
        {
            return string.IsNullOrEmpty(this.Color) ? 0 : this.Color.GetHashCode();
        }

        protected bool Equals(Cat other)
        {
            return string.Equals(this.Color, other.Color);
        }
    }
}
