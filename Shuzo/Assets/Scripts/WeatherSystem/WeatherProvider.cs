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
            Weather.Subscribe(weather => OnOwnWeatherProvide(GetComponent<IWeatherable>(), weather));
        }
        private void OnTriggerEnter(Collider other)
        {
            OnOtherWeatherProvide(other);
        }
        //他の何かに天気を提供するとき
        private void OnOtherWeatherProvide(Collider other)
        {
            if (other.GetComponent<WeatherProvider>() != null) return;
            OnWeatherProvide(other.GetComponent<IWeatherable>(), Weather.Value);
        }
        //自分に天気を提供するとき
        private void OnOwnWeatherProvide(IWeatherable weatherable, WeatherEnum ownWeather)
        {
            OnWeatherProvide(weatherable, ownWeather);
        }
        //天気を提供する
        private void OnWeatherProvide(IWeatherable weatherable, WeatherEnum weather)
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