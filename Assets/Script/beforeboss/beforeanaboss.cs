using UnityEngine;

using UnityEngine.UI;
public class beforeanaboss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject goImage = GameObject.Find("ana");
        Color color = goImage.GetComponent<Image>().color;
        color.a = 0f;
        
        if (GameManager.instance.stage_level == Stage.ana)
        {
            color.a = 1f;
        }
        goImage.GetComponent<Image>().color = color;
    }

}
