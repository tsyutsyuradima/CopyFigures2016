using UnityEngine;
using System.Collections.Generic;
using CopyFigure2016.Models;
using System.Xml.Serialization;
using Assets.Scripts.Models;
using System.IO;
using System.Xml;
using System.Text;

namespace CopyFigure2016.Gesture
{
    public class GestureTemplates : MonoBehaviour
    {
        public static List<GestureObject> Templates = new List<GestureObject>();

        void Start()
        {
            Templates.Add(new GestureObject()
            {
                Name = "",
                PointArray = new List<Vector3>() { new Vector3(-146.5396f, 106.0059f), new Vector3(-121.5472f, 106.0059f), new Vector3(-87.41626f, 106.0059f), new Vector3(-61.87714f, 104.8531f), new Vector3(-33.0201f, 104.8531f), new Vector3(-6.355301f, 104.8531f), new Vector3(19.2429f, 104.8531f), new Vector3(48.04088f, 104.8531f), new Vector3(73.63908f, 104.8531f), new Vector3(99.23727f, 104.8531f), new Vector3(124.8355f, 104.8531f), new Vector3(153.4604f, 106.0059f), new Vector3(143.5359f, 84.04121f), new Vector3(130.7734f, 56.4312f), new Vector3(117.9059f, 26.30946f), new Vector3(105.5406f, -2.726761f), new Vector3(93.70068f, -32.93309f), new Vector3(82.75238f, -60.04282f), new Vector3(64.61984f, -91.18719f), new Vector3(49.35193f, -121.4964f), new Vector3(33.80997f, -145.7372f), new Vector3(20.15962f, -170.1743f), new Vector3(8.682739f, -192.2405f), new Vector3(-4.443741f, -193.9941f), new Vector3(-16.41547f, -166.8783f), new Vector3(-28.38991f, -141.7025f), new Vector3(-41.7453f, -114.4863f), new Vector3(-55.88635f, -90.65848f), new Vector3(-71.64844f, -66.9893f), new Vector3(-88.50451f, -37.9649f), new Vector3(-102.5074f, -14.36983f), new Vector3(-112.0781f, 11.91026f), new Vector3(-122.1864f, 37.41322f), new Vector3(-131.1555f, 69.46675f), new Vector3(-137.5714f, 95.15959f) }
            });

            Templates.Add(new GestureObject()
            {
                Name = "",
                PointArray = new List<Vector3>() { new Vector3(-147.1104f, -103.0666f), new Vector3(-137.011f, -80.00661f), new Vector3(-123.936f, -52.52548f), new Vector3(-116.4444f, -27.07724f), new Vector3(-108.2902f, 0.5969696f), new Vector3(-98.5439f, 26.02313f), new Vector3(-86.57701f, 51.91101f), new Vector3(-74.20896f, 76.94801f), new Vector3(-61.94113f, 104.4956f), new Vector3(-49.55285f, 130.1338f), new Vector3(-34.43353f, 154.578f), new Vector3(-16.63922f, 177.8402f), new Vector3(1.042068f, 196.9334f), new Vector3(17.38821f, 173.9128f), new Vector3(33.93318f, 149.7833f), new Vector3(46.99139f, 126.3224f), new Vector3(61.43581f, 96.7244f), new Vector3(72.82072f, 73.7495f), new Vector3(85.63463f, 49.29634f), new Vector3(101.7047f, 20.94077f), new Vector3(113.985f, -2.315384f), new Vector3(126.7833f, -25.78235f), new Vector3(139.3541f, -48.53223f), new Vector3(150.4924f, -71.39355f), new Vector3(152.8896f, -98.47885f), new Vector3(127.5392f, -100.908f), new Vector3(100.2513f, -100.908f), new Vector3(74.17574f, -100.908f), new Vector3(49.14317f, -100.908f), new Vector3(20.98154f, -100.908f), new Vector3(-4.051041f, -100.908f), new Vector3(-29.0836f, -100.908f), new Vector3(-54.11617f, -100.908f), new Vector3(-82.2778f, -100.908f), new Vector3(-109.3086f, -99.48386f), new Vector3(-143.0197f, -93.35294f) }
            });

            Templates.Add(new GestureObject()
            {
                Name = "",
                PointArray = new List<Vector3>() { new Vector3(-104.0795f, 148.8622f), new Vector3(-104.0795f, 124.1481f), new Vector3(-104.0795f, 98.88051f), new Vector3(-104.0795f, 69.21855f), new Vector3(-104.0795f, 39.55655f), new Vector3(-104.0795f, 6.59877f), new Vector3(-104.0795f, -19.76744f), new Vector3(-104.0795f, -50.52803f), new Vector3(-104.0795f, -79.09143f), new Vector3(-104.0795f, -106.5562f), new Vector3(-104.0795f, -135.1196f), new Vector3(-93.67366f, -151.1378f), new Vector3(-68.63393f, -143.4099f), new Vector3(-44.41747f, -134.1568f), new Vector3(-16.02688f, -123.0574f), new Vector3(12.88965f, -111.7815f), new Vector3(37.13675f, -101.4311f), new Vector3(67.51189f, -90.77232f), new Vector3(91.76389f, -80.71451f), new Vector3(123.2945f, -67.6973f), new Vector3(146.2374f, -54.41898f), new Vector3(169.685f, -38.2025f), new Vector3(189.5771f, -22.25015f), new Vector3(191.3384f, -1.624634f), new Vector3(164.9416f, 12.47154f), new Vector3(138.4975f, 23.10213f), new Vector3(110.7898f, 36.20845f), new Vector3(86.70592f, 48.67784f), new Vector3(62.26262f, 63.48637f), new Vector3(38.33478f, 77.43623f), new Vector3(19.1608f, 94.08153f), new Vector3(-4.110107f, 111.0277f), new Vector3(-29.77238f, 127.1654f), new Vector3(-57.13872f, 138.5642f), new Vector3(-82.81881f, 143.3693f), new Vector3(-108.6616f, 148.8622f) }
            });

            Templates.Add(new GestureObject()
            {
                Name = "",
                PointArray = new List<Vector3>() { new Vector3(96.22205f, 149.732f), new Vector3(77.2388f, 133.2076f), new Vector3(48.02084f, 119.1964f), new Vector3(11.98096f, 101.9164f), new Vector3(-21.91188f, 85.93634f), new Vector3(-47.84872f, 73.07635f), new Vector3(-72.46935f, 61.5219f), new Vector3(-106.1883f, 44.79568f), new Vector3(-136.8821f, 30.72821f), new Vector3(-162.5277f, 17.83255f), new Vector3(-193.8561f, 6.03421f), new Vector3(-199.7616f, -7.255676f), new Vector3(-168.4838f, -20.62054f), new Vector3(-136.5318f, -32.08423f), new Vector3(-108.5897f, -44.22035f), new Vector3(-77.97871f, -58.54559f), new Vector3(-45.94569f, -74.63586f), new Vector3(-21.05521f, -90.46343f), new Vector3(4.895996f, -106.2255f), new Vector3(30.27283f, -121.7244f), new Vector3(56.65781f, -137.6084f), new Vector3(82.8342f, -150.268f), new Vector3(92.16589f, -132.0545f), new Vector3(97.59506f, -109.0909f), new Vector3(100.2384f, -80.24694f), new Vector3(100.2384f, -56.45848f), new Vector3(100.2384f, -27.05606f), new Vector3(100.2384f, 1.2155f), new Vector3(100.2384f, 34.01051f), new Vector3(100.2384f, 57.75864f), new Vector3(100.2384f, 86.03018f), new Vector3(100.2384f, 109.7783f), new Vector3(100.2384f, 135.7881f) }
            });

            Templates.Add(new GestureObject()
            {
                Name = "",
                PointArray = new List<Vector3>() { new Vector3(-143.6665f, 145.3531f), new Vector3(-113.945f, 145.3531f), new Vector3(-80.82785f, 145.3531f), new Vector3(-47.71074f, 145.3531f), new Vector3(-14.59363f, 145.3531f), new Vector3(18.5235f, 145.3531f), new Vector3(49.50403f, 145.3531f), new Vector3(80.48456f, 145.3531f), new Vector3(117.8749f, 145.3531f), new Vector3(152.0603f, 145.3531f), new Vector3(148.9278f, 120.3788f), new Vector3(147.9778f, 86.77142f), new Vector3(144.7729f, 54.91428f), new Vector3(140.4997f, 22.29233f), new Vector3(140.4997f, -12.36026f), new Vector3(140.4997f, -45.78839f), new Vector3(140.4997f, -79.21654f), new Vector3(140.4997f, -111.492f), new Vector3(140.4997f, -147.2255f), new Vector3(116.7665f, -154.3474f), new Vector3(83.0025f, -154.3474f), new Vector3(46.68048f, -154.3474f), new Vector3(15.69995f, -154.3474f), new Vector3(-14.21228f, -154.3474f), new Vector3(-51.60258f, -154.3474f), new Vector3(-82.58311f, -154.3474f), new Vector3(-115.6552f, -154.6469f), new Vector3(-142.5983f, -152.2477f), new Vector3(-142.5983f, -118.8196f), new Vector3(-142.5983f, -83.08607f), new Vector3(-142.5983f, -50.81064f), new Vector3(-142.5983f, -13.92442f), new Vector3(-143.6665f, 26.3676f), new Vector3(-147.9397f, 61.20233f), new Vector3(-147.9397f, 95.58154f), new Vector3(-147.9397f, 129.0097f) }
            });
        }
    }
}