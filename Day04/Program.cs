using System.Text.RegularExpressions;

var lines = File.ReadAllLines(@"./input-test.txt");

var part1 = 0;
var part2 = 0;
foreach (var line in lines)
{
    var n = Regex.Matches(line, @"(\d)+");
    var x1 = int.Parse(n[0].Value);
    var y1 = int.Parse(n[1].Value);
    var x2 = int.Parse(n[2].Value);
    var y2 = int.Parse(n[3].Value);
    
    part1 += ((x1 <= x2 && y1 >= y2) || (x2 <= x1 && y2 >= y1)) ? 1 : 0;
    part2 += x1 <= y2 && y1 >= x2 ? 1 : 0;
}

Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");
