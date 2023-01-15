namespace Sevass;

class Program
{
    static void Main(string[] args)
    {
        string? path;

        if (args.Length == 0)
        {
            Console.Write("Enter path: ");
            path = Console.ReadLine();
            path = path.Trim('"');
        }
        else
        {
            path = args[0];
        }

        if (!File.Exists(path))
        {
            Console.WriteLine("File not found, exiting...");
            return;
        }

        string text = File.ReadAllText(path);

        if (Path.GetExtension(path) == ".cs")
        {
            // convert to .cv file
            string newPath = Path.ChangeExtension(path, ".cv");
            File.WriteAllText(newPath, SevassRewriter.ConvertCSharpToSevass(text));
        }
        else if (Path.GetExtension(path) == ".cv")
        {
            string newPath = Path.ChangeExtension(path, ".cs");
            File.WriteAllText(newPath, SevassRewriter.ConvertSevassToCSharp(text));
        }
        else
        {
            Console.WriteLine("File extension not supported, exiting...");
        }
    }
}