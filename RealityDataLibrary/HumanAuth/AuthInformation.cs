using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityDataLibrary.HumanAuth
{


    /// <summary>
    /// 認証関連で使うデバイスクラス
    /// カードやQRコードなど個別の場合に、継承をする
    /// </summary>
    public class RegisterDevice {
        public AuthInformation authInformation;
        public virtual AuthInformation DeviceDraw() {
            return authInformation;
        }
    }


    /// <summary>
    /// 認証情報
    /// </summary>
    public class AuthInformation
    {
        /// <summary>
        /// カード番号
        /// </summary>
        private string cardNumber;

        /// <summary>
        /// 登録済みの基本情報
        /// </summary>
        private HumanBasicInformation humanBasicInformation;

        public AuthInformation(string _cardNumber, HumanBasicInformation _humanBasicInformation)
        {
            cardNumber = _cardNumber;
            humanBasicInformation = _humanBasicInformation;            
        }

        /// <summary>
        /// カード番号を返却する
        /// </summary>
        /// <returns>表示用に使うカード番号</returns>
        public string GetCardNumber() {
            return cardNumber;
        }

        /// <summary>
        /// 人物名など、実際の人が認証に使う情報を取得する
        /// </summary>
        /// <returns>カードに設定されている認証情報</returns>
        public HumanBasicInformation GetHumanBasicInformation() { 
            return humanBasicInformation;
        }
        
    }

    /// <summary>
    /// デジタル世界内での標準情報を設定する
    /// この標準情報を使って、認証や買い物を人々は実施している
    /// </summary>
    public class HumanBasicInformation
    {
        /// <summary>
        /// 登録名称
        /// </summary>
        public string registerName;
        /// <summary>
        /// 住所
        /// </summary>
        public string address;
        /// <summary>
        /// 誕生日
        /// </summary>
        public string birthDay;
        
    }
}
