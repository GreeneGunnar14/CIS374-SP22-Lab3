using System;
using System.Collections.Generic;
using Lab3.SortingAlgorithms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a set of randomly ordered lists with ranges from 1 thousand to 10 million
            Console.WriteLine("Creating random integer list of length 1 thousand...");
            List<int> randList1k = GenerateRandomIntList(1000, 5000);
            Console.WriteLine("Creating random integer list of length 10 thousand...");
            List<int> randList10k = GenerateRandomIntList(10000, 50000);
            Console.WriteLine("Creating random integer list of length 100 thousand...");
            List<int> randList100k = GenerateRandomIntList(100000, 500000);
            Console.WriteLine("Creating random integer list of length 1 million...");
            List<int> randList1mil = GenerateRandomIntList(1000000, 5000000);
            Console.WriteLine("Creating random integer list of length 10 million...");
            List<int> randList10mil = GenerateRandomIntList(10000000, 50000000);

            List<int>[] randLists = new List<int>[5];

            randLists[0] = randList1k;
            randLists[1] = randList10k;
            randLists[2] = randList100k;
            randLists[3] = randList1mil;
            randLists[4] = randList10mil;

            //Create a set of lists in reverese with ranges from 1 thousand to 10 million
            Console.WriteLine("Creating reversed integer list of length 1 thousand...");
            List<int> reversedList1k = GenerateReversedIntList(1000, 5000);
            Console.WriteLine("Creating reversed integer list of length 10 thousand...");
            List<int> reversedList10k = GenerateReversedIntList(10000, 50000);
            Console.WriteLine("Creating reversed integer list of length 100 thousand...");
            List<int> reversedList100k = GenerateReversedIntList(100000, 500000);
            Console.WriteLine("Creating reversed integer list of length 1 million...");
            List<int> reversedList1mil = GenerateReversedIntList(1000000, 5000000);
            Console.WriteLine("Creating reversed integer list of length 10 million...");
            List<int> reversedList10mil = GenerateReversedIntList(10000000, 50000000);

            List<int>[] reversedLists = new List<int>[5];

            reversedLists[0] = randList1k;
            reversedLists[1] = randList10k;
            reversedLists[2] = randList100k;
            reversedLists[3] = randList1mil;
            reversedLists[4] = randList10mil;

            //Create a set of nearly ordered lists with ranges from 1 thousand to 10 million
            Console.WriteLine("Creating almost ordered list of length 1 thousand...");
            List<int> almostOrderedList1k = GenerateAlmostOrderedIntList(1000, 5000);
            Console.WriteLine("Creating almost ordered list of length 10 thousand...");
            List<int> almostOrderedList10k = GenerateAlmostOrderedIntList(10000, 50000);
            Console.WriteLine("Creating almost ordered list of length 100 thousand...");
            List<int> almostOrderedList100k = GenerateAlmostOrderedIntList(100000, 500000);
            Console.WriteLine("Creating almost ordered list of length 1 million...");
            List<int> almostOrderedList1mil = GenerateAlmostOrderedIntList(1000000, 5000000);
            Console.WriteLine("Creating almost ordered list of length 10 million...");
            List<int> almostOrderedList10mil = GenerateAlmostOrderedIntList(10000000, 50000000);

            List<int>[] almostOrderedLists = new List<int>[5];

            almostOrderedLists[0] = randList1k;
            almostOrderedLists[1] = randList10k;
            almostOrderedLists[2] = randList100k;
            almostOrderedLists[3] = randList1mil;
            almostOrderedLists[4] = randList10mil;

            List<List<int>[]> listTypes = new List<List<int>[]>();

            listTypes.Add(almostOrderedLists);
            listTypes.Add(randLists);
            listTypes.Add(reversedLists);

            List<string> listNames = new List<string>();

            listNames.Add("Almost Ordered");
            listNames.Add("Randomly Ordered");
            listNames.Add("Reverse Ordered");

            SelectionSort<int> selectionSort = new SelectionSort<int>();
            InsertionSort<int> insertionSort = new InsertionSort<int>();
            QuickSort<int> quickSort = new QuickSort<int>();
            HeapSort<int> heapSort = new HeapSort<int>();
            //BucketSort bucketSort = new BucketSort();
            CountingSort countingSort = new CountingSort();
            RadixSort radixSort = new RadixSort();

            ISortable<int>[] sorts = new ISortable<int>[4];
            sorts[0] = selectionSort;
            sorts[1] = insertionSort;
            sorts[2] = quickSort;
            sorts[3] = heapSort;

            ISortableInt[] intSorts = new ISortableInt[2];
            intSorts[0] = countingSort;
            intSorts[1] = radixSort;

            //create a list with all the possible lengths for lists
            string[] listLengths = new string[5];
            listLengths[0] = "1 thousand";
            listLengths[1] = "10 thousand";
            listLengths[2] = "100 thousand";
            listLengths[3] = "1 million";
            listLengths[4] = "10 million";

            //list of strings to output to the file
            List<string> output = new List<string>();

            //Selection Sort
            //TestSort<int>(sort: sorts[0], listTypes: listTypes, listLengths: listLengths, listNames: listNames);

            //Insertion Sort
            //TestSort<int>(sort: sorts[1], listTypes: listTypes, listLengths: listLengths, listNames: listNames);

            //Quick Sort
            //TestSort<int>(sort: sorts[2], listTypes: listTypes, listLengths: listLengths, listNames: listNames);

            //Heap Sort
            //TestSort<int>(sort: sorts[3], listTypes: listTypes, listLengths: listLengths, listNames: listNames);

            //Bucket Sort
            TestSort(sort: intSorts[0], listTypes: listTypes, listLengths: listLengths, listNames: listNames);

            //Radix Sort
            TestSort(sort: intSorts[1], listTypes: listTypes, listLengths: listLengths, listNames: listNames);
        }

        public static double TimeSort<T>(ISortable<T> sortable, List<T> items) where T : IComparable<T>
        {
            // start timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            sortable.Sort(ref items);

            // end timer
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // print info
            //Console.WriteLine(sortable.GetType().ToString());

            // print elapsed time data
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //ts.Hours, ts.Minutes, ts.Seconds,
            //ts.Milliseconds / 10);
            //Console.WriteLine(elapsedTime);

            Console.Write(ts.TotalSeconds.ToString() + ", ");

            return ts.TotalSeconds;
        }

        public static double TimeSort(ISortableInt sortable, List<int> items)
        {
            // start timer
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            sortable.Sort(items.ToArray());

            // end timer
            stopWatch.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // print info
            //Console.WriteLine(sortable.GetType().ToString());

            // print elapsed time data
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //ts.Hours, ts.Minutes, ts.Seconds,
            //ts.Milliseconds / 10);
            //Console.WriteLine(elapsedTime);

            Console.Write(ts.TotalSeconds.ToString() + ", ");

            return ts.TotalSeconds;
        }

        public static List<int> GenerateReversedIntList(int length, int maxValue)
        {
            int step = maxValue / length;

            List<int> list = new List<int>();

            for (int i = length; i > 0; i--)
            {
                list.Add(maxValue);

                int randomStep = new Random().Next(step) + 1;

                maxValue -= randomStep;
            }

            return list;
        }

        public static List<int> GenerateAlmostOrderedIntList(int length, int maxValue)
        {
            List<int> list = new List<int>();

            int maxCopy = maxValue;

            int step = maxValue / length;

            for (int i = length; i > 0; i--)
            {
                list.Add(maxCopy - maxValue);

                int randomStep = new Random().Next(step) + 1;

                maxValue -= randomStep;
            }

            //swap 5% of the items in the list
            for (int i = list.Count - 1; i >= 0; i--)
            {
                int random = new Random().Next(1000);

                if (random <= 25)
                {
                    int num = list[i];

                    if (i < list.Count - 1)
                    {
                        list[i] = list[i + 1];
                        list[i + 1] = num;
                    }
                    else if (i == list.Count - 1)
                    {
                        list[i] = list[i - 1];
                        list[i - 1] = num;
                    }
                }
            }

            return list;
        }

        public static List<int> GenerateRandomIntList(int length, int maxValue)
        {
            List<int> list = new List<int>();

            Random random = new Random();

            for(int i=0; i < length; i++)
            {
                list.Add(random.Next(maxValue));               
            }

            return list;
        }

        public static List<double> GenerateRandomDoubleList(int length, double maxValue)
        {
            List<double> list = new List<double>();

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                list.Add(random.NextDouble()* maxValue);
            }

            return list;
        }

        //static void RegexTest(string input)
        //{
        //    string firstPattern = @"(?<=\.).*";
        //    string secondPattern = @"(?<=\.).*(?=`)";

        //    Match firstResult = Regex.Match(input, firstPattern);

        //    string firstResultString = firstResult.ToString();

        //    Match secondResult = Regex.Match(firstResultString, secondPattern);

        //    Console.WriteLine(secondResult);
        //}

        public static void TestSort<T>(ISortable<T> sort, List<List<T>[]> listTypes, string[] listLengths, List<string> listNames) where T : IComparable<T>
        {
            List<string> output = new List<string>();

            output.Add(FormatSortName(sort.ToString()));
            Console.WriteLine(FormatSortName(sort.ToString()));
            output.Add("");

            for (int i = 0; i < 3; i++)
            {
                List<T>[] currentListType = listTypes[i];
                output.Add(listNames[i]);
                Console.WriteLine(listNames[i]);
                for (int j = 0; j < 5; j++)
                {
                    List<string> times = new List<string>();
                    output.Add(listLengths[j]);
                    Console.WriteLine(listLengths[j]);
                    Console.WriteLine("timing algorithm...");
                    for (int k = 0; k < 11; k++)
                    {
                        List<T> listCopy = new List<T>(currentListType[j]);
                        double totalSeconds = TimeSort<T>(sort, listCopy);
                        if (totalSeconds > 600)
                        {
                            output.Add("Sorting method took too long for given list");
                            Console.WriteLine();
                            Console.WriteLine("Sorting took too long");
                            output.Add("");
                            break;
                        }
                        else
                        {
                            times.Add(totalSeconds.ToString());
                        }
                    }
                    output.Add(string.Join(", ", times));
                    Console.WriteLine();
                    output.Add("");
                }
            }

            WriteOutput(output: output, file: "/Users/greenegunnar/Documents/CIS374/Labs/CIS374-SP22-Lab3/output.txt");
        }

        public static void TestSort(ISortableInt sort, List<List<int>[]> listTypes, string[] listLengths, List<string> listNames)
        {
            List<string> output = new List<string>();

            output.Add(FormatSortName(sort.ToString()));
            Console.WriteLine(FormatSortName(sort.ToString()));
            output.Add("");

            for (int i = 0; i < 3; i++)
            {
                List<int>[] currentListType = listTypes[i];
                output.Add(listNames[i]);
                Console.WriteLine(listNames[i]);
                for (int j = 0; j < 5; j++)
                {
                    List<int> listCopy = currentListType[j];
                    List<string> times = new List<string>();
                    output.Add(listLengths[j]);
                    Console.WriteLine(listLengths[j]);
                    Console.WriteLine("timing algorithm...");
                    for (int k = 0; k < 11; k++)
                    {
                        double totalSeconds = TimeSort(sort, listCopy);
                        if (totalSeconds > 600)
                        {
                            output.Add("Sorting method took too long for given list");
                            Console.WriteLine("Sorting took too long");
                            output.Add("");
                            break;
                        }
                        else
                        {
                            times.Add(totalSeconds.ToString());
                        }
                    }
                    output.Add(string.Join(", ", times));
                    Console.WriteLine();
                    output.Add("");
                }
            }

            WriteOutput(output: output, file: "/Users/greenegunnar/Documents/CIS374/Labs/CIS374-SP22-Lab3/output.txt");
        }

        //use a regex pattern to format output with unnecessary text
        public static string FormatSortName(string input)
        {
            string firstPattern = @"(?<=\.).*";
            string secondPattern = @"(?<=\.).*";

            Match firstResult = Regex.Match(input, firstPattern);

            string firstResultString = firstResult.ToString();

            Match secondResult = Regex.Match(firstResultString, secondPattern);

            string secondResultString = secondResult.ToString();

            return secondResultString;
        }

        //output will be a list of strings, each string represents a separate line in the output file
        static void WriteOutput(List<string> output, string file)
        {
            try
            {
                StreamWriter sw = new StreamWriter(file, true);
                foreach (var item in output)
                {
                    sw.WriteLine(item);
                }
                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception " + e.Message);
            }
            finally
            {
                string regexPattern = @"[^\/]+$";
                string filename = Regex.Match(file, regexPattern).ToString();
                Console.WriteLine($"Output written to file: \"{filename}\"");
            }
        }
    }
}
