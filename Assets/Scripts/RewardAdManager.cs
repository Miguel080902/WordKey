using UnityEngine;
using UnityEngine.Advertisements;

public class RewardAdManager : MonoBehaviour, IUnityAdsInitializationListener
{
    private const string androidGameId = "5293571";
    private const string iosGameId = "5293570";
    private const string rewardedVideoPlacementId = "Rewarded_Android";

    private bool isAdReady;

    private void Start()
    {
        InitializeUnityAds();
    }

    private void InitializeUnityAds()
    {
        if (Advertisement.isSupported)
        {
            string gameId = GetGameId();
            Advertisement.Initialize(gameId, true, this);
        }
        else
        {
            Debug.Log("Unity Ads no es compatible en esta plataforma.");
        }
    }

    private string GetGameId()
    {
#if UNITY_ANDROID
        return androidGameId;
#elif UNITY_IOS
        return iosGameId;
#else
        return string.Empty;
#endif
    }

    public void ShowRewardedAd()
    {
        if (isAdReady)
        {
            Advertisement.Show(rewardedVideoPlacementId);
        }
        else
        {
            Debug.Log("El anuncio de recompensa no está listo para ser mostrado.");
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads inicializado correctamente.");
        LoadRewardedAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"Inicialización de Unity Ads fallida: {error.ToString()} - {message}");
    }

    private void LoadRewardedAd()
    {
        Advertisement.Load(rewardedVideoPlacementId);
    }

    private void HandleRewardedAdResult(ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                // Aquí puedes recompensar al jugador por ver el anuncio.
                Debug.Log("El jugador ha completado el anuncio de recompensa.");
                break;
            case ShowResult.Skipped:
                Debug.Log("El jugador ha omitido el anuncio de recompensa.");
                break;
            case ShowResult.Failed:
                Debug.LogError("El anuncio de recompensa ha fallado al mostrarse.");
                break;
        }
    }
}


