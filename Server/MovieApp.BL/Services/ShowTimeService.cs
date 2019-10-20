using Microsoft.EntityFrameworkCore;
using MovieApp.BL.Interfaces;
using MovieApp.Data.EF;
using MovieApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.BL.Services
{
    public class ShowTimeService : IShowTimeService
    {
        private readonly MovieAppContext Context;

        public ShowTimeService(MovieAppContext context)
        {
            Context = context;
        }

        public Task<ShowTime> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DateTime>> GetDates()
        {
            return await Context.ShowTimes.Select(d => d.Date).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<string>> GetTimes(DateTime date, int movie_id)
        {
            return await Context.ShowTimes.Where(st => st.Date == date && st.MovieId == movie_id).Select(t => t.Time).ToListAsync();
        }
    }
}

