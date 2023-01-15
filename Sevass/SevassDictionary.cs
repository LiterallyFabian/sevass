using Microsoft.CodeAnalysis.CSharp;

namespace Sevass;

public static class SevassDictionary
{
    /// <summary>
    /// A dictionary that maps a syntax kind to its corresponding sevass keyword.
    /// </summary>
    public static readonly Dictionary<SyntaxKind, string> SyntaxKindToSevass = new()
    {
        {SyntaxKind.BoolKeyword, "bool"},
        {SyntaxKind.ByteKeyword, "byte"},
        {SyntaxKind.SByteKeyword, "sbyte"},
        {SyntaxKind.ShortKeyword, "kort"},
        {SyntaxKind.UShortKeyword, "ukort"},
        {SyntaxKind.IntKeyword, "hel"},
        {SyntaxKind.UIntKeyword, "uhel"},
        {SyntaxKind.LongKeyword, "lång"},
        {SyntaxKind.ULongKeyword, "ulång"},
        {SyntaxKind.FloatKeyword, "flyttal"},
        {SyntaxKind.DoubleKeyword, "dubbel"},
        {SyntaxKind.DecimalKeyword, "decimal"},
        {SyntaxKind.StringKeyword, "sträng"},
        {SyntaxKind.CharKeyword, "tecken"},
        {SyntaxKind.VoidKeyword, "tomhet"},
        {SyntaxKind.ObjectKeyword, "objekt"},
        {SyntaxKind.TypeOfKeyword, "typav"},
        {SyntaxKind.SizeOfKeyword, "storlekav"},
        {SyntaxKind.NullKeyword, "noll"},
        {SyntaxKind.TrueKeyword, "sant"},
        {SyntaxKind.FalseKeyword, "falskt"},
        {SyntaxKind.IfKeyword, "om"},
        {SyntaxKind.ElseKeyword, "annars"},
        {SyntaxKind.WhileKeyword, "medans"},
        {SyntaxKind.ForKeyword, "för"},
        {SyntaxKind.ForEachKeyword, "förvarje"},
        {SyntaxKind.DoKeyword, "gör"},
        {SyntaxKind.SwitchKeyword, "växla"},
        {SyntaxKind.CaseKeyword, "fall"},
        {SyntaxKind.DefaultKeyword, "standard"},
        {SyntaxKind.TryKeyword, "försök"},
        {SyntaxKind.CatchKeyword, "fånga"},
        {SyntaxKind.FinallyKeyword, "slutligen"},
        {SyntaxKind.LockKeyword, "lås"},
        {SyntaxKind.BreakKeyword, "bryt"},
        {SyntaxKind.ContinueKeyword, "fortsätt"},
        {SyntaxKind.ReturnKeyword, "återvänd"},
        {SyntaxKind.ThrowKeyword, "kasta"},
        {SyntaxKind.PublicKeyword, "offentlig"},
        {SyntaxKind.PrivateKeyword, "privat"},
        {SyntaxKind.ProtectedKeyword, "skyddad"},
        {SyntaxKind.InternalKeyword, "intern"},
        {SyntaxKind.StaticKeyword, "statisk"},
        {SyntaxKind.ReadOnlyKeyword, "läsbar"},
        {SyntaxKind.SealedKeyword, "sluten"},
        {SyntaxKind.ConstKeyword, "konstant"},
        {SyntaxKind.FixedKeyword, "fast"},
        {SyntaxKind.StackAllocKeyword, "stackallokering"},
        {SyntaxKind.NewKeyword, "ny"},
        {SyntaxKind.OverrideKeyword, "överskugga"},
        {SyntaxKind.AbstractKeyword, "abstrakt"},
        {SyntaxKind.VirtualKeyword, "virtuell"},
        {SyntaxKind.EventKeyword, "händelse"},
        {SyntaxKind.ExternKeyword, "extern"},
        {SyntaxKind.RefKeyword, "ref"},
        {SyntaxKind.OutKeyword, "ut"},
        {SyntaxKind.InKeyword, "in"},
        {SyntaxKind.IsKeyword, "är"},
        {SyntaxKind.AsKeyword, "som"},
        {SyntaxKind.ParamsKeyword, "parametrar"},
        {SyntaxKind.ThisExpression, "detta"},
        {SyntaxKind.BaseExpression, "bas"},
        {SyntaxKind.NamespaceDeclaration, "namnrymd"},
        {SyntaxKind.UsingDirective, "använder"},
        {SyntaxKind.ClassDeclaration, "klass"},
        {SyntaxKind.StructDeclaration, "struktur"},
        {SyntaxKind.InterfaceDeclaration, "gränssnitt"},
        {SyntaxKind.EnumDeclaration, "enum"},
        {SyntaxKind.GetKeyword, "hämta"},
        {SyntaxKind.SetKeyword, "sätt"},
        {SyntaxKind.AddKeyword, "lägg"},
        {SyntaxKind.RemoveKeyword, "ta"},
    };

    /// <summary>
    /// A dictionary that maps a sevass keyword to its corresponding syntax kind.
    /// </summary>
    public static readonly Dictionary<string, string> SevassToSyntaxKind =
        SyntaxKindToSevass.ToDictionary(x => x.Value, x => SyntaxFacts.GetText(x.Key));
}