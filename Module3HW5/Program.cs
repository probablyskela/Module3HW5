static async Task<string> ReadFile(string path)
{
    return await Task.Run(() => string.Join(string.Empty, File.ReadAllLines(path)));
}

static async Task<string> Concatenate(params string[] paths)
{
    return string.Join(string.Empty, await Task.WhenAll(paths.Select(ReadFile).ToArray()));
}

Console.WriteLine(await Concatenate("../../../hello.txt", "../../../world.txt"));