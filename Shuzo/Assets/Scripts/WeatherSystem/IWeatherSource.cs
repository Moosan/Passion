using UniRx;
namespace Assets.Scripts.WeatherSystem
{
    public interface IWeatherSource
    {
        IObservable<WeatherEnum> OnWeatherObservable();
    }
}