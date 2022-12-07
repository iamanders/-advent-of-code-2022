var lines = File.ReadAllLines(@"./input-test.txt");

var sizes = new Dictionary<string, long>();
var current = new Stack<string>();

foreach (var line in lines)
{
    var command = line.Split(" ");
    
    if (line.StartsWith("$ cd .."))
    {
        current.Pop();
    }
    else if (line.StartsWith("$ cd "))
    {
        current.Push($"{string.Join("", current)}{command[2]}");
    }
    else if (long.TryParse(command[0], out var size) && size > 0)
    {
        foreach (var p in current)
        {
            sizes[p] = sizes.GetValueOrDefault(p) + size;
        }
    }
}

var sizesList = sizes.Values.ToList();
var part1 = sizesList.Where(size => size < 100000).Sum();
var part2 = sizesList.Where(size => size + 70000000 - sizesList.Max() >= 30000000).Min();

Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");
