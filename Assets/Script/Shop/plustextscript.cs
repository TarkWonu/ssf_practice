using TMPro;
using UnityEngine;

public class plustextscript : MonoBehaviour
{
    public int code;
    TMP_Text tmp;
    void Start()
    {
        tmp = GetComponent<TMP_Text>();
    }

    void Update()
    {
        switch (code)
        {
            case 0:{
                if(GameManager.instance.player_maxhp<6)tmp.text="+0";
                else tmp.text = "+"+(GameManager.instance.player_maxhp-5).ToString();
                break;
            }
            case 1:{
                if(GameManager.instance.bulletdamage<2)tmp.text="+0";
                else tmp.text = "+"+(GameManager.instance.bulletdamage-1).ToString();
                break;
            }
            case 2:
                {
                if(GameManager.instance.maxammo<6)tmp.text="+0";
                else tmp.text = "+"+(GameManager.instance.maxammo-5).ToString();
                break;
            }
        }
    }
}
