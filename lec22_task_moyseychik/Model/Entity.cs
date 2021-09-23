namespace Model
{
    public class Entity<T>
    {
        public T Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Entity<T> entity)
            {
                return Id.Equals(entity.Id);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
