namespace Esprima.Tests;

#if !NETFRAMEWORK

public class JavaScriptParserTests
{
    /// <summary>
    /// Ensures that we don't regress in stack handling, only test in modern runtime for now
    /// </summary>
    [Fact]
    public void CanHandleDeepNestingWithoutStackOverflow()
    {
        if (OperatingSystem.IsMacOS())
        {
            // stack limit differ quite a lot
            return;
        }

        var parser = new JavaScriptParser(new ParserOptions { MaxAssignmentDepth = 1000 });
#if DEBUG
        const int Depth = 205;
#else
        const int Depth = 520;
#endif
        var input = $"if ({new string('(', Depth)}true{new string(')', Depth)}) {{ }}";
        parser.ParseScript(input);
    }
}

#endif
