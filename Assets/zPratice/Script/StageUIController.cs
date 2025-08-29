using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StageUIController : MonoBehaviour
{
    Slider hp_bar;
    TMP_Text bullettxt;
    TMP_Text cointxt;

    PlayerAttack player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp_bar = GetComponentInChildren<Slider>();
        bullettxt = GameObject.Find("Bullet").GetComponent<TMP_Text>();
        cointxt = GameObject.Find("Coin").GetComponent<TMP_Text>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        hp_bar.value = (float)GameManager.instance.player_hp / (float)GameManager.instance.player_maxhp;
        bullettxt.text = "Bullet:"+(player.reloading ? "reloading...." : player.ammo.ToString() + "/" + GameManager.instance.maxammo.ToString());
        cointxt.text = GameManager.instance.coin.ToString()+" coin";
    }
}
