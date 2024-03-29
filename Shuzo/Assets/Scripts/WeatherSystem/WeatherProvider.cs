﻿using UnityEngine;
using UniRx;
namespace Assets.Scripts.WeatherSystem
{
    [RequireComponent(typeof(Collider))]
    public class WeatherProvider : MonoBehaviour
    {
        public ReactiveProperty<WeatherEnum> Weather { get; private set; }
        [SerializeField]
#pragma warning disable IDE0044 // 読み取り専用修飾子を追加します
        private WeatherEnum StartWeather = WeatherEnum.Sunny;
#pragma warning restore IDE0044 // 読み取り専用修飾子を追加します
        private void Awake()
        {
            Weather = new ReactiveProperty<WeatherEnum>(StartWeather);
        }
    }
}