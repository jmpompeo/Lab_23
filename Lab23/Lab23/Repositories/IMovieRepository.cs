using Lab23.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab23.Repositories
{
    public interface IMovieRepository
    {
        Task Create(Movies movie);
        Task Delete(int id);
        Task<bool> Exists(int id);
        Task<List<Movies>> Get();
        Task<Movies> Get(int id);
        Task Update(Movies movie);

        Task<List<Movies>> SearchByGenre(Movies model);
        Task<List<Movies>> SearchByTitle(Movies model);


    }
}
