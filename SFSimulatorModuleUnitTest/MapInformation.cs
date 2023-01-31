using RealityDataLibrary.Map;

namespace SFSimulatorModuleUnitTest
{
    [TestClass]
    public class MapInformation
    {
        [TestMethod]
        public void TestMapPin()
        {
            MapPin mapPin = new MapPin();
            mapPin.PinName = "‘æ‚P“Œ‹—Ìˆæ“Ë“ü";
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
    public class TestCountryZone
    {
        [TestMethod]
        public void TestCountryZoneParameterSet()
        {
            string name = "‘æ‚Q“Œ‹@–h‰qü";
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
    }
}