using System;
using System.Runtime.InteropServices;


namespace Base{
    class Program {
        static void Main(string[] args){

            // read and process input onto array
            string[] input = System.IO.File.ReadAllLines("./input/input.txt");

            // write solutions
            System.Console.WriteLine("----------------\nPart1: {0}\n----------------", PartOne(input));
            System.Console.WriteLine("----------------\nPart2: {0}\n----------------", PartTwo(input));
            return;
        }


        static int PartOne(string[] input){

            int solution = 0;
            foreach(string line in input){
                int[] report = line.Split(' ').Select(int.Parse).ToArray();
                int sign = GetReportSort(report);

                if(IsValidReport(report, sign)){
                    solution++;
                    continue;
                }
            }
            return solution;
        }


        static int PartTwo(string[] input){
            
            int solution = 0;
            foreach(string line in input){
                int[] report = line.Split(' ').Select(int.Parse).ToArray();
                int sign = GetReportSort(report);

                if(IsValidReport(report, GetReportSort(report))){
                    solution++;
                    continue;
                }

                for(int i = 0; i < report.Length - 1; i++){
                    if(!IsValidPair(report[i], report[i + 1], sign)){
                        int[] reportA = report[0..i].Concat(report[(i + 1)..]).ToArray();
                        int[] reportB = report[0..(i+1)].Concat(report[(i + 2)..]).ToArray();
                        if(IsValidReport(reportA, sign) || IsValidReport(reportB, sign)){
                            solution++;
                        }
                        break;
                    }
                }
            }
            return solution;
        }

        static bool IsValidPair(int a, int b, int signal){
            return Math.Sign(b - a) == signal && Math.Abs(a - b) <= 3 && signal != 0;
        }

        static bool IsValidReport(int[] report, int signal){
            for(int i = 0; i < report.Length - 1; i++){
                if(!IsValidPair(report[i], report[i + 1], signal)){
                    return false;
                }
            }
            return true;
        }

        static int GetReportSort(int[] report){
            int increasing = 0;
            int decreasing = 0;
            for(int i = 0; i < report.Length - 1; i++){
                increasing += Convert.ToInt32(report[i + 1] > report[i]);
                decreasing += Convert.ToInt32(report[i + 1] < report[i]);
            }
            return Math.Sign(increasing - decreasing);
        }
    }
}