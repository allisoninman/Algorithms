using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class Knapsack
    {
        public static List<KnapsackItem> solveKnapsack(List<KnapsackItem> items, double maxKnapsackWeight)
        {
            int n = items.Count;
            int currentCount = 1;
            int max = (int) Math.Pow(2, n) - 1;
            double currentMaxVal = 0;
            List<KnapsackItem> mostValuableItems = new List<KnapsackItem>();

            while (currentCount <= max)
            {
                string permutation = Convert.ToString(currentCount, 2);
                List<KnapsackItem> tempItems = new List<KnapsackItem>();
                double tempVal = 0;
                double weight = 0;
                for(int i = n - permutation.Length; i < n; i++)
                {
                    if(permutation[i - n + permutation.Length] == '1')
                    {
                        tempVal += items[i].Value;
                        weight += items[i].Weight;
                        tempItems.Add(items[i]);
                    }
                }

                if (weight <= maxKnapsackWeight && tempVal > currentMaxVal)
                {
                    currentMaxVal = tempVal;
                    mostValuableItems = tempItems;
                }

                currentCount++;
            }

            return mostValuableItems;
        }

        private static string formatBinaryString(string permutation, int desiredLength)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < desiredLength - permutation.Length; i++)
            {
                sb.Append("0");
            }
            sb.Append(permutation);
            return sb.ToString();
        }
    }

    public class KnapsackItem
    {
        public double Weight { get; set; }
        public double Value { get; set; }
    }
}
