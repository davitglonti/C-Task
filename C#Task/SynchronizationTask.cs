using System;
using System.Threading;
using System.Threading.Tasks;

public class SynchronizationTask
{
    private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1); // SemaphoreSlim for synchronization
    private bool isPaused = false; // To track whether we are paused for the message
    private int count = 0; // For keeping track of the current number (1 or 0)

    public async Task RunAsync()
    {
        var task = Task.Run(() => PrintNumbers());

        while (true)
        {
            await Task.Delay(5000);

            await semaphore.WaitAsync();
            isPaused = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Neo, you are the chosen one");
            await Task.Delay(5000); 
            isPaused = false;
            semaphore.Release(); 

           
        }
    }

    private async Task PrintNumbers()
    {
        while (true)
        {
            await semaphore.WaitAsync(); // Ensure synchronization

            if (!isPaused)
            {
                // Print 1 and 0 continuously without a delay
                Console.ForegroundColor = (count % 2 == 0) ? ConsoleColor.Green : ConsoleColor.Green;
                Console.Write(count % 2 == 0 ? "1" : "0");
                count++;

                // Add log to track number print
                Console.WriteLine($"Printed: {count % 2 == 0 ? "1" : "0"}");

                await Task.Yield();
            }

            semaphore.Release(); // Allow other tasks to run
            await Task.Delay(100); // Delay just a bit to prevent high CPU usage
        }
    }
}
