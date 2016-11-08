using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_for_Anugular_Restaurant.DataAccessLayer.Repositories
{
    public interface IRepository<T>  
    {
        List<T> Get();

        T Get(int id);

        T Insert(T obj);

        T Update(T obj);

        int Delete(T obj);
    }
}
