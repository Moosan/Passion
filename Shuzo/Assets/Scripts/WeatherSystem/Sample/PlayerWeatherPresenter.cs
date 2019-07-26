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

            //RepeatUntilDestroyを使うと
            //Destroy時にOnCompleteを発行して
            //まだオブザーバー生成されてなかったら(再生時に一度もボタンに触れなかったら)
            //Instanceしちゃうっぽくてくそいので
            //RepeatUntilDisableを使ってるけど
            //リークしてないか心配ではある(一応使用的にはDestroyの前にDisableの処理を完了させてるっぽいのでたぶん大丈夫)
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

        private void OnDisable()
        {
            Debug.Log("Disable");
        }
        private void OnDestroy()
        {
            Debug.Log("Destroy");
        }
    }
}