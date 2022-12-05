using System.Text.RegularExpressions;

var lines = File.ReadAllLines(@"./input-test.txt");

// Parse moves
var moves = lines
    .Where(line => line.StartsWith("move"))
    .Select(line =>
    {
        var matches = Regex.Matches(line, @"\d+");
        return new
        {
            Quantity = int.Parse(matches[0].Value),
            From = int.Parse(matches[1].Value) - 1,
            To = int.Parse(matches[2].Value) - 1,
        };
    });

// Parse stacks
var stacksCount = Math.Ceiling((double)lines[0].Length / 4);
var stacksEndsAtLine = Array.FindIndex(lines, line => line.StartsWith(" 1 ")) -  1;
var stacks1 = new List<List<char>>();
var stacks2 = new List<List<char>>();

for (var i = 0; i < stacksCount; i++)
{
    stacks1.Add(new List<char>());
    stacks2.Add(new List<char>());
}

foreach (var line in lines.Take(stacksEndsAtLine + 1).Reverse())
{
    for (var i = 0; i < stacksCount; i++)
    {
        var c = line[(i * 4) + 1];
        if (c != ' ')
        {
            stacks1[i].Add(c);
            stacks2[i].Add(c);
        }
    }
}

// Move the crates
foreach (var move in moves)
{
    // Part 1
    var temp = stacks1[move.From].TakeLast(move.Quantity).Reverse().ToList();
    stacks1[move.To].AddRange(temp);
    stacks1[move.From].RemoveRange(stacks1[move.From].Count - move.Quantity, move.Quantity);

    // Part 2
    temp = stacks2[move.From].TakeLast(move.Quantity).ToList();
    stacks2[move.To].AddRange(temp);
    stacks2[move.From].RemoveRange(stacks2[move.From].Count - move.Quantity, move.Quantity);
}

var part1 = string.Join("", stacks1.Select(x => x[^1]));
var part2 = string.Join("", stacks2.Select(x => x[^1]));
Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");
