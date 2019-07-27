using UnityEngine;
using UniRx;
namespace Assets.Scripts.WeatherSystem
{
    public abstract class WeatherableMonoBehavior : MonoBehaviour
    {
        private IWeatherSource Source;
        protected virtual void Start()
        {
            Source = GetComponent<IWeatherSource>();
            if (Source != null)
            {
                Source.OnWeatherObservable()
                    .Subscribe(weather => OnWeather(weather))
                    .AddTo(gameObject);
            }
        }
        private void OnWeather(WeatherEnum weather)
        {
            switch (weather)
            {
                case WeatherEnum.Sunny:
                    OnSunny();
                    break;
                case WeatherEnum.Rainy:
                    OnRainy();
                    break;
                case WeatherEnum.Thunder:
                    OnThunder();
                    break;
                case WeatherEnum.Sonwy:
                    OnSnowy();
                    break;
                case WeatherEnum.None:
                    break;
            }
        }
        protected virtual void OnSunny()
        {

        }
        protected virtual void OnRainy()
        {

        }
        protected virtual void OnThunder()
        {

        }
        protected virtual void OnSnowy()
        {

        }
    }
}