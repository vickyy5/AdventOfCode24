
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


        int s=0;

        s = left.Zip(right)
            .Sum(pair => int.Abs(pair.First-pair.Second));

        //Console.WriteLine(string.Join(" ",left));
        //Console.WriteLine(string.Join(" ",right));
        Console.WriteLine(sum);
        Console.WriteLine(s);

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


        var s = left.Distinct()
                    .Sum(x => x * right.Count(y => x==y));        

        Console.WriteLine(s);
        Console.WriteLine(sum);
    }

}