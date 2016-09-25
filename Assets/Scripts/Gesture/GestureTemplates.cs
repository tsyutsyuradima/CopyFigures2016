using UnityEngine;
using System.Collections.Generic;
using CopyFigure2016.Models;
using System.Xml.Serialization;
using Assets.Scripts.Models;
using System.IO;

namespace CopyFigure2016.Gesture
{
    public class GestureTemplates : MonoBehaviour
    {
        public static GestureDatabase Templates;

        void Awake()
        {
            Load();
            //Templates.Add(new GestureObject()
            //{
            //    Name = "M",
            //    PointArray = new List<Vector3>() { new Vector3(-145.7722f, -172.7422f), new Vector3(-144.7982f, -151.5887f), new Vector3(-140.9521f, -125.3644f), new Vector3(-136.1536f, -104.887f), new Vector3(-131.589f, -83.87671f), new Vector3(-127.2832f, -58.0251f), new Vector3(-122.8083f, -37.28766f), new Vector3(-115.6496f, -11.32137f), new Vector3(-109.6324f, 14.36432f), new Vector3(-103.9108f, 41.73857f), new Vector3(-100.967f, 62.78458f), new Vector3(-95.48074f, 83.90634f), new Vector3(-91.53528f, 105.3274f), new Vector3(-87.41833f, 127.2578f), new Vector3(-74.04251f, 120.918f), new Vector3(-56.93002f, 94.70789f), new Vector3(-47.57635f, 68.95062f), new Vector3(-38.08673f, 50.36392f), new Vector3(-24.50861f, 25.03264f), new Vector3(-15.672f, 4.515167f), new Vector3(-5.154419f, -18.16635f), new Vector3(2.266815f, -38.14581f), new Vector3(9.956177f, -21.5802f), new Vector3(20.85999f, -2.146957f), new Vector3(30.6449f, 17.33205f), new Vector3(42.4964f, 38.4039f), new Vector3(53.29831f, 64.22647f), new Vector3(64.63156f, 85.16788f), new Vector3(74.12708f, 107.2043f), new Vector3(87.02002f, 122.9459f), new Vector3(94.56897f, 107.3763f), new Vector3(103.5108f, 79.12033f), new Vector3(109.1725f, 56.09058f), new Vector3(114.6503f, 34.23648f), new Vector3(119.2457f, 7.063507f), new Vector3(126.4579f, -22.87538f), new Vector3(130.61f, -54.75125f), new Vector3(136.7232f, -77.76165f), new Vector3(142.339f, -102.431f), new Vector3(146.9172f, -123.4264f), new Vector3(152.1941f, -145.554f), new Vector3(154.2278f, -167.1027f) }
            //});
            //Templates.Add(new GestureObject()
            //{
            //    Name = "Triangle",
            //    PointArray = new List<Vector3>() { new Vector3(-143.4123f, -105.1196f), new Vector3(-137.7427f, -86.15549f), new Vector3(-122.5665f, -62.17853f), new Vector3(-110.789f, -42.92371f), new Vector3(-103.1695f, -23.27933f), new Vector3(-95.8299f, -2.138474f), new Vector3(-87.02225f, 24.48549f), new Vector3(-80.2272f, 50.8271f), new Vector3(-72.01141f, 73.03943f), new Vector3(-63.14139f, 93.73874f), new Vector3(-54.83691f, 112.7563f), new Vector3(-44.7193f, 134.6478f), new Vector3(-36.10461f, 153.1415f), new Vector3(-25.02945f, 174.1042f), new Vector3(-12.40378f, 194.8804f), new Vector3(-3.139343f, 177.8545f), new Vector3(8.538086f, 159.0568f), new Vector3(21.35684f, 138.8588f), new Vector3(34.06589f, 117.1858f), new Vector3(46.67401f, 97.17191f), new Vector3(57.87656f, 76.90338f), new Vector3(68.41559f, 59.06932f), new Vector3(79.18939f, 40.28864f), new Vector3(88.74719f, 21.63148f), new Vector3(100.5623f, 0.07565308f), new Vector3(110.9485f, -20.23502f), new Vector3(123.6734f, -36.86342f), new Vector3(136.5685f, -53.4242f), new Vector3(147.9459f, -69.97812f), new Vector3(156.5877f, -83.09161f), new Vector3(137.0233f, -86.23846f), new Vector3(117.8612f, -87.28741f), new Vector3(95.8324f, -90.43426f), new Vector3(74.14175f, -90.77433f), new Vector3(51.81021f, -91.48322f), new Vector3(31.53659f, -92.44043f), new Vector3(12.13757f, -93.58112f), new Vector3(-8.801453f, -96.72797f), new Vector3(-30.56747f, -97.52676f), new Vector3(-51.93512f, -97.77692f), new Vector3(-73.26596f, -97.77692f), new Vector3(-94.59677f, -97.77692f), new Vector3(-113.9884f, -97.77692f), new Vector3(-136.1928f, -96.72797f) }
            //});
            //Templates.Add(new GestureObject()
            //{
            //    Name = "Triangle2",
            //    PointArray = new List<Vector3>() { new Vector3(-152.249f, 90.40303f), new Vector3(-135.7651f, 93.4832f), new Vector3(-116.8618f, 95.77809f), new Vector3(-86.79346f, 97.52812f), new Vector3(-64.28775f, 97.52812f), new Vector3(-43.65753f, 97.52812f), new Vector3(-24.9028f, 97.52812f), new Vector3(-7.085785f, 97.52812f), new Vector3(16.35764f, 97.52812f), new Vector3(34.17465f, 97.52812f), new Vector3(57.61807f, 97.52812f), new Vector3(77.31055f, 97.52812f), new Vector3(94.55972f, 99.90315f), new Vector3(115.7578f, 99.90315f), new Vector3(133.5748f, 99.90315f), new Vector3(147.751f, 94.62907f), new Vector3(136.4799f, 73.04497f), new Vector3(123.5305f, 51.32246f), new Vector3(112.9795f, 31.50011f), new Vector3(103.6277f, 10.36267f), new Vector3(94.80716f, -16.5685f), new Vector3(86.31601f, -37.44279f), new Vector3(74.02182f, -65.81215f), new Vector3(62.36328f, -87.71431f), new Vector3(49.92038f, -112.1967f), new Vector3(33.85535f, -137.3722f), new Vector3(22.20242f, -158.08f), new Vector3(6.785248f, -182.5029f), new Vector3(-5.613647f, -200.0968f), new Vector3(-18.88541f, -198.4224f), new Vector3(-31.03668f, -179.6266f), new Vector3(-38.61707f, -159.0453f), new Vector3(-52.18195f, -128.9759f), new Vector3(-61.43857f, -105.6554f), new Vector3(-70.31064f, -76.37982f), new Vector3(-81.71133f, -46.68631f), new Vector3(-93.0679f, -19.41916f), new Vector3(-109.1582f, 10.70497f), new Vector3(-119.886f, 39.11873f), new Vector3(-131.3619f, 62.60231f), new Vector3(-139.1207f, 81.58549f) }
            //});
            //Templates.Add(new GestureObject()
            //{
            //    Name = "И",
            //    PointArray = new List<Vector3>() { new Vector3(-139.7734f, 147.2949f), new Vector3(-143.1891f, 130.4817f), new Vector3(-144.8928f, 103.932f), new Vector3(-144.8928f, 82.10522f), new Vector3(-145.9167f, 57.26324f), new Vector3(-145.9167f, 31.17607f), new Vector3(-145.9167f, 7.270554f), new Vector3(-145.9167f, -16.63496f), new Vector3(-145.9167f, -43.6586f), new Vector3(-145.9167f, -67.56413f), new Vector3(-145.9167f, -90.43028f), new Vector3(-145.9167f, -111.2177f), new Vector3(-144.8928f, -131.8772f), new Vector3(-139.9596f, -152.7051f), new Vector3(-127.1068f, -140.0967f), new Vector3(-112.3281f, -120.1073f), new Vector3(-98.59335f, -104.8415f), new Vector3(-85.91174f, -88.38824f), new Vector3(-63.65787f, -69.58074f), new Vector3(-48.72894f, -53.38674f), new Vector3(-30.90942f, -36.33717f), new Vector3(-15.63013f, -19.78754f), new Vector3(1.470825f, -2.934326f), new Vector3(17.71509f, 13.02246f), new Vector3(36.37451f, 28.81972f), new Vector3(55.12778f, 42.68581f), new Vector3(72.46457f, 57.16661f), new Vector3(88.7131f, 70.54263f), new Vector3(104.2308f, 86.89539f), new Vector3(120.2264f, 103.2021f), new Vector3(135.3012f, 118.8745f), new Vector3(147.6574f, 134.5356f), new Vector3(152.0355f, 126.2099f), new Vector3(152.0355f, 103.932f), new Vector3(152.0355f, 83.14459f), new Vector3(152.0355f, 61.31783f), new Vector3(152.0355f, 35.33356f), new Vector3(152.0355f, 12.46741f), new Vector3(152.0355f, -8.320007f), new Vector3(152.0355f, -30.14679f), new Vector3(152.0355f, -53.01294f), new Vector3(152.0355f, -76.91846f), new Vector3(154.0833f, -99.15522f), new Vector3(154.0833f, -120.572f) }
            //});
            //Templates.Add(new GestureObject()
            //{
            //    Name = ">",
            //    PointArray = new List<Vector3>() { new Vector3(-145.0702f, 159.9323f), new Vector3(-132.4864f, 156.7859f), new Vector3(-117.909f, 146.1248f), new Vector3(-103.5844f, 136.5053f), new Vector3(-89.81882f, 125.8367f), new Vector3(-72.22949f, 119.445f), new Vector3(-58.24994f, 110.9952f), new Vector3(-43.32526f, 104.6316f), new Vector3(-32.26718f, 97.15004f), new Vector3(-20.70609f, 88.325f), new Vector3(-8.976257f, 79.01733f), new Vector3(7.100983f, 71.21703f), new Vector3(22.06775f, 63.50372f), new Vector3(35.92786f, 57.31728f), new Vector3(49.59955f, 48.94315f), new Vector3(64.80511f, 42.28868f), new Vector3(76.52911f, 34.40166f), new Vector3(90.33386f, 26.43927f), new Vector3(106.6483f, 17.74901f), new Vector3(118.506f, 10.36488f), new Vector3(130.4014f, 2.063309f), new Vector3(143.0282f, -4.868134f), new Vector3(142.4946f, -17.63954f), new Vector3(130.2016f, -25.98872f), new Vector3(117.2783f, -33.92029f), new Vector3(101.1172f, -42.30321f), new Vector3(87.43396f, -48.56274f), new Vector3(70.40039f, -57.71151f), new Vector3(56.69604f, -64.16359f), new Vector3(41.94769f, -71.84184f), new Vector3(29.55829f, -79.00468f), new Vector3(12.91675f, -85.65981f), new Vector3(-4.210419f, -92.70485f), new Vector3(-22.30612f, -98.44582f), new Vector3(-38.63309f, -103.9351f), new Vector3(-52.51865f, -108.9763f), new Vector3(-70.9848f, -114.315f), new Vector3(-93.33813f, -120.8529f), new Vector3(-108.8767f, -124.9362f), new Vector3(-123.9244f, -129.3534f), new Vector3(-138.6076f, -133.7852f), new Vector3(-156.9718f, -140.0677f) }
            //});
            //Templates.Add(new GestureObject()
            //{
            //    Name = "<",
            //    PointArray = new List<Vector3>() { new Vector3(152.7791f, 143.7046f), new Vector3(139.8537f, 141.5541f), new Vector3(127.1981f, 135.1024f), new Vector3(115.29f, 127.5756f), new Vector3(102.3314f, 120.5179f), new Vector3(87.77814f, 112.2072f), new Vector3(72.85156f, 105.6144f), new Vector3(58.51001f, 98.35275f), new Vector3(44.56363f, 91.7641f), new Vector3(30.84167f, 86.71536f), new Vector3(18.54044f, 80.03989f), new Vector3(5.505676f, 72.98886f), new Vector3(-7.275604f, 67.33124f), new Vector3(-23.02798f, 61.12671f), new Vector3(-35.58664f, 55.52255f), new Vector3(-51.87259f, 50.47092f), new Vector3(-68.15549f, 44.03917f), new Vector3(-83.17438f, 39.15126f), new Vector3(-98.88358f, 32.70483f), new Vector3(-111.541f, 25.24522f), new Vector3(-124.1364f, 15.70325f), new Vector3(-135.1953f, 6.89827f), new Vector3(-147.2209f, -3.867828f), new Vector3(-132.4124f, -11.85075f), new Vector3(-115.6094f, -16.1937f), new Vector3(-103.4332f, -24.63947f), new Vector3(-91.10846f, -31.96153f), new Vector3(-77.09341f, -41.0448f), new Vector3(-62.65363f, -49.63045f), new Vector3(-50.21872f, -59.1273f), new Vector3(-39.62531f, -68.36662f), new Vector3(-26.22858f, -78.09575f), new Vector3(-13.05511f, -84.65345f), new Vector3(2.112061f, -93.30017f), new Vector3(14.19623f, -99.91654f), new Vector3(26.27808f, -107.3353f), new Vector3(41.29196f, -113.3147f), new Vector3(58.07739f, -121.0703f), new Vector3(74.1843f, -127.6215f), new Vector3(87.27069f, -134.79f), new Vector3(100.2528f, -142.3169f), new Vector3(112.155f, -148.9396f), new Vector3(125.6447f, -156.2954f) }
            //});
        }
        void Load()
        {
            Templates = GestureDatabase.Load(Path.Combine(Application.dataPath, "gestures.xml"));
        }

        public static void Read()
        {
            Templates.Save(Path.Combine(Application.dataPath, "gestures.xml"));
        }
    }
}