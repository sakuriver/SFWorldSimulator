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
        public void TestFinanceVolumeConstruct(){
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

    [TestClass]
    public class TestHumanFinance
    {

        [TestMethod]
        public void TestHumanFinanceConstruct()
        {

            long volumejp = 20004555;
            Money moneyjp = new Money();
            moneyjp._name = "円";
            moneyjp._code = "jp";
            FinanceVolume financeVolumejp = new FinanceVolume(volumejp, moneyjp);
            long volumeus = 200004555;
            Money moneyus = new Money();
            moneyus._name = "ドル";
            moneyus._code = "us";
            FinanceVolume financeVolumeus = new FinanceVolume(volumeus, moneyus);

            List<FinanceVolume> financeVolumeResult = new List<FinanceVolume>();
            financeVolumeResult.Add(financeVolumejp);
            financeVolumeResult.Add(financeVolumeus);

            HumanFinance humanFinance = new HumanFinance();
            humanFinance.FinanceVolumeAdd(financeVolumejp);
            humanFinance.FinanceVolumeAdd(financeVolumeus);

            Assert.AreEqual(financeVolumeResult.Count, humanFinance.GetFinanceVolumes().Count);
        }

    }
}
