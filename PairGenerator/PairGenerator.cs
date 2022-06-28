﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PairGenerator
{
    class PairGenerator
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine(" \n** Get pairs for pair programming assignment ** \n\n");

            string path = @"C:\Files\List.txt";
            var names = ReadFile(path);

            if (names != null)
                ListPairs(names);

            bool result = await WriteStuff(names, path);

        }

        public static void ListPairs(string[] names)
        {
            if (names != null)
            {
                Random r = new Random();
                names = names.OrderBy(x => r.Next()).ToArray();

                for (int i = 0; i < names.Length; i++)
                {
                    Console.Write(names[i].PadRight(10).PadLeft(11));
                    if (i % 2 == 0)
                    {
                        Console.Write(" ");
                        continue;
                    }
                    Console.WriteLine("");
                }
            }
       }

        public static string[] ReadFile(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);

                if (lines.Length == 0)
                {
                    Console.WriteLine("Error: No names in file");
                    return null;
                }
                return lines;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: File not found ");
                return null;
            }
        }

        public static bool WriteStuff(string[] names, string fileName)
        {
            await File.WriteAllLines(fileName, names);
            
            return true;
        }
    }
}
