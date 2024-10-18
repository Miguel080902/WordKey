using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private TextMeshProUGUI textCoin;
    private int coins;
    [SerializeField] private int scenaPasadas;
    private const string CoinsKey = "Coins";

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        LoadCoins();
    }
    public void ResetearCont()
    {
        scenaPasadas =0;
    }
    public void SumarScena()
    {
        scenaPasadas += 1;
    }
    public int GetScenaPasadas()
    {
        return this.scenaPasadas;
    }
    public void BuscarTexto()
    {
        textCoin = GameObject.FindGameObjectWithTag("CoinText").GetComponent<TextMeshProUGUI>();
        ActualizarMoneda();
    }
    private void ActualizarMoneda()
    {
        if (coins < 10)
        {
            textCoin.text = "0" + coins.ToString();
        }
        else
        {
            textCoin.text = coins.ToString();
        }
    }
    private void LoadCoins()
    {
        coins = PlayerPrefs.GetInt(CoinsKey, 5);
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt(CoinsKey, coins);
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        ActualizarMoneda();
        SaveCoins();
        AudioManager.instance.ReproducirMoneda();
    }
    public void RestarCoins(int amount)
    {
        coins -= amount;
        ActualizarMoneda();
        SaveCoins();
    }
    public int GetCoins()
    {
        return coins;
    }

}
