using UnityEngine;
namespace Assets.Scripts.WeatherSystem.Sample
{
    public class WeatherPlayerSample : WeatherableMonoBehavior
    {
        public override void OnSunny()
        {
            Debug.Log("Playerが晴れになった");
        }
        public override void OnRainy()
        {
            Debug.Log("Playerが雨になった");
        }
        public override void OnThunder()
        {
            Debug.Log("Playerが雷になった");
        }
        public override void OnSnowy()
        {
            Debug.Log("Playerが雪になった");
        }
    }
}