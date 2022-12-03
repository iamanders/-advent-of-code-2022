int GetPrioritySum(IEnumerable<IEnumerable<char>> input) =>
    input
        .First()
        .Where(c => input.All(line => line.Contains(c)))
        .Select(c => CharValue(c))
        .First();

int CharValue(char c) =>
    c < 'a' ? c - 'A' + 27 : c - 'a' + 1;

var lines = File.ReadAllLines(@"./input-test.txt");

var a = lines
    .Select(line => line.Chunk(line.Length / 2))
    .Select(GetPrioritySum)
    .Sum();

var b = lines
    .Chunk(3)
    .Select(GetPrioritySum)
    .Sum();

Console.WriteLine($"A: {a}");
Console.WriteLine($"B: {b}");
