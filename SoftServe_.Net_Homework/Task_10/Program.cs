using System;
using System.Collections;
namespace Task_10
{

    public enum FilmGenre
    {
        Action,
        Adventure,
        Comedy,
        Drama,
        Fantasy,
        Historical,
        Horror,
        Romance,
        ScienceFiction,
        Thriller
    }

    public class Movie : ICloneable, IComparable<Movie>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Country { get; set; }
        public FilmGenre Genre { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }

        public Movie(string name, string description, string director, string country, FilmGenre genre, int year, int rating)
        {
            Name = name;
            Description = description;
            Director = director;
            Country = country;
            Genre = genre;
            Year = year;
            Rating = rating;
        }

        public int CompareTo(Movie? other)
        {
            if (other == null) return 1;
            return this.Name.CompareTo(other.Name) * -1;
        }

        public object Clone()
        {
            var copy = (Movie)this.MemberwiseClone();
            copy.Name = (string)this.Name.Clone();
            return copy;
        }

        public override string ToString()
        {
            return "Film Name: " + Name + "\nDescription: " + Description + "\nDirector: " + Director +
                "\nCountry: " + Country + "\nGenre: " + Genre + "\nYear: " + Year + "\nRating: " + Rating + "\n";
        }
    }

    public class Cinema : IEnumerable
    {
        private Movie[] movie;

        public Cinema()
        {
            movie = new[]
            {
                new Movie("The Shawshank Redemption", "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "Frank Darabont", "United States", FilmGenre.Drama, 1994, 9),
                new Movie("The Godfather", "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", "United States", FilmGenre.Drama, 1972, 9),
                new Movie("The Dark Knight", "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.", "Christopher Nolan", "United States", FilmGenre.Action, 2008, 9),
            };
       
        }
        public IEnumerator GetEnumerator()
        {
            return movie.GetEnumerator();
        }
        public void SortByName()
        {
            Array.Sort(movie);
        }
        public void Sort(IComparable comparable)
        {
            Array.Sort(movie);
        }
        public void ShowObjects()
        {
            foreach (var item in movie)
            {
                Console.WriteLine(item);
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Cinema cinema= new Cinema();
            cinema.SortByName();
            cinema.ShowObjects();

            foreach(Movie item in cinema)
            {
                Console.WriteLine(item.Genre);
            }


            Movie movie = new Movie("The Shawshank Redemption", "Two imprisoned men bond over a number of years, finding solace .", "Frank Darabont", "United States", FilmGenre.Drama, 1998, 10);

            Movie copy = (Movie)movie.Clone();
            movie.Rating += 4;

            Console.WriteLine("Original rating: " + movie.Rating);
            Console.WriteLine("Copy rating: " + copy.Rating );

        }
    }
}