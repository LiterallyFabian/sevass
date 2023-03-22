using System.Collections.Immutable;
using System.Diagnostics;

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
            if (args[0] == "build" || args[0] == "bygg") // build command, build the project and return
            {
                Build(args);
                return;
            }

            // non-build command, continue converting

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
            string sevassText = SevassRewriter.ConvertCSharpToSevass(text);
            //File.WriteAllText(newPath, SevassRewriter.ConvertCSharpToSevass(sevassText));
            Console.Write(sevassText);
        }
        else if (Path.GetExtension(path) == ".cv")
        {
            string newPath = Path.ChangeExtension(path, ".cs");
            string csharpText = SevassRewriter.ConvertSevassToCSharp(text);
            //File.WriteAllText(newPath, SevassRewriter.ConvertSevassToCSharp(csharpText));
            Console.Write(csharpText);
        }
        else
        {
            Console.WriteLine("File extension not supported, exiting...");
        }
    }

    public static void Build(string[] args)
    {
        string path = args[1];
        // convert to .cs file
        string newPath = Path.GetTempPath() + Path.GetFileNameWithoutExtension(path) + ".cs";
        string text = File.ReadAllText(path);
        string csharpText = SevassRewriter.ConvertSevassToCSharp(text);
        File.WriteAllText(newPath, csharpText);

        // run csc to compile the file to an exe
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "csc",
            Arguments = "/out:" + Path.GetFileNameWithoutExtension(path) + ".exe " + newPath,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        Process? process = Process.Start(startInfo);

        if (process == null)
        {
            Console.WriteLine("Failed to start process");
            return;
        }

        process.WaitForExit();
        Console.WriteLine(process.StandardOutput.ReadToEnd());
        Console.WriteLine(process.StandardError.ReadToEnd());
    }
}