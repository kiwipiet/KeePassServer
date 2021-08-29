using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeePassServer.Core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var db = Database.Open(@"E:\piete\Documents\Database.kdbx", SecureStringHelper.CreateSecureString("LZp*BRPDj!#ZCVNI3m4TI2h8^%406jx7yb7LyhxqF9AaGap6RAPI04pRJO66V%@n")))
            {
            }
        }
    }
}
