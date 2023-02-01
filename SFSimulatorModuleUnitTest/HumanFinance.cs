using RealityDataLibrary.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFSimulatorModuleUnitTest
{
    [TestClass]
    public class TestFinanceVolume
    {
        [TestMethod]
        public void Testa(){
            long volume = 20004555;
            Money money = new Money();
            money._name = "円";
            money._code = "jp";
            FinanceVolume financeVolume = new FinanceVolume(volume, money);
            Assert.AreEqual(financeVolume.GetVolumeNum(), volume);
            Assert.AreEqual(financeVolume.GetMoneyInfo()._name, money._name);
            Assert.AreEqual(financeVolume.GetMoneyInfo()._code, money._code);

        }
    }
}
