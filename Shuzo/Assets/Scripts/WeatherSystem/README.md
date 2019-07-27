# Weatherのリードミー
* 天気が変わる空間
    * WeatherProviderをアタッチ
        * Colliderをアタッチ(isTriggerをtrue)
* 天気の影響を受けるオブジェクトを作るとき
    * WeatherSourceFromTriggerをアタッチ
        * Colliderをアタッチ
    * WeatherableMonoBehaviorを継承したコンポーネントをアタッチ
* 天気を変えれるPlayerを作るとき
    * WeatherProviderをアタッチ
        * Colliderをアタッチ(isTriggerをtrue)
    * WeatherSourceOwnをアタッチ
    * WeatherableMonoBehaviorを継承したコンポーネントをアタッチ
![](https://i.imgur.com/eQppat5.png)