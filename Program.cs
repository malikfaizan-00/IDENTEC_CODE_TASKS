using System;
using System.Linq;
using System.IO;
using System.Text;

namespace Identec_Task
{
    class Program
    {
        
        /////////////// 1 Create a method, which calculates the median /////////////
        private static decimal CalculateMedian (int[] numbers) {
            if (numbers.Length == 0 || numbers == null ) {
                throw new System.Exception("Median of empty array or null is not defined.");
            }

            int halfIndex = numbers.Length/2;
            var sortedNumbers = numbers.OrderBy(n=>n);
            decimal median;
            
            if ((numbers.Length % 2) == 0) {
                median = Decimal.Divide(sortedNumbers.ElementAt(halfIndex) + sortedNumbers.ElementAt((halfIndex - 1)), 2);
            } else {
                median = sortedNumbers.ElementAt(halfIndex);
            }
            return median;
        }
        

        /////////////// Create a method, which counts all occurrences of the digit ‘2‘ in numbers from 1 to N (N should be given as parameter). /////////////
        
        // This function calculates the Count of 2's in a number as a parameter.
        private static int GetNumberOfTwos(int n) {
            int count = 0;
            while (n > 0) {
                if (n % 10 == 2) {
                    count++;
                }
                n = n / 10;
            }
            return count;
        }
        
        // It takes a number as parameter and counts the number of '2' digit from 1 to N.
        private static int CountTwosinRange(int n) {
            int count = 0;
            for (int i = 2; i <= n; i++) {
                count += GetNumberOfTwos(i);
            }
            return count;
        }

        /////////////// File reading and add numaric values /////////////

        private static decimal AddNumaric (string path) {
            decimal sum = 0;
            if (String.IsNullOrEmpty(path)) {
                throw new System.Exception("Please enter the valid file path.");
            }
            try {
                using (var sr = new StreamReader (@""+path)) {
                    string content = sr.ReadToEnd();
                    var numbers = content.Split( new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None );
                    foreach (string numb in numbers) {
                        try {
                            sum += decimal.Parse(numb);
                        } catch (FormatException ex) {
                            Console.WriteLine("Unable to parse " + numb + " : " + ex.Message);
                        }
                    }
                }
            } catch (FileNotFoundException fileEx) {
                Console.WriteLine("File not found : " + fileEx.Message);
            } catch (DirectoryNotFoundException dirEx) {
                Console.WriteLine("Directory not found: " + dirEx.Message);
            } catch (Exception ex) {
                Console.WriteLine("An unknown error occured : " + ex.Message);
            } finally {
                // Console.WriteLine("Finally runs all the time.");
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int[] numbers = { 5, 5, 5, 4, 5, 2, 2, 2, 1, 5 };
            Console.WriteLine("Median = " + CalculateMedian(numbers));

            Console.WriteLine("Number of 2's = " + CountTwosinRange(30));

            Console.WriteLine("Sum = " + AddNumaric("numbers.txt"));
        }
    }
}
