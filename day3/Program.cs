using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

class Program
{
    public static void Main(string[] args)
    {
        //Part1();
        Part2();
    }


    public static void Part1()
    {
        int total=0;

        foreach(string line in File.ReadLines("./inputs/part1.txt"))
        {
            //Console.WriteLine(line);
            string pattern = @"mul\(\d{1,3},\d{1,3}\)";
            
            MatchCollection matches = Regex.Matches(line,pattern);

            foreach (Match match in matches)
            {
                string d_patt = @"(\d{1,3})";
                MatchCollection muls = Regex.Matches(match.ToString(), d_patt);

                int result = muls.Cast<Match>()
                                 .Select(m => int.Parse(m.Value))
                                 .Aggregate((a, b) => a * b);                

                total += result;                
            }

        }

        Console.WriteLine(total);

    }


    public static void Part2()
    {
        string file = File.ReadAllText("./inputs/part1.txt").Replace("\n","");

        //Console.WriteLine(file);

        string pattern1 = @"do\(\)";
        string pattern2 = @"don't\(\)";


        string r1 = Regex.Replace(file, pattern1, "\n"+pattern1  );
        string r2 = Regex.Replace(r1, pattern2, "\n"+pattern2  );

        var lines = r2.Split("\n");
        var filteredLines = lines.Where(line => !line.Contains("don't")).ToArray();


        string pattern = @"mul\(\d{1,3},\d{1,3}\)";
        int total=0; 
        foreach(string line in filteredLines)
        {
            MatchCollection matches = Regex.Matches(line,pattern);
            foreach (Match match in matches)
            {
                string d_patt = @"(\d{1,3})";
                MatchCollection muls = Regex.Matches(match.ToString(), d_patt);

                int result = muls.Cast<Match>()
                                 .Select(m => int.Parse(m.Value))
                                 .Aggregate((a, b) => a * b);                

                total += result;                
            }
        }


        //Console.WriteLine(string.Join("\n", filteredLines));
        //Console.WriteLine(r2);

        Console.WriteLine(total);

    }

}