using System.Text.RegularExpressions;

var lines = File.ReadAllLines(@"./input-test.txt");

var data = lines
    .Select(line => Regex.Matches(line, @"\d+"))
    .Select(matches =>
        new
        {
            x1 = int.Parse(matches[0].Value),
            y1 = int.Parse(matches[1].Value),
            x2 = int.Parse(matches[2].Value),
            y2 = int.Parse(matches[3].Value),
        })
    .ToList();

var part1 = data.Count(n => (n.x1 <= n.x2 && n.y1 >= n.y2) || (n.x2 <= n.x1 && n.y2 >= n.y1));
var part2 = data.Count(n => n.x1 <= n.y2 && n.y1 >= n.x2);

Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");
