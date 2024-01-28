namespace BlandGroup;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Select between Palindrome or Quicksort:");

        string? response = Console.ReadLine();

        if (string.IsNullOrEmpty(response) || response != "Palindrome" && response != "Quicksort")
        {
            Console.WriteLine("Wrong input, please try again");
            return;
        }

        switch (response)
        {
            case "Palindrome":

                Console.WriteLine("Introduce a word to check if is Palindrome: ");

                string? word = Console.ReadLine();

                if (string.IsNullOrEmpty(word))
                {
                    Console.WriteLine("Wrong input, please try again");
                    return;
                }

                string isPalindromeResponse = (PalindromeChecker.IsPalindrome(word)) ? $"{word} is Palindrome" : $"{word} is no Palindrome";

                Console.WriteLine(isPalindromeResponse);

                Console.ReadLine();

                break;


            case "Quicksort":

                QuickSortOperation();

                Console.ReadLine();

                break;

            default:

                break;

        }
            




        
    }

    

    static void QuickSortOperation()
    {
        Console.Write("Enter the number of elements (maximum 10): ");
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0 && n <= 10)
        {
            Console.WriteLine("Enter the elements.");

            float[] elements = new float[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i + 1}: ");
                if (float.TryParse(Console.ReadLine(), out float element))
                {
                    elements[i] = element;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    return;
                }
            }

            Console.WriteLine("\nInput Elements:");
            PrintArray(elements);

            QuickSort.Quicksort(elements);

            Console.WriteLine("\nSorted Elements:");

            PrintArray(elements);
        }
        else
        {
            Console.WriteLine("Wrong number or input type");
            Console.ReadLine();
        }
    }

    static void PrintArray<T>(T[] array)
    {
        foreach (var item in array)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }


}

