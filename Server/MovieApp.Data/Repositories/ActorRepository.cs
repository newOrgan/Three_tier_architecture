﻿using Microsoft.EntityFrameworkCore;
using MovieApp.Data.EF;
using MovieApp.Data.Entities;
using MovieApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Data.Repositories
{
    public class ActorRepository : Repository<Actor>, IActorRepository
    {
        public ActorRepository(MovieAppContext context) : base (context)
        { }

        public MovieAppContext Context
        {
            get => Context as MovieAppContext;
        }

        public Actor GetActorWithMovies(int id) =>
            Context.Actors.Include(a => a.Movies).SingleOrDefault(a => a.Id == id);
    }
}
