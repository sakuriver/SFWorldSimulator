using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityDataLibrary.Finance
{

    /// <summary>
    /// 通貨情報
    /// </summary>
    public class Money
    {

        /// <summary>
        /// 名称
        /// </summary>
        public string _name;
        /// <summary>
        /// 通貨コード
        /// </summary>
        public string _code;
    }

    /// <summary>
    /// レート情報
    /// 通貨が違う国同士は、レート変換をして格納する
    /// </summary>
}
