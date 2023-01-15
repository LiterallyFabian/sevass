using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Sevass;

public class SevassRewriter
{
    public static string ConvertSevassToCSharp(string sevassCode)
    {
        // Iterate through the dictionary and create a regular expression pattern
        // that matches any of the sevass keywords
        var sevassRegex = new Regex(string.Join("|", SevassDictionary.SevassToSyntaxKind.Keys));

        // Use the Replace method to replace all matches of the regular expression pattern
        // with the corresponding C# keyword
        string csharpCode = sevassRegex.Replace(sevassCode, match => SevassDictionary.SevassToSyntaxKind[match.Value]);

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
        }

        return sevass;
    }
}