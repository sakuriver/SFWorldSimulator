using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealityDataLibrary.Map
{

    /// <summary>
    /// 地図情報
    /// 本だったり、デジタルのふわっとしたものだったりする
    /// </summary>
    public class MapInformation
    {

        /// <summary>
        /// 地図そのものの名称
        /// 世界地図 2036最新版等
        /// </summary>
        private string name;

        /// <summary>
        /// 地図が発売された年月をスキャンして表示する
        /// </summary>
        private int releaseYear;

        /// 
        /// 地図内における領域情報一覧
        ///
        private List<CountyRow> countyRows;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_name">地図に設定する名前</param>
        /// <param name="_releaseYear">地図が公開された年月</param>
        /// <param name="countyRows">領域一覧</param>
        public MapInformation(string _name,int _releaseYear, List<CountyRow> countyRows) {
            this.name = _name;
            this.releaseYear = _releaseYear;
            this.countyRows = countyRows;
        }
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
        public string? PinName;
    }

    /// <summary>
    /// 国単位の領域定義
    /// 第3東京等を設定する
    /// </summary>
    public class CountryZone
    {
        /// <summary>
        /// 領域名を設定する
        /// </summary>
        private string name;

        /// <summary>
        /// 領域の範囲を表す
        /// </summary>
        private AreaRange areaRange;


        /// <summary>
        /// 領域情報を設定する
        /// </summary>
        /// <param name="_name">領域の別名</param>
        /// <param name="_areaRange">領域の範囲情報</param>
        public CountryZone(string _name, AreaRange _areaRange)
        {
            this.name = _name;
            this.areaRange = _areaRange;
        }


        /// <summary>
        /// 領域情報を取得する
        /// </summary>
        /// <returns>領域の情報名</returns>
        public string GetName() { return name; }

        /// <summary>
        /// 領域の範囲を取得する
        /// </summary>
        /// <returns>領域範囲情報</returns>
        public AreaRange GetAreaRange() { return areaRange; }
    }

    /// <summary>
    /// 特定領域の範囲を表す
    /// </summary>
    public class AreaRange {
        /// <summary>
        /// 緯度、経度情報
        /// </summary>
        private float startLat;
        private float startLon;
        private float endLat;
        private float endLon;
        /// <summary>
        /// 空中都市や深海都市描画で利用する
        /// </summary>
        private float startAltitude;
        private float endAltitude;

        /// <summary>
        /// 座標情報を設定
        /// </summary>
        /// <param name="_startLat">開始緯度</param>
        /// <param name="_startLon">開始経度</param>
        /// <param name="_endLat">開始緯度</param>
        /// <param name="_endLon">開始経度</param>
        public AreaRange(float _startLat,float _startLon,float _endLat,float _endLon) {
            this.startLat = _startLat;
            this.startLon = _startLon;
            this.endLat = _endLat;
            this.endLon= _endLon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetStartLat() {
            return startLat;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetStartLon()
        {
            return startLon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetEndLat()
        {
            return this.endLat;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public float GetEndLon()
        {
            return this.endLon;
        }

        /// <summary>
        /// 標高の開始情報を定義
        /// </summary>
        /// <returns></returns>
        public float GetStartAltitude()
        {
            return this.startAltitude;
        }

        /// <summary>
        /// 標高の終了情報を定義
        /// </summary>
        /// <returns></returns>
        public float GetEndAltitude() 
        { 
            return this.endAltitude;
        }

    }


    ///<summary>
    /// SF内で集計する国単位の情報を集めたものになる
    ///<summary>
    public class CountyRow
    {
        /// <summary>
        /// 一国の中に入っている都市等の一覧を取得
        /// </summary>
        private List<CountryZone> countryZones;

        /// <summary>
        /// 国単位情報設定用のコンストラクタ
        /// </summary>
        /// <param name="_countryZones">国の中に格納されている領域一覧</param>
        public CountyRow(List<CountryZone> _countryZones)
        {
            countryZones = _countryZones;
        }

        /// <summary>
        /// 領域一覧を取得する
        /// 各領域内での天候や土地状況などを取得する
        /// </summary>
        /// <returns></returns>
        public List<CountryZone> GetCountryZones()
        {
            return countryZones;
        }
    }
}
