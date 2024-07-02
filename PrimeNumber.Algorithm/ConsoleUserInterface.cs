namespace PrimeNumber.Algorithm
{
    public class ConsoleUserInterface : IUserInterface
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public int GetIntegerInput(string message)
        {
            while (true)
            {
                DisplayMessage(message);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                else
                {
                    DisplayMessage("Invalid input. Please enter a valid integer.");
                }
            }
        }
    }
}
