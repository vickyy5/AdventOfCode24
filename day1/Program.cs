using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection.Emit;

class Program {

    public static void Main (string[] args){
        
        //Part1();
        Part2();

    }

    public static void Part1(){

        List<int> left = new List<int>();
        List<int> right = new List<int>();

        int sum=0;

        foreach( string line in File.ReadLines("./inputs/part1.txt")){
            
            string[] nums = line.Split("  ");

            left.Add(int.Parse(nums[0])); 
            right.Add(int.Parse(nums[1])); 
        }

        left.Sort();
        right.Sort();

        foreach( var (l,r) in left.Zip(right) ){
                sum += int.Abs(l-r);
        }


        //Console.WriteLine(string.Join(" ",left));
        //Console.WriteLine(string.Join(" ",right));
        Console.WriteLine(sum);

    }

    public static void Part2(){

        List<int> left = new List<int>();
        List<int> right = new List<int>();

        int sum=0;

        foreach( string line in File.ReadLines("./inputs/part1.txt")){
            
            string[] nums = line.Split("  ");

            left.Add(int.Parse(nums[0])); 
            right.Add(int.Parse(nums[1])); 
        }


        foreach( int x in left)
        {
            var times = right.Count(num => num == x);
            sum += x * times; 
        }

        Console.WriteLine(sum);
    }

}