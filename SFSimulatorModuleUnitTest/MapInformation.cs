using RealityDataLibrary.Map;

namespace SFSimulatorModuleUnitTest
{
    [TestClass]
    public class TestMapPin
    {
        [TestMethod]
        public void TestMapPinDataSet()
        {
            MapPin mapPin = new MapPin();
            mapPin.PinName = "第１東京領域突入";
            float testLat = 25.0f;
            float testLon = 45.5f;
            mapPin.lat = testLat;
            mapPin.lon = testLon;
            Assert.IsFalse(mapPin.PinName == "");
            Assert.IsTrue(mapPin.lat == testLat);
            Assert.IsTrue(mapPin.lon == testLon);
            
        }
    }


    [TestClass]
    public class TestMapInformation
    {
        [TestMethod]
        public void TestMapInformationDataSet()
        {
            string mapName = "2021年版第３都市対応地図";
            int releaseYear = 2021;
            List<CountryRow> countryRows = new List<CountryRow>();



            MapInformation newMap = new MapInformation(mapName, releaseYear, countryRows);

            Assert.AreEqual(mapName, newMap.GetName());
            Assert.AreEqual(releaseYear, newMap.GetReleaseYear());
            Assert.AreEqual(countryRows, newMap.GetCountryRows());   


        }


    }



    [TestClass]
    public class TestCountryZone
    {
        [TestMethod]
        public void TestCountryZoneParameterSet()
        {
            string name = "第２東京　防衛線";
            float startLat = 20.0f;
            float startLon = 10.0f;
            float endLat = 40.0f;
            float endLon = 30.0f;

            AreaRange areaRange = new AreaRange(startLat, startLon, endLat, endLon);
            CountryZone countryZone = new CountryZone(name, areaRange);
            Assert.AreEqual(name, countryZone.GetName());
            Assert.AreEqual(countryZone.GetAreaRange().GetStartLat(), startLat);
            Assert.AreEqual(countryZone.GetAreaRange().GetStartLat(), startLat);
            Assert.AreEqual(countryZone.GetAreaRange().GetStartLat(), startLat);
            Assert.AreEqual(countryZone.GetAreaRange().GetStartLat(), startLat);

        }

        [TestMethod]
        public void TestAreaRangePlanType()
        {

            float startLat = 30.0f;
            float startLon = 40.0f;
            float endLat = 80.0f;
            float endLon = 20.0f;


            AreaRange areaRange = new AreaRange(startLat, startLon, endLat, endLon);
            
            Assert.AreEqual(startLat, areaRange.GetStartLat());
            Assert.AreEqual(startLon, areaRange.GetStartLon());
            Assert.AreEqual(endLat, areaRange.GetEndLat());
            Assert.AreEqual(endLon, areaRange.GetEndLon());

        }


        /// <summary>
        /// 地下帝国が設定できているかを確認
        /// </summary>
        public void TestAreaRangeGeoFront()
        {

            float startLat = 30.0f;
            float startLon = 40.0f;

            AreaRange areaRange = new AreaRange(startLat, startLon, startLat, startLon);

            float startAltitude = 0.0f;
            float endAltitude = -30.0f;

            areaRange.Altitude(startAltitude, endAltitude);

            Assert.AreEqual(startAltitude, areaRange.GetStartAltitude());
            Assert.AreEqual(endAltitude, areaRange.GetEndAltitude());

        }




    }
}