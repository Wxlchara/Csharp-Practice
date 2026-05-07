using System.Xml.Serialization;

namespace XMLinClass
{
    public class Movie
    {
        private string _name;
        private int _duration;
        private int[] _review;
        public string Name => _name;
        public int Duration => _duration;
        public int[] Review => _review.ToArray();

        public Movie(string name, int duration)
        {
            _name = name;
            _duration = duration;
            _review = new int[0];
        }

        public void AddReview(int stars)
        {
            Array.Resize(ref _review, _review.Length + 1);
            _review[_review.Length - 1] = stars;
        }
    }

    public class MovieDTO
    {
        // Свойства с публичными сеттерами
        public string Name { get; set; }
        public int Duration { get; set; }
        public string MovieType { get; set; }
        public int[] Review {get; set;}

        // Конструктор без параметров
        public MovieDTO()
        {
            
        }

        // Movie -> MovieDTO
        public MovieDTO(string name, int duration)
        {
            MovieType = nameof(Movie);
            Name = name;
            Duration = duration;
        }

        public MovieDTO(Movie movie)
        {
            MovieType = movie.GetType().Name;
            Name = movie.Name;
            Duration = movie.Duration;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Movie movie1 = new Movie("Harry Potter", 120);
            MovieDTO movieDTO1 = new MovieDTO(movie1);
            
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(folderPath, "movie.xml");
            
            var serealizer = new XmlSerializer(typeof(MovieDTO));
            
            // Сериализация
            using (var writer = new StreamWriter(filePath))
            {
                serealizer.Serialize(writer, movieDTO1);
            }
            
            // Десериализация
            MovieDTO movieDTO2;
            using (var reader = new StreamReader(filePath))
            {
                movieDTO2 = (MovieDTO)serealizer.Deserialize(reader);
            }
            
            Movie movie2 = new Movie(movieDTO2.Name, movieDTO2.Duration);
            foreach (int star in movieDTO2.Review)
            {
                movie2.AddReview(star);
            }

            // Проверка равенства изначального и полученного объекта
            if (CompareMovies(movie1, movie2))
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Not Success");
            }
        }

        public static bool CompareMovies(Movie m1, Movie m2)
        {
            if  (m1.Name != m2.Name) return false;
            if (m1.Duration != m2.Duration) return false;
            if (m1.Review.Length != m2.Review.Length) return false;
            for (int i = 0; i < m1.Review.Length; i++)
            {
                if (m1.Review[i] != m2.Review[i]) return false;
            }
            
            return true;
        }
    }
}