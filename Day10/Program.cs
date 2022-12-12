var lines = File.ReadAllLines(@"./input-test.txt");

var cycleCount = 0;
var signal = 0;
var display = "";
var x = 1;

foreach (var line in lines)
{
    var xOriginal = x;
    var commandCycles = line == "noop" ? 1 : 2;

    if (line.StartsWith("addx"))
    {
        x += int.Parse(line[5..]);
    }
    
    for (var i = 0; i < commandCycles; i++)
    {
        cycleCount++;
        
        var middle = new[] { xOriginal - 1, xOriginal, xOriginal + 1 };
        display += middle.Contains((cycleCount - 1) % 40) ? "#" : " ";
        display += ((cycleCount) % 40 == 0) ? '\n' : "";

        if ((cycleCount - 20) % 40 == 0)
        {
            signal += cycleCount * xOriginal;
        }
    }
}

Console.WriteLine($"Part 1: {signal}");
Console.WriteLine($"Part 2:\n {display}");
