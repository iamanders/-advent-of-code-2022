var line = File.ReadAllText(@"./input-test.txt");

int? FindMarker(int markerSize)
{
    for (var i = markerSize - 1; i < line.Length; i++)
    {
        var marker = line.Substring(i - (markerSize - 1), markerSize);
        if (marker.Distinct().Count() >= markerSize)
            return i + 1;
    }
    return null;
}

Console.WriteLine($"A: {FindMarker(4)}");
Console.WriteLine($"B: {FindMarker(14)}");
