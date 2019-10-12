using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.BL.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);

    }
}
