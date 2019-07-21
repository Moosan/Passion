using UnityEngine;
namespace Assets.Scripts.WeatherSystem.Sample
{
    public class WeatherableObjectSample : WeatherableMonoBehavior
    {
        public override void OnSunny()
        {
            Debug.Log("周りが晴れになった");
        }
        public override void OnRainy()
        {
            Debug.Log("周りが雨になった");
        }
        public override void OnThunder()
        {
            Debug.Log("周りが雷になった");
        }
        public override void OnSnowy()
        {
            Debug.Log("周りが雪になった");
        }
    }
}