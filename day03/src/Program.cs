using System;
using System.Text.RegularExpressions;

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
            char[] chars = {',', '(', ')'};
            string pattern = @"mul\(\d+,\d+\)";
            Regex regex = new Regex(pattern);

            foreach(string line in input){
                MatchCollection matches = regex.Matches(line);

                foreach(Match item in matches){
                    string instruction = Convert.ToString(item);
                    string[] pair = instruction.Split(chars);
                    solution += MultInstruction(pair[1], pair[2]);
                }
            }
            return solution;
        }


        static int PartTwo(string[] input){
            
            int solution = 0;
            bool doMul = true;
            char[] chars = {',', '(', ')'};
            string pattern = @"(do\(\)|don't\(\)|mul\(\d+,\d+\))";
            Regex regex = new Regex(pattern);

            foreach(string line in input){
                MatchCollection matches = regex.Matches(line);

                foreach(Match item in matches){
                    string instruction = Convert.ToString(item);
                    if(instruction == "do()"){
                        doMul = true;
                    } else if(instruction == "don't()") {
                        doMul = false;
                    } else if(doMul){
                        string[] pair = instruction.Split(chars);
                        solution += MultInstruction(pair[1], pair[2]);
                    }
                }
            }
            return solution;
        }

        static int MultInstruction(string a, string b){
            return Convert.ToInt32(a) * Convert.ToInt32(b);
        }
    }
}