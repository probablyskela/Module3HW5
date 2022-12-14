static async Task<string> ReadFile(string path)
{
    return await Task.Run(() => string.Join(string.Empty, File.ReadAllLines(path)));
}

static async Task<string> Concatenate(string separator, IEnumerable<string> paths)
{
    return string.Join(separator, await Task.WhenAll(paths.Select(ReadFile).ToArray()));
}

Console.WriteLine(await Concatenate(" ", new[] { "../../../hello.txt", "../../../world.txt" }));