var lines = File.ReadAllLines(@"./input-test.txt");

int PrioritySum(IEnumerable<IEnumerable<char>> input) =>
    input
        .First()
        .Where(c => input.All(line => line.Contains(c)))
        .Select(c => CharValue(c))
        .First();

int CharValue(char c) =>
    c < 97 ? c - 65 + 27 : c - 97 + 1;

var a = lines
    .Select(line => line.Chunk(line.Length / 2))
    .Select(PrioritySum)
    .Sum();

var b = lines
    .Chunk(3)
    .Select(PrioritySum)
    .Sum();

Console.WriteLine($"A: {a}");
Console.WriteLine($"B: {b}");
