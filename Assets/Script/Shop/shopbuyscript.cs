using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class shopbuyscript : MonoBehaviour
{
    int cost = 5;

    public void HealthUpgrade()
    {
        if (GameManager.instance.coin >= cost)
        {
            GameManager.instance.coin -= cost;
            GameManager.instance.player_maxhp++;

        }
        Debug.Log("123");
    }

    public void AttackPowerUpgrade()
    {
        if (GameManager.instance.coin >= cost)
        {
            GameManager.instance.coin -= cost;
            GameManager.instance.bulletdamage++;

        }
    }

    public void maxammoUpgrade()
    {
        if (GameManager.instance.coin >= cost)
        {
            GameManager.instance.coin -= cost;
            GameManager.instance.maxammo++;

        }
    }

    public void MoveNextStage()
    {
        FadeManager.Instance.LoadScene("beforestage");
    }
}
