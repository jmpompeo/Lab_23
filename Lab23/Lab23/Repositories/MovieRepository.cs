using Lab23.Data;
using Lab23.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab23.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        //private readonly List<Movies> _movies;
        private readonly MovieDbContext _context;


        public MovieRepository(MovieDbContext context)
        {
            //List<Movies> movies = new List<Movies>
            //{
            //    new Movies { Id = 1, Title = "21 Jump Street", Genre = "Comedy", Runtime = 95.5 },
            //    new Movies { Id = 2, Title = "Star Wars: A New Hope", Genre = "Sci-Fi", Runtime = 120.2 },
            //    new Movies { Id = 3, Title = "Star Wars: Force Awakens", Genre = "Sci-Fi", Runtime = 115.1 },
            //    new Movies { Id = 4, Title = "Avengers", Genre = "Action", Runtime = 85.2 },
            //    new Movies { Id = 5, Title = "Grown Ups", Genre = "Comedy", Runtime = 90.2 },
            //    new Movies { Id = 6, Title = "Top Gun", Genre = "Action" },
            //    new Movies { Id = 7, Title = "Saw", Genre = "Horror", Runtime = 90 },
            //    new Movies { Id = 8, Title = "Annabelle", Genre = "Horror", Runtime = 80 },
            //    new Movies { Id = 9, Title = "Avengers: Ultron", Genre = "Action", Runtime = 90 },
            //    new Movies { Id = 10, Title = "Avengers Infinity War", Genre = "Action", Runtime = 90 },
            //    new Movies { Id = 11, Title = "Step Brothers", Genre = "Comedy", Runtime = 90 },
            //    new Movies { Id = 12, Title = "Friends With Benefits", Genre = "RomCom", Runtime = 90 },
            //    new Movies { Id = 13, Title = "Runaway Bride", Genre = "RomCom", Runtime = 90 },
            //    new Movies { Id = 14, Title = "Star Wars: ROTS", Genre = "Sci-Fi", Runtime = 95 },
            //    new Movies { Id = 15, Title = "Avengers Endgame", Genre = "Action", Runtime = 90 }
            //};

            //_movies = movies;

            _context = context;
        }

        public async Task Create(Movies movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Movies.AnyAsync(x => x.Id == id);
        }

        public async Task<List<Movies>> Get()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task Update (Movies movie)
        {
            _context.Update(movie);
            await _context.SaveChangesAsync();

        }

        public async Task<Movies> Get(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<List<Movies>> SearchByGenre(Movies model)
        {


            var results = _context.Movies.FindAsync(model);

            return await _context.Movies.Where(s => s.Genre.ToLower().Contains(model.Genre.ToLower())).ToListAsync();

        }

        public async Task<List<Movies>> SearchByTitle(Movies model)
        {
            return await _context.Movies.Where(s => s.Title.ToLower().Contains(model.Title.ToLower())).ToListAsync();
        }
    }
}

