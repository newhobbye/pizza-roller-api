using RollerPizza.Model;

namespace RollerPizza.Data.Dao
{
    public interface IItemDao<T> 
       
    {
        IEnumerable<T> Search();
        T GetById(int id);
        //T GetByName(string name);

        public void Add(T item);
        
        
        public void Update(T item);

        public void Delete(T item);

    }
}
