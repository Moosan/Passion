using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
namespace Assets.Scripts.WeatherSystem.Sample
{
    public class PlayerWeatherPresenter : MonoBehaviour
    {
        public Button SunnyButton;
        public Button RainyButton;
        public Button Left;
        public Button Right;
        public WeatherProvider provider;
        public WeatherPlayerSample Player;
        private void Start()
        {
            SunnyButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    provider.Weather.Value = WeatherEnum.Sunny;
                })
                .AddTo(gameObject);
            RainyButton.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    provider.Weather.Value = WeatherEnum.Rainy;
                })
                .AddTo(gameObject);
            provider.Weather
                .Subscribe(weather =>
                {
                    switch (weather)
                    {
                        case WeatherEnum.Sunny:
                            SunnyButton.gameObject.SetActive(false);
                            RainyButton.gameObject.SetActive(true);
                            break;
                        case WeatherEnum.Rainy:
                            SunnyButton.gameObject.SetActive(true);
                            RainyButton.gameObject.SetActive(false);
                            break;
                    }
                })
                .AddTo(gameObject);


            Left.OnPointerDownAsObservable()
                .SelectMany(_ => gameObject.UpdateAsObservable())
                .TakeUntil(Left.OnPointerUpAsObservable())
                .RepeatUntilDestroy(gameObject)
                .Subscribe(_ => Player.GotoLeft());

            Right.OnPointerDownAsObservable()
                .SelectMany(_ => gameObject.UpdateAsObservable())
                .TakeUntil(Right.OnPointerUpAsObservable())
                .RepeatUntilDestroy(gameObject)
                .Subscribe(_ => Player.GotoRight());
        }
    }
}