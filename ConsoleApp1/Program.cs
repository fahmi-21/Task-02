List<int> numbers = new();

//variable to store user choice and switch case control============================
char choice;

//function to display when the list is empty=======================================
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
        //print the numbers or indicate that the list is empty========================
        case 'P':
            if (numbers.Count == 0)
                Empty();
            else
                Console.WriteLine("[ " + string.Join(" ", numbers) + " ]");
            break;
        //add a number to the list====================================================
        case 'A':
            Console.Write("Enter a number to add to the list: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int num))
            {
                bool exists = false;
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] == num)
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    numbers.Add(num);
                    Console.WriteLine($"{num} added to the list.");
                }
                else
                {
                    Console.WriteLine("Number already exists in the list. Not added.");
                }
            }
            break;
        //sort the list in descending order===========================================
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
                            int place = numbers[i];
                            numbers[i] = numbers[j];
                            numbers[j] = place;
                        }
                    }
                }
                Console.WriteLine("List sorted in descending order:");
                Console.WriteLine("[ " + string.Join(" ", numbers) + " ]");
            }
            break;
        //sort the list in ascending order============================================
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
                            int place = numbers[i];
                            numbers[i] = numbers[j];
                            numbers[j] = place;
                        }
                    }
                }
                Console.WriteLine("List sorted in ascending order:");
                Console.WriteLine("[ " + string.Join(" ", numbers) + " ]");
            }
            break;
        //calculate average of the numbers================================
        case 'M':
            if (numbers.Count == 0)
                Empty();
            else
            {
                double mean = numbers.Average();
                Console.WriteLine($"The mean of the numbers is: {mean}");
            }
            break;
        //find the smallest number===========================================
        case 'S':
            if (numbers.Count == 0)
                Empty();
            else
            {
                int smallest = numbers[0];
                for (int i = 1; i < numbers.Count; i++)
                {
                    if (numbers[i] < smallest)
                    {
                        smallest = numbers[i];
                    }
                }
                Console.WriteLine($"The smallest number is: {smallest}");
            }
            break;
        //find the largest number============================================
        case 'L':
            if (numbers.Count == 0)
                Empty();
            else
            {
                int largest = numbers[0];
                for (int i = 1; i < numbers.Count; i++)
                {
                    if (numbers[i] > largest)
                    {
                        largest = numbers[i];
                    }
                }
                Console.WriteLine($"The largest number is: {largest}");
            }

            break;
        //find a number and display its index===================================
        case 'F':
            if (numbers.Count == 0)
            {
                Empty();
            }
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
        //swap two numbers in the list====================================================================
        case 'W':
            if (numbers.Count == 0)
                Empty();
            else
            {
                Console.Write("Enter the indexes you want to swap (with space between them): ");
                string[] indixes = Console.ReadLine().Split();

                if (indixes.Length != 2 ||
                    !int.TryParse(indixes[0], out int ind1) ||
                    !int.TryParse(indixes[1], out int ind2))
                {
                    Console.WriteLine("Invalid input. Please enter two valid indexes separated by space.");
                }
                else if (ind1 < 0 || ind1 >= numbers.Count || ind2 < 0 || ind2 >= numbers.Count)
                {
                    Console.WriteLine("Invalid index. Please try again.");
                }
                else
                {
                    int place = numbers[ind1];
                    numbers[ind1] = numbers[ind2];
                    numbers[ind2] = place;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Numbers at index {ind1} and {ind2} have been swapped.");
                    Console.ResetColor();
                }
            }
            break;
        //clear the whole list==================================================================================
        case 'C':
            if (numbers.Count == 0)
            {
                Empty();
            }
            else
            {
                Console.Write("Are you sure you want to clear the list? (Y/N): ");
                char confirm = char.ToUpper(Console.ReadKey().KeyChar);
                if (confirm == 'Y')
                {
                    for (int i = numbers.Count - 1; i >= 0; i--)
                    {
                        numbers.RemoveAt(i);
                    }
                }
                else 
                {
                    Console.WriteLine("\nClear operation cancelled.");
                }
            }
            break;
        //quit the program=======================================================================================
        case 'Q':
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Unknown selection, please try again.");
            break;
    }
} while (choice != 'Q');
