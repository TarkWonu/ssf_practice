using UnityEngine;
using TMPro;
public class MoneyUI : MonoBehaviour
{
    TMP_Text coin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coin = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coin.text = "Coin"+GameManager.instance.coin.ToString();
    }
}
