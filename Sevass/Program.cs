using System.Collections.Immutable;
using System.Diagnostics;
using System;
using System.IO;
using System.Reflection;

namespace Sevass;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: sevass [build|translate] <path>");
            return;
        }

        string command = args[0];
        string path = args[1];

        // check if path is a valid file
        if (!File.Exists(path))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("File not found");
            Console.ResetColor();
            return;
        }

        switch (command)
        {
            case "build":
            case "bygg":
                Build(path);
                break;
            case "translate":
            case "översätt":
                Translate(path);
                break;
            case "run":
            case "kör":
                Run(path);
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Unknown command: {command}");
                Console.ResetColor();
                break;
        }
    }

    private static void Translate(string path)
    {
        string text = File.ReadAllText(path);

        if (Path.GetExtension(path) == ".cs")
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Translating C# into to Sevass...");
            Console.ResetColor();

            // convert to .cv file
            string newPath = Path.ChangeExtension(path, ".cv");
            string sevassText = SevassRewriter.ConvertCSharpToSevass(text);
            File.WriteAllText(newPath, SevassRewriter.ConvertCSharpToSevass(sevassText));
        }
        else if (Path.GetExtension(path) == ".cv")
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Translating Sevass into to C#...");
            Console.ResetColor();

            string newPath = Path.ChangeExtension(path, ".cs");
            string csharpText = SevassRewriter.ConvertSevassToCSharp(text);
            File.WriteAllText(newPath, SevassRewriter.ConvertSevassToCSharp(csharpText));
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("File extension not supported, exiting...");
            Console.ResetColor();
            return;
        }
    }

    /// <summary>
    /// Builds a Sevass file into an executable.
    /// </summary>
    /// <param name="path">The path to the Sevass file.</param>
    /// <returns>True if the build succeeded, false otherwise.</returns>
    public static bool Build(string path)
    {
        if (Path.GetExtension(path) != ".cv")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("File extension not supported, exiting...");
            return false;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Building Sevass into an executable...");
        Console.ResetColor();

        // convert to .cs file
        string newPath = Path.GetTempPath() + Path.GetFileNameWithoutExtension(path) + ".cs";
        string text = File.ReadAllText(path);
        string csharpText = SevassRewriter.ConvertSevassToCSharp(text);
        File.WriteAllText(newPath, csharpText);

        // add the sevass wrapper to the file
        string assemblyPath = Assembly.GetExecutingAssembly().Location;
        string wrapperPath = Path.GetDirectoryName(assemblyPath) + "/SevassWrapper.cs";

        Console.WriteLine("Converted Sevass successfully...");
        Console.WriteLine("Running csc...");

        // run csc to compile the file to an exe
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "csc",
            Arguments = "/out:" + Path.GetFileNameWithoutExtension(path) + ".exe " + newPath + " " + wrapperPath,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };
        
        Console.WriteLine("Command: " + startInfo.FileName + " " + startInfo.Arguments + "");

        Process? process = Process.Start(startInfo);
        if (process == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed to start build process");
            return false;
        }

        process.WaitForExit();
        Console.WriteLine(process.StandardOutput.ReadToEnd());
        Console.WriteLine(process.StandardError.ReadToEnd());

        if (process.ExitCode != 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Build failed");
            Console.ResetColor();
            return false;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Build succeeded");
            Console.ResetColor();
            return true;
        }
    }

    private static void Run(string path)
    {
        // build the file
        if (!Build(path))
            return;

        // run the file
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = Path.GetFileNameWithoutExtension(path) + ".exe",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };

        Process? process = Process.Start(startInfo);

        if (process == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed to start build process");
            return;
        }

        process.WaitForExit();
        Console.WriteLine(process.StandardOutput.ReadToEnd());
        Console.WriteLine(process.StandardError.ReadToEnd());
    }
}