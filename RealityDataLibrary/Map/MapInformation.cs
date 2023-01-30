using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityDataLibrary.Map
{

    /// <summary>
    /// 地図情報
    /// </summary>
    public class MapInformation
    {

    }

    /// <summary>
    /// 地図内のpinを表す
    /// </summary>
    public class MapPin
    {
        /// <summary>
        /// 緯度、経度情報
        /// </summary>
        public float lat;
        public float lon;

        /// <summary>
        /// 地図で表示される名称
        /// </summary>
        public string PinName;
    }
}
