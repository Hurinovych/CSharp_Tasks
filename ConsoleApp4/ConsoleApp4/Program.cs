namespace ConsoleApp4
{
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie("Gran Turismo", Genre.Action),
                new Movie("Gentlemen", Genre.Action),
                new Movie("Oppenheimer", Genre.Drama),
                new Serial("Breaking Bad", Genre.Drama, 5),
                new Serial("Stranger Things", Genre.SciFi, 4)
            };
            Console.WriteLine("Basic movies list without changes:");
            foreach (var movie in movies)
            {
                movie.DisplayInfo();
                Console.WriteLine();
            }
            Console.WriteLine();
            foreach (var movie in GetMoviesByGenre(movies))
            {
                movie.DisplayInfo();
                Console.WriteLine();
            }

            static List<Movie> GetMoviesByGenre(List<Movie> movieList)
            {
                Console.Write("Enter genre for search: ");
                string genreString = Console.ReadLine();
                if (Enum.IsDefined(typeof(Genre), genreString))
                {
                    Genre genre = (Genre)Enum.Parse(typeof(Genre), genreString);

                    List<Movie> filteredMovies = movieList.FindAll(movie => movie.Genre == genre);
                    return filteredMovies;
                }
                else
                {
                    Console.WriteLine("Entered genre didn't find.");
                    return new List<Movie>();
                }
            }
        }
    }
    public enum Genre
    {
        Action,
        Detective,
        Drama,
        Comedy,
        SciFi,
        Horror,
        Thriller,
        Sport
    }
    public class Movie
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Movie(string title, Genre genre)
        {
            Title = title;
            Genre = genre;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Genre: {Genre}");
        }
    }
    public class Serial : Movie
    {
        public int NumberOfSeasons { get; set; }
        public Serial(string title, Genre genre, int numberOfSeasons) : base(title, genre)
        {
            NumberOfSeasons = numberOfSeasons;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Number of Seasons: {NumberOfSeasons}");
        }
    }
}
