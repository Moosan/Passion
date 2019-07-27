using UnityEngine;
namespace Assets.Scripts.WeatherSystem.Sample
{
    public class WeatherPlayerSample : WeatherableMonoBehavior
    {
        protected override void OnSunny()
        {
            Debug.Log("Playerが晴れになった");
        }
        protected override void OnRainy()
        {
            Debug.Log("Playerが雨になった");
        }
        protected override void OnThunder()
        {
            Debug.Log("Playerが雷になった");
        }
        protected override void OnSnowy()
        {
            Debug.Log("Playerが雪になった");
        }
        public void GotoLeft()
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        public void GotoRight()
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
    }
}