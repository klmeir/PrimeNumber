namespace PrimeNumber.Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUserInterface userInterface = new ConsoleUserInterface();
            IPrimeNumberGenerator primeNumberGenerator = new PrimeNumberGenerator();

            int i = userInterface.GetIntegerInput("Enter the starting number (i): ");
            int n = userInterface.GetIntegerInput("Enter the number of prime numbers to calculate (n): ");

            List<int> primeNumbers = primeNumberGenerator.GeneratePrimeNumbers(i, n);

            userInterface.DisplayMessage($"The first {n} prime numbers starting from {i} are:");
            foreach (int prime in primeNumbers)
            {
                userInterface.DisplayMessage(prime.ToString());
            }
        }
    }
}

//Principios SOLID aplicados:
//Single Responsibility Principle (SRP): Cada clase debe tener una sola responsabilidad. Vamos a separar la lógica de generación de números primos y la lógica de interacción con el usuario en diferentes clases.

//Open/Closed Principle (OCP): Las clases deben estar abiertas para la extensión pero cerradas para la modificación. Esto significa que debemos diseñar nuestro código de manera que podamos extender su funcionalidad sin modificar el código existente.

//Liskov Substitution Principle (LSP): Las clases derivadas deben poder sustituirse por sus clases base sin alterar el comportamiento del programa. En este caso, no estamos utilizando herencia directa, pero al diseñar interfaces y clases, consideraremos este principio.

//Interface Segregation Principle (ISP): Los clientes no deben verse obligados a depender de interfaces que no utilizan. Vamos a definir interfaces específicas para nuestras clases y métodos para que sean cohesivos y específicos.

//Dependency Inversion Principle (DIP): Los módulos de alto nivel no deben depender de módulos de bajo nivel. Ambos deben depender de abstracciones. Vamos a utilizar interfaces para desacoplar las dependencias entre nuestras clases.
