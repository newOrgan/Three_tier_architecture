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
    public class MovieRepository : Repository<Movie>
    {
        public MovieRepository(MovieAppContext context) : base(context)
        {
        }
    }
}
