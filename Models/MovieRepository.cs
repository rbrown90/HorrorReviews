using System;
using System.Data;
using Dapper;
using System.Collections.Generic;
using Horror_Reviews.Models;

namespace Horror_Reviews.Models
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDbConnection _conn;

        public MovieRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void InsertMovie(Movie movieToInsert)
        {
            _conn.Execute("INSERT INTO names (GENRE, NAME, YEAR, RATING, DIRECTOR, VIEWERREVIEW, CATEGORYID) VALUES (@genre, @name, @year, @rating, @director, @viewerreview, @categoryID);",
                new { genre = movieToInsert.Genre, name = movieToInsert.Name, year = movieToInsert.Year, rating = movieToInsert.Rating, director = movieToInsert.Director, viewerreview = movieToInsert.ViewerReview, categoryID = movieToInsert.CategoryID });
        }

        public IEnumerable<Category> GetMovies()
        {
            return _conn.Query<Category>("SELECT * FROM Created_Movie;");
        }

        public Movie AssignMovie()
        {
            var categoryList = GetMovies();
            var movie = new Movie();
            movie.Created_Movie = categoryList;
            return movie;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _conn.Query<Movie>("SELECT * FROM NAMES;");
        }

        public Movie GetMovie(int id)
        {
            return _conn.QuerySingle<Movie>("SELECT * FROM NAMES WHERE MOVIEID = @id", new { id = id });
        }

        public void UpdateMovie(Movie movie)
        {
            _conn.Execute("UPDATE names SET Name = @name, Director = @director, Genre = @genre WHERE MovieID = @id",
            new {name = movie.Name, director = movie.Director, genre = movie.Genre, id = movie.MovieID});
        }

        public void DeleteMovie(Movie movie)
        {
            _conn.Execute("DELETE FROM NAMES WHERE MovieID = @id;", new { id = movie.MovieID });
        }

        public IEnumerable<Movie> SearchMovie(string searchString)
        {
            return _conn.Query<Movie>("SELECT * FROM NAMES WHERE NAME LIKE @name;",
                new { name = "%" + searchString + "%" });
        }
    }
}
