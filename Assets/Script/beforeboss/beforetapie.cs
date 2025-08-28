using UnityEngine;

using UnityEngine.UI;
public class beforetapieboss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject goImage = GameObject.Find("tapie");
        Color color = goImage.GetComponent<Image>().color;
        color.a = 0f;

        if (GameManager.instance.stage_level == Stage.tapie)
        {
            color.a = 1f;
        }
        goImage.GetComponent<Image>().color = color;
    }

}