using UnityEngine;
namespace Assets.Scripts.WeatherSystem.Sample
{
    public class WeatherableObjectSample : WeatherableMonoBehavior
    {
        protected override void OnSunny()
        {
            Debug.Log("周りは晴れ");
        }
        protected override void OnRainy()
        {
            Debug.Log("周りは雨");
        }
        protected override void OnThunder()
        {
            Debug.Log("周りは雷");
        }
        protected override void OnSnowy()
        {
            Debug.Log("周りは雪");
        }
    }
}