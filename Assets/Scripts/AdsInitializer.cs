using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _showAdButton;
    public AudioSource backgroundMusic;
    public static AdsInitializer instance;
    private string _androidGameId = "5293571";
    private string _iOSGameId = "5293570";
    private bool _testMode = true;
    private string _gameId;
    private bool tieneMoneda = true;
    public GameObject Panel;
    private int sceneCount;
    bool cargo = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        InitializeAds();
    }

    public void InitializeAds()
    {
#if UNITY_IOS
            _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void MostrarPanelAnuncio()
    {
        Panel.SetActive(true);
    }

    public void OcultarPanelAnuncio()
    {
        Panel.SetActive(false);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex > 1)
        {
            Debug.Log("BuscandoPanel");
            _showAdButton = GameObject.Find("Si").GetComponent<Button>();
            Panel = GameObject.Find("PanelAnuncio");
            OcultarPanelAnuncio();
            LoadAd();
        }
    }

    private void Update()
    {
        sceneCount = CoinManager.instance.GetScenaPasadas();
        if (sceneCount >= 2 && _showAdButton!=null && cargo)
        {
            tieneMoneda = false;
            ShowAd();
            CoinManager.instance.ResetearCont();
        }
    }

    public void LoadAd()
    {
        cargo = false;
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + "Rewarded_Android");
        Advertisement.Load("Rewarded_Android", this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Ad Loaded: " + placementId);
        cargo = true;
        if (placementId.Equals("Rewarded_Android"))
        {
            // Configure the button to call the ShowAd() method when clicked:
            _showAdButton.onClick.AddListener(ShowAd);
            // Enable the button for users to click:
            _showAdButton.interactable = true;
        }
    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAd()
    {
        // Disable the button:
        _showAdButton.interactable = false;
        Debug.Log("Showing Ad: " + "Rewarded_Android");
        Advertisement.Show("Rewarded_Android", this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals("Rewarded_Android") && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            if (tieneMoneda)
                CoinManager.instance.AddCoins(5);
            tieneMoneda = true;
            OcultarPanelAnuncio();
            backgroundMusic.UnPause();
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        OcultarPanelAnuncio();
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { backgroundMusic.Pause(); }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        if(_showAdButton!=null)
        // Clean up the button listeners:
        _showAdButton.onClick.RemoveAllListeners();
    }
}
