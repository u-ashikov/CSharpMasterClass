namespace ChangingHashCode
{
    public class Cat
    {
        public Cat(int id)
        {
            this.Id = id;
        }

        public int Id { get; }

        public string Name { get; set; }

        public override int GetHashCode()
        {
            // Wrong, if any of the properties, that are included in the calculation can be changed from outside or from logic inside the class.
            //return this.Id.GetHashCode() ^ this.Name.GetHashCode();

            // Use the read only property to generate the hash code, so no one can change it.
            return this.Id.GetHashCode();
        }
    }
}
