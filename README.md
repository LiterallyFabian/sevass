# S#, Sevass

S#, pronounced "se-vass" is a C# dialect where everything is in Swedish. 

![image](https://user-images.githubusercontent.com/47401343/212559687-8c203051-3771-4b25-92cc-9abd7ae0a4ad.png)

## Structure
### [SevassRewriter.cs](Sevass/SevassRewriter.cs)
The Sevass rewriter class uses the [Roslyn .NET compiler](https://github.com/dotnet/roslyn) API to [tokenize](https://code.visualstudio.com/api/language-extensions/syntax-highlight-guide#tokenization) C# code and translate it into Sevass. It can also translate Sevass back into C# code, which is required for running the program.

### [SevassVSC](SevassVSC)
SevassVSC is a language extension for Visual Studio Code based on the extension templates by [Yeoman](https://yeoman.io/) that uses a modified version of the TextMate grammar directly from [dotnet/csharp-tmLanguage](https://github.com/dotnet/csharp-tmLanguage).

## Installation 
