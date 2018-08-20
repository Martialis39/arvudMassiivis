using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arvudMassiivis
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] array = new int[10, 10];

            Random r = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] = r.Next(0, 100);
                    Console.Write("\t" +array[i,j]);
                }

                Console.WriteLine();
            }



            Console.WriteLine("I have an array of 100 numbers. Ask me for a number, I will tell you if I have it and where it is");
            int input = int.Parse(Console.ReadLine());

            int[] location = new int[2];
            bool found = false;
            int smallestDifference = int.MaxValue;
            int[] closestLocation = new int[2];
            List<int[]> otherOccurences = new List<int[]>();
            
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int difference = Math.Abs(array[i, j] - input);
                    if (difference < smallestDifference)
                    {
                        closestLocation[0] = i;
                        closestLocation[1] = j;
                        smallestDifference = difference;
                    }
                    if(array[i, j] == input)

                    {
                        if (!found)
                        {

                            location[0] = i;
                            location[1] = j;
                            found = true;
                        } else if (found)
                        {
                            otherOccurences.Add(new int[]{i, j});
                        }
                    }
                }
            }
            if (found)
            {
                Console.WriteLine($"I found your number at Y -{location[0] + 1}, X {location[1] + 1}");
            }
            else if (!found)
            {
            Console.WriteLine($"I dont have that, the closest one I have is {array[closestLocation[0], closestLocation[1]]}");
            }
        }
    }
}
