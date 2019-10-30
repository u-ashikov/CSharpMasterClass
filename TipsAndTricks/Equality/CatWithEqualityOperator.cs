namespace Equality
{
    public class CatWithEqualityOperator : Cat
    {
        public CatWithEqualityOperator(string name, int age, string color)
            : base(name, age, color)
        {
        }

        public override bool Equals(object obj)
        {
            return string.Equals(this.Color, ((CatWithEqualityOperator)obj).Color);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(CatWithEqualityOperator x, CatWithEqualityOperator y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return true;
            }

            if ((object)x == null || (object)y == null)
            {
                return false;
            }

            return x.Equals(y);
        }

        public static bool operator !=(CatWithEqualityOperator x, CatWithEqualityOperator y)
        {
            return !(x == y);
        }
    }
}
