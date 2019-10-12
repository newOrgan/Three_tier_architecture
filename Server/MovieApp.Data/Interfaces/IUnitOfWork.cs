using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }
        IActorRepository Actors { get; }
        IGenreRepository Genres { get; }
        int Save();
    }
}
