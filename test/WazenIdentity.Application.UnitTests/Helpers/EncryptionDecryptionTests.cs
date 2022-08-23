using Shouldly;
using System.Threading.Tasks;
using WazenIdentity.Infrastructure.EncryptDecrypt;
using Xunit;

namespace WazenIdentity.Application.UnitTests.Helpers
{
    public class EncryptionDecryptionTests
    {
        [Fact]
        public void EncryptDecrypt()
        {
            string originalString = "Test";

            string encryptedString = EncryptionDecryption.EncryptString(originalString);
            string decryptedString = EncryptionDecryption.DecryptString(encryptedString);

            decryptedString.ShouldBeEquivalentTo(originalString);
        }
    }
}
