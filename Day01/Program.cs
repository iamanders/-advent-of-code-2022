string[] lines;
List<long> elfCalories = new List<long>();
lines = System.IO.File.ReadAllLines(@"./input-test.txt");

int currentElf = 0;
foreach (var line in lines)
{
    if (string.IsNullOrEmpty(line))
    {
        currentElf += 1;
        continue;
    }
    
    if (elfCalories.Count <= currentElf)
        elfCalories.Add(0);

    elfCalories[currentElf] += long.Parse(line);
}

var topElfCalories = elfCalories.Max();
var topThreeElfCalories = elfCalories.OrderByDescending(x => x).Take(3).Sum();

Console.WriteLine($"Top calories is: {topElfCalories}");
Console.WriteLine($"Top three elf calories sum: {topThreeElfCalories}");
