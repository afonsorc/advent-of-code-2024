using System;


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

        struct Pos{
            public int x;
            public int y;

            public Pos(int Y, int X){
                y = Y;
                x = X;
            }
        }

        static int PartOne(string[] input){

            int solution = 0;
            Pos[] directions = {new(-1, -1), new(-1, 0), new(-1, 1), new(0, -1), new(0, 1), new(1, -1), new(1, 0), new(1, 1)};   

            for(int y = 0; y < input.Length; y++){
                for(int x = 0; x < input.Length; x++){
                    if(input[y][x] == 'X'){
                        foreach(Pos dir in directions){
                            Pos newPos = new(y + dir.y, x + dir.x);
                            if(IsOutsideBox(newPos, input.Length)){
                                continue;
                            } else if(input[newPos.y][newPos.x] == 'M'){
                                solution += CheckNextLetter(input, newPos, dir, 2);
                            } 
                        }   
                    }
                }
            }
            return solution;
        }


        static int PartTwo(string[] input){
            
            int solution = 0;
            for(int y = 1; y < input.Length - 1; y++){
                for(int x = 1; x < input.Length - 1; x++){
                    if(input[y][x] == 'A'){
                        solution += CheckCrossmas(input, new(y, x));
                    }   
                }
            }
            return solution;
        }

        static bool IsOutsideBox(Pos pos, int length){
            return pos.y < 0 || pos.x < 0 || pos.y >= length || pos.x >= length;
        }

        static int CheckNextLetter(string[] input, Pos current, Pos dir, int letterIndex){

            if(letterIndex > 3){
                return 1;
            }

            char[] xmas = {'X', 'M', 'A', 'S'};
            Pos newPos = new(current.y + dir.y, current.x + dir.x);
            
            if(IsOutsideBox(newPos, input.Length)){
                return 0;
            } else if(input[newPos.y][newPos.x] == xmas[letterIndex]){
                return CheckNextLetter(input, newPos, dir, letterIndex+1);
            }
            return 0;
        }

        static int CheckCrossmas(string[] input, Pos current){
            
            int countM = 0;
            int countS = 0;
            char[] xmas = {'X', 'M', 'A', 'S'};
            Pos[] directions = {new(-1, -1), new(-1, 1), new(1, -1), new(1, 1)};   

            foreach(Pos dir in directions){
                Pos newPos = new(current.y + dir.y, current.x + dir.x);
                Pos oppPos = new(current.y - dir.y, current.x - dir.x);
                countM += Convert.ToInt32(input[newPos.y][newPos.x] == xmas[1] && input[oppPos.y][oppPos.x] != xmas[1]);
                countS += Convert.ToInt32(input[newPos.y][newPos.x] == xmas[3] && input[oppPos.y][oppPos.x] != xmas[3]);
            }
            return Convert.ToInt32(countM == 2 && countS == 2);
        }
    }
}