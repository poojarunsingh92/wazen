using Shouldly;
using System.Threading.Tasks;
using WazenCustomer.Infrastructure.EncryptDecrypt;
using Xunit;

namespace WazenCustomer.Application.UnitTests.Helpers
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
