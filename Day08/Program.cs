var lines = File.ReadAllLines(@"./input-test.txt");
var trees = new List<List<short>>();
var part1 = 0;
var part2 = 0;

// Parse input
foreach (var line in lines)
{
    var row = new List<short>();
    for (var i = 0; i < line.Count(); i++)
    {
        row.Add(short.Parse(line[i].ToString()));
    }
    trees.Add(row);
}

// Solve
for (short y = 1; y < trees.Count - 1; y++)
{
    for (short x = 1; x < trees[y].Count - 1; x++)
    {
        part1 += TreeVisible(x, y) ? 1 : 0;
        var score = TreeScore(x, y);
        part2 = score > part2 ? score : part2;
    }
}

bool TreeVisible(short treeX, short treeY)
{
    var treeHeight = trees[treeY][treeX];
    var visible = true;
    
    // Right
    visible = true;
    for (var x = treeX + 1; x < trees[treeY].Count; x++)
    {
        if (trees[treeY][x] >= treeHeight)
            visible = false;
    }
    if (visible) { return true; }
    
    // Left
    visible = true;
    for (var x = treeX - 1; x >= 0; x--)
    {
        if (trees[treeY][x] >= treeHeight)
            visible = false;
    }
    if (visible) { return true; }
    
    // Down
    visible = true;
    for (var y = treeY + 1; y < trees.Count; y++)
    {
        if (trees[y][treeX] >= treeHeight)
            visible = false;
    }
    if (visible) { return true; }
    
    // Up
    visible = true;
    for (var y = treeY - 1; y >= 0; y--)
    {
        if (trees[y][treeX] >= treeHeight)
            visible = false;
    }
    if (visible) { return true; }

    return false;
}

int TreeScore(short treeX, short treeY)
{
    var treeHeight = trees[treeY][treeX];
    var scores = new int[] { 0, 0, 0, 0 };
    
    // Up
    for (var y = treeY - 1; y >= 0; y--)
    {
        scores[0]++;
        if (trees[y][treeX] >= treeHeight)
            break;
    }
    
    // Left
    for (var x = treeX - 1; x >= 0; x--)
    {
        scores[1]++;
        if (trees[treeY][x] >= treeHeight)
            break;
    }

    // Right
    for (var x = treeX + 1; x < trees[treeY].Count; x++)
    {
        scores[2]++;
        if (trees[treeY][x] >= treeHeight)
            break;
    }

    // Down
    for (var y = treeY + 1; y < trees.Count; y++)
    {
        scores[3]++;
        if (trees[y][treeX] >= treeHeight)
            break;
    }
    
    return scores.Aggregate((carry, item) => carry * item);
}

Console.WriteLine($"Part 1: {part1 + ((trees[0].Count() - 2) * 2) + (trees.Count() * 2)}");
Console.WriteLine($"Part 2: {part2}");
