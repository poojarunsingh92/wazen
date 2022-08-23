using Shouldly;
using System.Threading.Tasks;
using WazenTransactions.Infrastructure.EncryptDecrypt;
using Xunit;

namespace WazenTransactions.Application.UnitTests.Helpers
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
