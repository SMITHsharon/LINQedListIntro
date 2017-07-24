using System;
using System.Collections.Generic;
using System.Linq;

namespace linqList
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Are all the numbers even?
            // JAVASCRIPT
            // var sampleNumbers = [18, 9, 5, 6, 84, 2, 5, 13];
            // var allAreEven = sampleNumbers.every(value => { return value % 2 == 0 });
            // LINQ
            List <int> sampleNumbers = new List <int> ()
            {
                18, 9, 5, 6, 84, 2, 5, 13
            };
           bool areAllEven = sampleNumbers.All(number => number % 2 == 0);

           Console.WriteLine();
           if (areAllEven)
           {
               Console.WriteLine("This list contains all even numbers.");
           }
           else
           {
                Console.WriteLine("This list does not contain only even numbers.");
           }


            // Limit an array to the items that meet a criteria
            // JAVASCRIPT
            // var onlyEvens = sampleNumbers.filter(value => { return value % 2 == 0 });
            // LINQ
            var onlyEvens = 
                from n in sampleNumbers
                where n % 2 == 0
                select n;

            Console.WriteLine();
            Console.WriteLine("This is a list of only the even numbers:");
            foreach (var n in onlyEvens)
            {
                Console.WriteLine(n);
            }
            
            // Perform an action on each item in an array
            // JAVASCRIPT
            // onlyEvens.forEach(evenValue => { console.log(evenValue + " is an even value"); });
            // LINQ
            Console.WriteLine();
            onlyEvens.ToList().ForEach(evenValue => Console.WriteLine(evenValue + " is an even value"));



            // Transforms each value in an array 
            // JAVASCRIPT
            // var sampleNumbersSquared = sampleNumbers.map(value => value * value);
            // LINQ
            var sampleNumbersSquared = 
                from n in sampleNumbers
                select n * n;
                
            Console.WriteLine();
            foreach (var n in sampleNumbersSquared)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            sampleNumbersSquared.ToList().ForEach(squaredValue => Console.WriteLine(squaredValue + " is the squared value."));



            // RESTRICTING/FILTERING OPERATIONS
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};
            var LFruits = from fruit in fruits where fruit.First() == 'L' select fruit;
            Console.WriteLine();
            Console.WriteLine("The words in the list that start with 'L' are: ");
            LFruits.ToList().ForEach(Console.WriteLine);


            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            var fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0);
            Console.WriteLine();
            Console.WriteLine("The numbers in the list that are multiples of 4 or 6 are: ");
            fourSixMultiples.ToList().ForEach(Console.WriteLine);



            // ORDERING OPERATIONS
            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre" 
            };

            var alphaNames = (
                from name in names 
                orderby name
                select name)
                .Reverse();

            Console.WriteLine();
            Console.WriteLine("The list of names in reverse alpha order: ");
            foreach (var name in alphaNames)
            {
                Console.WriteLine(name);
            }


            // Build a collection of these numbers sorted in ascending order
            List<int> sortNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var sortedInts =
                from x in sortNumbers
                orderby x
                select x;

            Console.WriteLine();
            Console.WriteLine("The sorted integers are: ");
            foreach (var x in sortedInts)
            {
                Console.WriteLine(x);
            }          



            // AGGREGATE OPERATIONS
            // Output how many numbers are in this list
            List<int> secondNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            Console.WriteLine();
            Console.WriteLine($"There are {secondNumbers.Count()} numbers in this list.");
            Console.WriteLine($"The maximum number in the list is {secondNumbers.Max()}.");
            Console.WriteLine($"The minimum number in the list is {secondNumbers.Min()}.");


            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            double moneySum = purchases.Sum(); 
            string formattedSum = String.Format("Order Total: {0:C}", moneySum); 
            Console.WriteLine();
            Console.WriteLine("We have made a total of {0}.", String.Format("{0:C}", moneySum)); 
            // Console.WriteLine("We have made a total of ${0}.", moneySum); 

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };
            double maxPrice = prices.Max();
            string formattedPrice = String.Format("{0:C}", maxPrice); 
            Console.WriteLine();
            Console.WriteLine($"Our most expensive product costs {formattedPrice}.");
            // Console.WriteLine($"Our most expensive product costs ${prices.Max()}.");



            // PARTITIONING OPERATIONS
            /*
                Store each number in the following List until a perfect square
                is detected.

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> whereSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
            var listUpToPerfectSquare = whereSquaredo.TakeWhile(n => Math.Sqrt(n)%1 != 0); 
            
            Console.WriteLine();
            var checkThis = Math.Sqrt(66)%1;
            Console.WriteLine($"checkThis for 66 :: {checkThis}");
            checkThis = Math.Sqrt(81)%1;
            Console.WriteLine($"checkThis for 81 :: {checkThis}");
            Console.WriteLine();
            Console.WriteLine("List up to the first perfect square:"); 

            foreach (var n in listUpToPerfectSquare) 
            { 
                Console.WriteLine(n); 
            } 
        }
    }
}
