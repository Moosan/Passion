using System.Collections.Generic;
using UniRx;
using UnityEngine;
namespace Assets.Scripts.WeatherSystem
{
    public class WeatherSourceFromTrigger : MonoBehaviour,IWeatherSource
    {
        public IObservable<WeatherEnum> OnWeatherObservable()
        {
            return WeatherSubject;
        }
        public void SetDefaultWeatherProperty(IReactiveProperty<WeatherEnum> weather)
        {
            DefaultWeather = weather;
        }

        private readonly List<IReadOnlyReactiveProperty<WeatherEnum>> CollisionWeatherList = new List<IReadOnlyReactiveProperty<WeatherEnum>>();
        private IReadOnlyReactiveProperty<WeatherEnum> DefaultWeather;
        private readonly Subject<WeatherEnum> WeatherSubject = new Subject<WeatherEnum>();
        private WeatherEnum GetWeather
        {
            get
            {
                if (CollisionWeatherList.Count > 0) return CollisionWeatherList[CollisionWeatherList.Count - 1].Value;
                else if (DefaultWeather != null) return DefaultWeather.Value;
                else return WeatherEnum.None;
            }
        }
        private void Start()
        {
            Observable.EveryUpdate().Subscribe(_ => WeatherSubject.OnNext(GetWeather)).AddTo(gameObject);
        }
        private void OnTriggerEnter(Collider other)
        {
            var provider = other.GetComponent<WeatherProvider>();
            if (provider != null)
            {
                CollisionWeatherList.Add(provider.Weather);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            var provider = other.GetComponent<WeatherProvider>();
            if (provider != null)
            {
                CollisionWeatherList.Remove(provider.Weather);
            }
        }
    }
}