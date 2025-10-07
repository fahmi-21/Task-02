
List<int> numbers = new();

char choice;

void Empty()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("____________________ ");
    Console.WriteLine("|[] - list is empty|");
    Console.WriteLine("--------------------");
    Console.ResetColor();
    Console.WriteLine();
}

do
{
    Console.WriteLine("------------------------------------");
    Console.WriteLine("|             Main Menu            |");
    Console.WriteLine("------------------------------------");
    Console.WriteLine("|P - Print numbers                 |");
    Console.WriteLine("|A - Add a number                  |");
    Console.WriteLine("|D - Descending sort               |");
    Console.WriteLine("|E - Ascending sort                |");
    Console.WriteLine("|M - Display mean of the numbers   |");
    Console.WriteLine("|S - Display the smallest number   |");
    Console.WriteLine("|L - Display the largest number    |");
    Console.WriteLine("|F - Find a number                 |");
    Console.WriteLine("|W - Swap two numbers              |");
    Console.WriteLine("|B - Duplicate a number            |");
    Console.WriteLine("|C - Clear the whole list          |");
    Console.WriteLine("|Q - Quit                          |");
    Console.WriteLine("------------------------------------");
    Console.Write("=> ");

    choice = char.ToUpper(Console.ReadKey().KeyChar);
    Console.WriteLine();

    switch (choice)
    {
        case 'P':
            if (numbers.Count == 0)
                Empty();
            else
                Console.WriteLine("[ " + string.Join(" ", numbers) + " ]");
            break;

        case 'A':
            Console.Write("Enter a number to add to the list: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int num))
            {
                numbers.Add(num);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{num} added successfully!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            break;

        case 'D':
            if (numbers.Count == 0)
                Empty();
            else
            {
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    for (int j = i + 1; j < numbers.Count; j++)
                    {
                        if (numbers[i] < numbers[j])
                        {
                            int temp = numbers[i];
                            numbers[i] = numbers[j];
                            numbers[j] = temp;
                        }
                    }
                }
                Console.WriteLine("List sorted in descending order:");
                Console.WriteLine("[ " + string.Join(" ", numbers) + " ]");
            }
            break;

        case 'E':
            if (numbers.Count == 0)
                Empty();
            else
            {
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    for (int j = i + 1; j < numbers.Count; j++)
                    {
                        if (numbers[i] > numbers[j])
                        {
                            int temp = numbers[i];
                            numbers[i] = numbers[j];
                            numbers[j] = temp;
                        }
                    }
                }
                Console.WriteLine("List sorted in ascending order:");
                Console.WriteLine("[ " + string.Join(" ", numbers) + " ]");
            }
            break;

        case 'M':
            if (numbers.Count == 0)
                Empty();
            else
            {
                double mean = numbers.Average();
                Console.WriteLine($"The mean of the numbers is: {mean}");
            }
            break;

        case 'S':
            if (numbers.Count == 0)
                Empty();
            else
                Console.WriteLine($"The smallest number is: {numbers.Min()}");
            break;

        case 'L':
            if (numbers.Count == 0)
                Empty();
            else
                Console.WriteLine($"The largest number is: {numbers.Max()}");
            break;

        case 'F':
            if (numbers.Count == 0)
                Empty();
            else
            {
                Console.Write("Enter the number you want to find: ");
                string findInput = Console.ReadLine();
                if (int.TryParse(findInput, out int number))
                {
                    bool found = false;
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == number)
                        {
                            Console.WriteLine($"Found at index {i}");
                            found = true;
                        }
                    }
                    if (!found)
                        Console.WriteLine("Number not found in list.");
                }
                else
                    Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            break;

        case 'W':
            if (numbers.Count == 0)
                Empty();
            else
            {
                Console.Write("Enter the indexes you want to swap (with space between them): ");
                string[] indices = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (indices.Length != 2 ||
                    !int.TryParse(indices[0], out int ind1) ||
                    !int.TryParse(indices[1], out int ind2))
                {
                    Console.WriteLine("Invalid input. Please enter two valid indexes separated by space.");
                }
                else if (ind1 < 0 || ind1 >= numbers.Count || ind2 < 0 || ind2 >= numbers.Count)
                {
                    Console.WriteLine("Invalid index. Please try again.");
                }
                else
                {
                    int temp = numbers[ind1];
                    numbers[ind1] = numbers[ind2];
                    numbers[ind2] = temp;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Numbers at index {ind1} and {ind2} have been swapped.");
                    Console.ResetColor();
                }
            }
            break;

        case 'B':
            if (numbers.Count == 0)
                Empty();
            else
            {
                Console.Write("Enter the index of the number you want to duplicate: ");
                string dupInput = Console.ReadLine();
                if (int.TryParse(dupInput, out int numIndex) &&
                    numIndex >= 0 && numIndex < numbers.Count)
                {
                    numbers.Add(numbers[numIndex]);
                    Console.WriteLine($"Number {numbers[numIndex]} duplicated.");
                }
                else
                {
                    Console.WriteLine("Invalid index. Please try again.");
                }
            }
            break;

        case 'C':
            numbers.Clear();
            Console.WriteLine("The list has been cleared.");
            break;

        case 'Q':
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Unknown selection, please try again.");
            break;
    }
} while (choice != 'Q');
