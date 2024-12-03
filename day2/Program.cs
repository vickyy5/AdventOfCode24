
class Program 
{
    public static void Main (string[] args) {

        //Part1();
        Part2();

    }

    public static void Part1()
    {
        int safe =0;
        
        foreach ( string line in File.ReadLines("./inputs/part1_test.txt"))
        {
            List<int> nums = line.Split(" ")
                        .Select(num => int.Parse(num))
                        .ToList();
        



            var m = ( inc: false, dec:false );

            var cs=true;            
            for(int i=0; i < nums.Count - 1; i++)
            {
                int diff = int.Abs(nums[i] - nums[i+1]);

                if (diff > 3 || diff < 1){
                    cs = false;
                    break;
                }

                if ( nums[i] - nums[i+1] < 0 ) {m.inc = true;}
                if ( nums[i] - nums[i+1] > 0 ) {m.dec = true;}

                if (m.inc && m.dec){
                    cs=false;
                    break;
                }
                
            }

            if (cs)
            {
                safe +=1;
            }

        }

        Console.WriteLine(safe);

    }

    public static void Part2()
    {
        int s = 0;
        foreach(string line in File.ReadLines("./inputs/part1.txt"))
        {
            List<int> nums = line.Split(" ")
                        .Select(num => int.Parse(num))
                        .ToList();
            bool safe = false;
            var m = (inc: false, dec: false);
            
            safe = true;
            for(int i = 0; i < nums.Count - 1; i++)
            {
                if (!IsSafe(nums[i], nums[i+1], ref m))
                {
                    safe = false;
                    break;
                }
            }
            
            if (!safe)
            {
                for(int j = 0; j < nums.Count; j++)
                {
                    List<int> nums2 = new List<int>(nums);
                    nums2.RemoveAt(j);
                    m = (inc: false, dec: false);
                    safe = true;
                    
                    for(int i = 0; i < nums2.Count - 1; i++)
                    {
                        if (!IsSafe(nums2[i], nums2[i+1], ref m))
                        {
                            safe = false;
                            break;
                        }
                    }
                    
                    if (safe) break;
                }
            }
            
            if(safe)
            {
                s += 1;
            }
        }
        Console.WriteLine(s);
    }


    public static bool IsSafe(int current, int next, ref (bool inc, bool dec )m )
    {

        int diff = Math.Abs(current-next);

        if ( current - next < 0 ) {m.inc = true;}
        if ( current - next > 0 ) {m.dec = true;}
        
        if (( m.inc && m.dec) || (diff > 3 || diff <1 ) ){
            return false;
        }

        return true;

    }

}