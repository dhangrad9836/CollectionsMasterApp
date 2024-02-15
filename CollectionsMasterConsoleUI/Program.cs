using System;
using System.Collections.Generic;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50
            int[] numbers = new int [50];

            //TODO: Create a method to populate the numbers array with 50 random numbers that are between 0 and 50
            //see below
            //Pass in the numbers array created above into the Populater method
            Populater(numbers);


            //TODO: Print the first number of the array
            Console.WriteLine($"First number in the numbers array is: {numbers[0]}");

            //TODO: Print the last number of the array            
            Console.WriteLine($"Last number in the numbers array is: {numbers.Length - 1}");

            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(numbers);
            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */

            Console.WriteLine("All Numbers Reversed:");            

            Console.WriteLine("---------REVERSE CUSTOM------------");
            //call the ReverseArray method
            //ReverseArray(numbers);

            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");
            //call the ThreeKiller method
            ThreeKiller(numbers);


            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(numbers);
            //use NumberPrinter method to print out the sorted numbers array
            NumberPrinter(numbers);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List
            List<int> numberList = new List<int>();

            //TODO: Print the capacity of the list to the console
            Console.WriteLine($"The capacity of the list is: {numberList.Capacity}");

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            Populater(numberList);


            //TODO: Print the new capacity
            Console.WriteLine($"The new capacity of the list is: {numberList.Capacity}");

            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            
            int userSearchNumber;
            bool isNum;
            do
            {
                //do while loop will print out the console line below once
                //then the int.TryParse will take in a user input
                //the while(__) will check if it's not an integer and will repeat until int is entered
                Console.WriteLine("What number will you search for in the number list?");
                isNum = int.TryParse(Console.ReadLine(), out userSearchNumber);
                //NumberChecker(numberList, userSearchNumber);
            } while (isNum == false);
            //if the user input passes as an interger the value will be passed into userSearchNumber
            //and NumberChecker() will take in two arguments the list and the user input
            NumberChecker(numberList, userSearchNumber);

            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(numberList);
            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            OddKiller(numberList);

            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted odds!!");
            numberList.Sort();
            NumberPrinter(numberList);

            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            var listToArray = numberList.ToArray();


            //TODO: Clear the list
            numberList.Clear();
            

            Console.ReadLine();
            #endregion
        }//end main method

        private static void ThreeKiller(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
                Console.WriteLine($"Three: {numbers[i]}");
            }
        }

        private static void OddKiller(List<int> numberList)
        {
            //loop through the list backwards and iterate backwards
            for(int i = numberList.Count - 1; i >= 0; i--)
            {
                ///if an odd number is in the list at this number numberList[i]
                if (numberList[i] % 2 != 0)
                {   //remove that odd number here using .Remove method and (numberList[i])
                    numberList.Remove(numberList[i]);
                }
            }
            Console.WriteLine("Odd Killer");
            NumberPrinter(numberList);
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            if (numberList.Contains(searchNumber))
            {
                Console.WriteLine($"The number {searchNumber} is in the list");
            }
            else
            {
                Console.WriteLine("Your number is not in the list");
            }
        }

        private static void Populater(List<int> numberList)
        {
            for (int i = 0; i <= 50; i++) {
                //create a random number
                Random rng = new Random();
                //generate a random number between 0 and 50
                int num = rng.Next(0, 50);
                numberList.Add(num);
            }
            Console.WriteLine("New list");
            NumberPrinter(numberList);


        }

        private static void Populater(int[] numbers)
        {
            //Create a method to populate the number array with 50 random numbers
            //that are between 0 and 50
            
            //generate a random number between 0 and 50            
            for(int i = 0; i < numbers.Length; i++)
            {
                //use random number generator to create an instance of a Random number
                Random rng = new Random();
                //using the rng we will populate a random number between 0 and 50 and we will
                //store it in each index of the numbers array for the length of the array
                numbers[i] = rng.Next(0, 50);
            }


        }        

        private static void ReverseArray(int[] array)
        {   
            //built-in .Reverse method
            Array.Reverse(array);
            //use NumberPrinter method
            NumberPrinter(array);
            foreach(var num in array)
            {
                Console.WriteLine(num);
            }
            
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
