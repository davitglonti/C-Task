using System;
using System.Threading.Tasks;

namespace C_Task
{
    internal class Program
    {
        static async Task Main(string[] args) 
        {
            // task 1
            string input = "aa";
            bool result = Palindrome.sPalindrome(input);
            Console.WriteLine(result ? "Palindrome!" : "not palindrome!");

            // task 2
            int amount = 87;
            int results = CoinChanger.MinCoinCount(amount);
            Console.WriteLine($"min coins: {results}");

            // task 3 
            int[] array = { 1, 2, 3, 5, 6 };
            int resultss = MissingNumber.NotContains(array);
            Console.WriteLine($"\r\nFirst non-existent positive number: {resultss}"); //correct : 4

            // task 4 
            string test1 = "(()())";   // Correct
            string test2 = "())()";    // Wrong

            Console.WriteLine(BracketValidator.IsProperly(test1) ? "correct" : "wrong");
            Console.WriteLine(BracketValidator.IsProperly(test2) ? "correct" : "wrong");

            // task 5
            Console.Write("Enter the number of steps: ");
            if (int.TryParse(Console.ReadLine(), out int stairCount) && stairCount > 0)
            {
                Console.WriteLine($"The number  {stairCount} of ways to climb the stairs : {Staircase.CountVariants(stairCount)}");
            }
            else
            {
                Console.WriteLine("Please enter a valid, positive integer\r\n.");
            }

            //task 7
            using var context = new AppDbContext();
            context.Database.EnsureCreated(); 

            var service = new TeacherService(context);

            Console.Write("name: ");
            string studentName = Console.ReadLine();

            var teachers = service.GetAllTeachersByStudent(studentName);

            if (teachers.Length == 0)
            {
                Console.WriteLine("No teachers were found for such a student\r\n.");
            }
            else
            {
                Console.WriteLine($"Teachers who teach {studentName}-:");
                foreach (var teacher in teachers)
                {
                    Console.WriteLine($"{teacher.FirstName} {teacher.LastName} - {teacher.Subject}");
                }
            }

                //

                // task 8
                Console.WriteLine("Starting to generate country data files...");
            var countryDataService = new CountryDataService();
            await countryDataService.GenerateCountryDataFiles(); 
            Console.WriteLine("Country data files generation completed.");

            //

            // Task 9
            SynchronizationTask syncTask = new SynchronizationTask();
            await syncTask.RunAsync();
        }
    }
}
