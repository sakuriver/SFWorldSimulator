using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityDataLibrary.Finance
{
    /// <summary>
    /// 世界内で個人が保有している財務情報
    /// </summary>
    public class HumanFinance
    {
        
        /// <summary>
        /// 現在通貨を持っている一覧情報
        /// </summary>
        private List<FinanceVolume> financeVolumes= new List<FinanceVolume>();

        /// <summary>
        /// 各通貨それぞれいくら持っているかを取得できる
        /// </summary>
        /// <returns>各通貨ごとの保有一覧</returns>
        public List<FinanceVolume> GetHumanFinances() {
            return financeVolumes;
        }
    }

    /// <summary>
    /// 通貨ごとの保有情報
    /// </summary>
    public class FinanceVolume
    {
        /// <summary>
        /// いくら持っているか
        /// </summary>
        private Int64 volumeNum;
        
        /// <summary>
        /// 通貨情報
        /// </summary>
        private Money money;

        /// <summary>
        /// アプリ起動時に通貨情報を設定
        /// </summary>
        /// <param name="volumeNum">通貨量</param>
        /// <param name="money">通貨情報</param>
        public FinanceVolume(long volumeNum, Money money)
        {
            this.volumeNum = volumeNum;
            this.money = money;
        }

        /// <summary>
        /// 現在の通貨量を取得する
        /// </summary>
        /// <returns>通貨量</returns>
        public Int64 GetVolumeNum()
        {
            return volumeNum;
        }

        /// <summary>
        /// 通貨情報を取得する
        /// </summary>
        /// <returns>通貨情報</returns>
        public Money GetMoneyInfo()
        {
            return money;
        }


    }
}
