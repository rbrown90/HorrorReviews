using System;
using Horror_Reviews.Models;

namespace Horror_Reviews.Models
{
    public class Movie
	{
		public Movie()
		{

		}

        public int Year { get; set; }
        public string Name { get; set; }
		public string Genre { get; set; }
		public int Rating { get; set; }
		public string Director { get; set; }
		public int CategoryID { get; set; }
		public int MovieID { get; set; }
		public string ViewerReview { get; set; }
		public string ImgPath { get; set; }
		public IEnumerable<Category> Created_Movie { get; set; }
	}
}

