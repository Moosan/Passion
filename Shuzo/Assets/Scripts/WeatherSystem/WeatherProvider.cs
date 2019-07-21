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
            Weather.Subscribe(weather => OnOwnWeatherChange(GetComponent<IWeatherable>(), weather));
        }
        private void OnTriggerEnter(Collider other)
        {
            OnOtherProvideWeatherChange(other);
        }
        private void OnOtherProvideWeatherChange(Collider other)
        {
            if (other.GetComponent<WeatherProvider>() != null) return;
            OnWeatherChange(other.GetComponent<IWeatherable>(), Weather.Value);
        }
        private void OnOwnWeatherChange(IWeatherable weatherable, WeatherEnum ownWeather)
        {
            OnWeatherChange(weatherable, ownWeather);
        }
        private void OnWeatherChange(IWeatherable weatherable, WeatherEnum weather)
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