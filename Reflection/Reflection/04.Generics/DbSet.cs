using System.Collections.Generic;

namespace Generics
{
    public class DbSet<TEntity> 
        where TEntity : class
    {
        private readonly ICollection<TEntity> entities;

        public DbSet()
        {
            this.entities = new List<TEntity>();
        }

        public int Count => this.entities.Count;

        public void Add(TEntity entity) => this.entities.Add(entity);
    }
}
