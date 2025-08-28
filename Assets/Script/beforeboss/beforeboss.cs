using UnityEngine;
using UnityEngine.SceneManagement;

public class beforeboss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void startstage()
    {
        if (GameManager.instance.stage_level == Stage.para)
        {
            FadeManager.Instance.LoadScene("Para");
        }
        if (GameManager.instance.stage_level == Stage.ana)
        {
            FadeManager.Instance.LoadScene("AnA");
        }
        if (GameManager.instance.stage_level == Stage.tapie)
        {
            FadeManager.Instance.LoadScene("Tapie");
        }
    }
}
