using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.BL.DTOs;
using MovieApp.BL.Interfaces;
using MovieApp.Data.EF;
using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.BL.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieAppContext Context;

        public MovieService(MovieAppContext context) 
        { 
            Context = context;
        }

        public async Task<Movie> GetById(int id)
        {
            return await Context.Movies.Include(m=>m.Genre).SingleOrDefaultAsync(m=>m.Id==id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByDate(DateTime dateTime)
        {
            var movieIds = Context.ShowTimes.Where(s => s.Date == dateTime).Select(m => m.MovieId).Distinct().ToList();
            IQueryable<Movie> movies = Context.Movies;
            foreach (var id in movieIds)
            {
                movies = movies.Where(m => m.Id == id);
            }
            return await movies.ToListAsync();
        }
    }
}
