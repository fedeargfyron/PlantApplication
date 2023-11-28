using Application.Helpers;

namespace ApplicationTests.Helpers;

public class EncryptionHelperTests
{
    [Fact]
    public void Encrypt_WhenPasswordDoesntMatch_ReturnsNotEqualPassword()
    {
        // Arrange
        const string key = "pass";
        const string expected = "notmatch";

        // Act
        var actual = EncryptionHelper.Encrypt(key);

        // Assert
        Assert.NotEmpty(actual);
        Assert.NotEqual(expected, actual);
    }

    [Fact]
    public void Encrypt_WhenPasswordMatch_ReturnsEqualPassword()
    {
        // Arrange
        const string key = "pass";
        const string expected = "?O??????k\u0018?w?????\v[??????%\0\u000f????";

        // Act
        var actual = EncryptionHelper.Encrypt(key);

        // Assert
        Assert.NotEmpty(actual);
        Assert.Equal(expected, actual);
    }
}
