using RealityDataLibrary.HumanAuth;

namespace SFSimulatorModuleUnitTest
{
    [TestClass]
    public class HumanAuth
    {
        [TestMethod]
        public void AuthInformationConstructTest()
        {
            string testCardNumber = "2223-33444-22233";
            HumanBasicInformation humanBasicInformation = new HumanBasicInformation();
            humanBasicInformation.birthDay = "1960-05-20";
            humanBasicInformation.address = "okinawaken ";
            humanBasicInformation.registerName = "tanaka yuuhei";
            AuthInformation authInformation = new AuthInformation(testCardNumber, humanBasicInformation);
            Assert.AreEqual(authInformation.GetCardNumber(), testCardNumber);
            Assert.AreEqual(authInformation.GetHumanBasicInformation().birthDay, humanBasicInformation.birthDay);
            Assert.AreEqual(authInformation.GetHumanBasicInformation().address, humanBasicInformation.address);
            Assert.AreEqual(authInformation.GetHumanBasicInformation().registerName, humanBasicInformation.registerName);


        }
    }
}