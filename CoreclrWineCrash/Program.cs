using Mono.Cecil;

var assemblies = new List<AssemblyDefinition>();

var defaultAssemblyResolver = new DefaultAssemblyResolver();
var readerParameters = new ReaderParameters
{
    AssemblyResolver = defaultAssemblyResolver,
};
defaultAssemblyResolver.AddSearchDirectory("dummy");

foreach (var file in Directory.GetFiles("dummy", "*.dll", SearchOption.TopDirectoryOnly))
{
    assemblies.Add(AssemblyDefinition.ReadAssembly(file, readerParameters));
}

Parallel.ForEach(assemblies, a =>
{
    try
    {
        // a.Write("test/" + a.MainModule!.Name);
        var outputStream = new MemoryStream();
        a.Write(outputStream);
    }
    catch (Exception e)
    {
        Console.WriteLine("Failed to write " + a.Name + " " + e);
        // throw;
    }
});
