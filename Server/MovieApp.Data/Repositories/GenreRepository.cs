using Microsoft.EntityFrameworkCore;
using MovieApp.Data.EF;
using MovieApp.Data.Entities;
using MovieApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieAppContext context) : base(context)
        {
        }
    }
}
