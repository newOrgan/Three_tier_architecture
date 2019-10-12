using MovieApp.Data.EF;
using MovieApp.Data.Interfaces;
using MovieApp.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace MovieApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieAppContext context;

        private IMovieRepository _movies;
        public IMovieRepository Movies
        {
            get => _movies ?? (_movies = new MovieRepository(context));
        }

        private IActorRepository _actors;
        public IActorRepository Actors
        {
            get => _actors ?? (_actors = new ActorRepository(context));
        }

        private IGenreRepository _genres;
        public IGenreRepository Genres
        {
            get => _genres ?? (_genres = new GenreRepository(context));
        }

        public UnitOfWork(MovieAppContext context)
        {
            this.context = context;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~UnitOfWork()
        // {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
