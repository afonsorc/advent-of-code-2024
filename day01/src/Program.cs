using System;

namespace Day01{
    class Program {
        static void Main(string[] args){

            // read and process input onto array
            string[] input = System.IO.File.ReadAllLines("./input/input.txt");

            // write solutionP
            System.Console.WriteLine("----------------\nPart1: {0}\n----------------", PartOne(input));
            System.Console.WriteLine("----------------\nPart2: {0}\n----------------", PartTwo(input));
            return;
        }


        static int PartOne(string[] input){
            
            int solution = 0;
            int[] left = new int[input.Length];
            int[] right = new int[input.Length];

            for(int i = 0; i < input.Length; i++){
                string[] pair = input[i].Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                left[i] = int.Parse(pair[0]); 
                right[i] = int.Parse(pair[1]);
            }

            Array.Sort(left);
            Array.Sort(right);
            
            for(int i = 0; i < input.Length; i++){
                solution += Math.Abs(right[i] - left[i]);
            }
            return solution;
        }


        static int PartTwo(string[] input){

            int solution = 0;
            int[] left = new int[input.Length];
            int[] right = new int[input.Length];
            Dictionary<int, int> map = new Dictionary<int, int>();

            for(int i = 0; i < input.Length; i++){
                string[] pair = input[i].Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                left[i] = int.Parse(pair[0]); 
                right[i] = int.Parse(pair[1]);
            }

            foreach(int num in right){
                if(map.ContainsKey(num)){
                    map[num]++;
                } else {
                    map.Add(num, 1);
                }
            }

            foreach(int num in left){
                if(map.ContainsKey(num)){
                    solution += num * map[num];
                }
            }

            return solution;
        }
    }
}