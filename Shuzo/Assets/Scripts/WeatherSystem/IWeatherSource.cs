using UniRx;
namespace Assets.Scripts.WeatherSystem
{
    public interface IWeatherSource
    {
        IObservable<WeatherEnum> OnWeatherObservable();
        void SetDefaultWeatherProperty(IReactiveProperty<WeatherEnum> weatherProperty);
    }
}