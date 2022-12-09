var lines = File.ReadAllLines(@"./input-test.txt");
// var lines = File.ReadAllLines(@"./input-test-2.txt");

// Setup
const int noKnots1 = 2;
const int noKnots2 = 10;
var knots1 = new Position[noKnots1];
var knots2 = new Position[noKnots2];

for (var i = 0; i < noKnots1; i++)
    knots1[i] = new Position();

for (var i = 0; i < noKnots2; i++)
    knots2[i] = new Position();

var path1 = new List<Position>();
var path2 = new List<Position>();

// Instructions
foreach (var line in lines)
{
    var lineValues = line.Split(" ");
    var instruction = new Instruction(lineValues[0][0], short.Parse((string)lineValues[1]));

    for (var m = 0; m < instruction.Moves; m++)
    {
        var direction = instruction.Direction switch
        {
            'L' => new Position {X = -1, Y = 0},
            'R' => new Position {X = 1, Y = 0},
            'U' => new Position {X = 0, Y = 1},
            'D' => new Position {X = 0, Y = -1},
            _ => throw new ArgumentOutOfRangeException(),
        };

        // Part 1
        knots1[0].X += direction.X;
        knots1[0].Y += direction.Y;

        for (var i = 1; i < noKnots1; i++)
        {
            var diffX = knots1[i - 1].X - knots1[i].X;
            var diffY = knots1[i - 1].Y - knots1[i].Y;
            
            if (Math.Abs(diffX) > 1 || Math.Abs(diffY) > 1)
            {
                knots1[i].X += diffX switch
                {
                    >= 1 => 1,
                    < 0 => -1,
                    _ => 0,
                };
                knots1[i].Y += diffY switch
                {
                    >= 1 => 1,
                    < 0 => -1,
                    _ => 0,
                };
            }
        }
        
        path1.Add(new Position {X = knots1[1].X, Y = knots1[1].Y});
        
        // Part 2
        knots2[0].X += direction.X;
        knots2[0].Y += direction.Y;

        for (var i = 1; i < noKnots2; i++)
        {
            var diffX = knots2[i - 1].X - knots2[i].X;
            var diffY = knots2[i - 1].Y - knots2[i].Y;
            
            if (Math.Abs(diffX) > 1 || Math.Abs(diffY) > 1)
            {
                knots2[i].X += diffX switch
                {
                    >= 1 => 1,
                    < 0 => -1,
                    _ => 0,
                };
                knots2[i].Y += diffY switch
                {
                    >= 1 => 1,
                    < 0 => -1,
                    _ => 0,
                };
            }
        }
        
        path2.Add(new Position {X = knots2[noKnots2 - 1].X, Y = knots2[noKnots2 - 1].Y});
    }
}

Console.WriteLine($"Part 1: {path1.Select(x => $"{x.X},{x.Y}" ).Distinct().Count()}");
Console.WriteLine($"Part 2: {path2.Select(x => $"{x.X},{x.Y}" ).Distinct().Count()}");

internal class Position
{
    public int X { get; set; }
    public int Y { get; set; }
}

internal record Instruction(char Direction, short Moves);
