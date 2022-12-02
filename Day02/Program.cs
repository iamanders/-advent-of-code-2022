var lines = File.ReadAllLines(@"./input.txt");

var scores = new Dictionary<string, (short scoreA, short scoreB)>
{
    { "A X", (4, 3) },
    { "A Y", (8, 4) },
    { "A Z", (3, 8) },

    { "B X", (1, 1) },
    { "B Y", (5, 5) },
    { "B Z", (9, 9) },

    { "C X", (7, 2) },
    { "C Y", (2, 6) },
    { "C Z", (6, 7) },
};

long scoreA = lines.Sum(x => scores.First(y => y.Key == x).Value.scoreA);
long scoreB = lines.Sum(x => scores.First(y => y.Key == x).Value.scoreB);

Console.WriteLine($"A: {scoreA}");
Console.WriteLine($"B: {scoreB}");
