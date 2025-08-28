using UnityEngine;
using UnityEngine.SceneManagement;

public class beforestage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void startstage()
    {
        FadeManager.Instance.LoadScene("Stage");
    }
}
