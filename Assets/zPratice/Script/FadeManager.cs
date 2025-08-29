using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    public float fadeDuration = 1.0f;
    private Image fadePanel;

    public static FadeManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        fadePanel = GameObject.Find("FadeInOutPanel")?.GetComponent<Image>();

        if (fadePanel == null)
        {
            Debug.LogError("Fade Panel을 찾을 수 없습니다! Canvas에 FadePanel UI Image가 있는지 확인하세요.");
        }
        else
        {
            fadePanel.color = Color.black;
            StartCoroutine(FadeIn());
        }
    }

    public void LoadScene(string sceneName)
    {
        // 씬 전환 시작 시 게임을 멈춤
        Time.timeScale = 0f;
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadePanel.gameObject.SetActive(false);
        
        // 페이드인 완료 후 게임을 다시 시작
        Time.timeScale = 1f; 
    }

    private IEnumerator FadeOut(string sceneName)
    {
        fadePanel.gameObject.SetActive(true);
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime; 
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}
