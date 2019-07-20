namespace Assets.Scripts.WeatherSystem
{
    public interface IWeatherable
    {
        void OnSunny();
        void OnRainy();
        void OnThunder();
        void OnSnowy();
    }
}