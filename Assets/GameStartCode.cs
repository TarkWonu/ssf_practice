using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartCode : MonoBehaviour
{
    public void StartGame()
    {
        FadeManager.Instance.LoadScene("beforestage");
    }
}
