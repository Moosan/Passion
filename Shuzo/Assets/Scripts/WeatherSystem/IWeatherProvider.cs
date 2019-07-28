using UniRx;
namespace Assets.Scripts.WeatherSystem
{
    public interface IWeatherProvider
    {
        IReactiveProperty<WeatherEnum> WeatherProperty();
    }
}