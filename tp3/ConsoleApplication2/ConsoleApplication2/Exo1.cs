using System;
using System.Linq;

namespace ConsoleApplication2
{
    public class Exo1
    {
        static MovieCollection collection = new MovieCollection();
        
        public static void e1p1()
        {
            Console.WriteLine("The total of movies is : " + collection.Movies.Count());
        }
        
        public static void e1p2()
        {
            Console.WriteLine("The total of movies with the letter e is : " +
                              collection.Movies.Count(x => x.Title.Contains('e')));
        }
        
        public static void e1p3()
        {
            var fCounter = 0;
            foreach (var movie in collection.Movies)
            {
                fCounter += movie.Title.Count(x => x == 'f');
            }
            Console.WriteLine("The total of letter f  in movies titles is : " + fCounter);
        }
        
        public static void e1p4()
        {
            Console.WriteLine("The title of the movies with the higher budget : " +
                              collection.Movies.OrderByDescending(x => x.Budget).First().Title);
        }
        
        public static void e1p5()
        {
            Console.WriteLine("The title of the movies with the lowest box office : " +
                              collection.Movies.OrderByDescending(x => x.BoxOffice).Last().Title);
        }
        
        public static void e1p6()
        {
            Console.WriteLine("The title of the movies with the lowest box office :\n" + string.Join(", ",
                collection.Movies.OrderByDescending(x => x.Title).Take(11).Select(x => x.Title)));
        }
        
        public static void e1p7()
        {
            Console.WriteLine("The total of movies made before 1980 : " +
                              collection.Movies.Count(x => x.ReleaseDate.Year<1980));
        }
        
        public static void e1p8()
        {
            Console.WriteLine("The average running time of movies having a vowel as the first letter : " +
                              collection.Movies.Where(x => x.Title.StartsWith("A") || 
                                                           x.Title.StartsWith("E") ||
                                                           x.Title.StartsWith("I") || x.Title.StartsWith("O") ||
                                                           x.Title.StartsWith("U") || x.Title.StartsWith("Y"))
                                  .Select(x => x.RunningTime).Average());
        }
        
        public static void e1p9()
        {
            Console.WriteLine("All movies with the letter H or W in the title, but not the letter I or T : " + string.Join(", ",
                collection.Movies.Where(x => (x.Title.ToUpper().Contains("H") || 
                                              x.Title.ToUpper().Contains("W")) &&
                                             !x.Title.ToUpper().Contains("I") &&
                                             !x.Title.ToUpper().Contains("T"))
                    .Select(x => x.Title)));
        }
        
        public static void e1p10()
        {
            Console.WriteLine("The mean of all Budget / Box Office of every movie ever : " + 
                              collection.Movies.Where(x => x.Budget != 0 && x.BoxOffice != 0)
                                  .Select(x => x.Budget / x.BoxOffice).Average());
        }
    }
}