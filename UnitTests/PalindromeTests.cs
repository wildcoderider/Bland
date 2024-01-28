using BlandGroup;

namespace UnitTests;

public class PalindromeTests
{
    [Fact]
    public void TestIsPalindrome_Word()
    {
        Assert.True(PalindromeChecker.IsPalindrome("Deleveled"));
        Assert.False(PalindromeChecker.IsPalindrome("NotPalindrome"));
    }

    [Fact]
    public void TestIsPalindrome_Number()
    {
        Assert.True(PalindromeChecker.IsPalindrome("12321"));
        Assert.True(PalindromeChecker.IsPalindrome("123 21"));
        Assert.False(PalindromeChecker.IsPalindrome("12345"));
    }
}
