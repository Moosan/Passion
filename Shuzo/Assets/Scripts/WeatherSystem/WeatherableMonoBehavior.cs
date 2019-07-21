using UnityEngine;
namespace Assets.Scripts.WeatherSystem
{
    public abstract class WeatherableMonoBehavior : MonoBehaviour, IWeatherable
    {
        public virtual void OnSunny()
        {

        }
        public virtual void OnRainy()
        {

        }
        public virtual void OnThunder()
        {

        }
        public virtual void OnSnowy()
        {

        }
    }
}