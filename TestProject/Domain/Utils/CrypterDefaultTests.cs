using Domain.Utils;

namespace TestProject.Domain.Ports;

[TestFixture]
public class CrypterDefaultTests
{



    [Test]
    public void EncriptText_WithStringValid_ReturnsString()
    {
        var stringValid = "fantasycommunity.reservar@gmail.com";

        var result = CrypterDefault.Encrypt(stringValid);

        Assert.That(result, !Is.Null);
    }

    [Test]
    public void DesencriptText_WithStringValid_ReturnsString()
    {
        var stringValid = "Uafj6cA0vMLBEGdP23UyVfRefWfRD8HSik8Vc2eguYdeZ6xmKtg6Bbkvbz/PtXe96SS9fYA5/WZ6ba9Z9pB3Gw==";

        var result = CrypterDefault.Decrypt(stringValid);

        Assert.That(result, !Is.Null);
    }
}
