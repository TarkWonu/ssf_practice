using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class shopbuyscript : MonoBehaviour
{
    int cost = 5;

    public void HealthUpgrade()
    {
        //코드 작성 해주세요!
        
    }

    public void AttackPowerUpgrade()
    {
        //코드 작성 해주세요!
    }

    public void maxammoUpgrade()
    {
        //코드 작성 해주세요!
    }

    public void MoveNextStage()
    {
        FadeManager.Instance.LoadScene("beforestage");
    }
}
