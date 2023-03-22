using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sevass;

/// <summary>
/// The SevassRewriter converts Sevass code to C# code and vice versa. It uses a dictionary to map Sevass keywords to C# keywords.
/// </summary>
public class SevassRewriter
{
    public static string ConvertSevassToCSharp(string sevassCode)
    {
        // match any of the sevass keywords, but only when they are not part of a class name or string
        Regex sevassRegex = new Regex(@"(?<![\""'])(?<![\p{L}_])(" + string.Join("|", SevassDictionary.SevassToSyntaxKind.Keys) + @")(?![\p{L}_])(?![\""'])");


        // replace all matches of the regular expression pattern with the corresponding C# keyword
        string csharpCode = sevassRegex.Replace(sevassCode, match => SevassDictionary.SevassToSyntaxKind[match.Value]);
        csharpCode = csharpCode.Replace("Huvud", "Main");

        return csharpCode;
    }


    public static string ConvertCSharpToSevass(string csharpCode)
    {
        // Create a SyntaxTree from the code
        SyntaxTree tree = CSharpSyntaxTree.ParseText(csharpCode);

        // Get the root node of the tree
        SyntaxNode root = tree.GetRoot();

        // replace all tokens in the tree
        string sevass = "";
        foreach (SyntaxToken token in root.DescendantTokens())
        {
            bool hasKey = SevassDictionary.SyntaxKindToSevass.ContainsKey(token.Kind());

            if (hasKey)
            {
                sevass += token.LeadingTrivia.ToFullString() + SevassDictionary.SyntaxKindToSevass[token.Kind()] +
                          token.TrailingTrivia.ToFullString();
            }
            else
            {
                sevass += token.LeadingTrivia.ToFullString() + token.Text + token.TrailingTrivia.ToFullString();
            }

            //Console.WriteLine($"{token.Text} - {token.Kind()}");
        }

        return sevass;
    }
}