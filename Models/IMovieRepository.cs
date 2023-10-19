using System;
using System.Collections.Generic;
using Horror_Reviews.Models;


namespace Horror_Reviews.Models
{
	public interface IMovieRepository
	{
		public IEnumerable<Movie> GetAllMovies();
		public Movie GetMovie(int id);
        public void UpdateMovie(Movie movie);
        public void InsertMovie(Movie movieToInsert);
        public IEnumerable<Category> GetMovies();
        public Movie AssignMovie();
        public void DeleteMovie(Movie movie);
        public IEnumerable<Movie> SearchMovie(string searchString);
    }
}

