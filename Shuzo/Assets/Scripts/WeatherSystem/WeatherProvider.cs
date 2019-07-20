using UnityEngine;
using UniRx;
namespace Assets.Scripts.WeatherSystem
{
    [RequireComponent(typeof(Collider))]
    public class WeatherProvider : MonoBehaviour
    {
        public ReactiveProperty<WeatherEnum> Weather { get; private set; }
        [SerializeField]
        private WeatherEnum StartWeather = WeatherEnum.Sunny;
        private void Awake()
        {
            Weather = new ReactiveProperty<WeatherEnum>(StartWeather);
            var ownWeatherable = GetComponent<IWeatherable>();
            if (ownWeatherable != null)
            {
                Weather.Subscribe(weather => OnWeatherable(ownWeatherable, weather));
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            OnWeatherable(other.GetComponent<IWeatherable>(), Weather.Value);
        }
        private void OnWeatherable(IWeatherable weatherable, WeatherEnum weather)
        {
            if (weatherable == null) return;
            switch (weather)
            {
                case WeatherEnum.Sunny:
                    weatherable.OnSunny();
                    break;
                case WeatherEnum.Rainy:
                    weatherable.OnRainy();
                    break;
                case WeatherEnum.Thunder:
                    weatherable.OnThunder();
                    break;
                case WeatherEnum.Sonwy:
                    weatherable.OnSnowy();
                    break;
            }
        }
    }
}