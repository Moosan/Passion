using UniRx;
using UniRx.Triggers;
using UnityEngine;
namespace Assets.Scripts.WeatherSystem
{
    public class WeatherSourceOwn : MonoBehaviour, IWeatherSource
    {
        private readonly BehaviorSubject<WeatherEnum> WeatherSubject = new BehaviorSubject<WeatherEnum>(WeatherEnum.None);
        public IObservable<WeatherEnum> OnWeatherObservable()
        {
            return WeatherSubject;
        }

        public void SetDefaultWeatherProperty(IReactiveProperty<WeatherEnum> weatherProperty)
        {
            weatherProperty
                .Subscribe(weather => WeatherSubject.OnNext(weather))
                .AddTo(gameObject);
        }
        private void Awake()
        {
            var weatherProvider = GetComponent<WeatherProvider>();
            if (weatherProvider != null)
            {
                SetDefaultWeatherProperty(weatherProvider.Weather);
            }
        }
    }
}