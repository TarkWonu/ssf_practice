using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StageUIController : MonoBehaviour
{
    [SerializeField] Slider hp_bar;
    [SerializeField] TMP_Text bullettxt;
    [SerializeField] TMP_Text cointxt;

    PlayerAttack player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
