using UnityEngine;
using UnityEngine.UI;

public class Enemy_healthbar : MonoBehaviour
{
    [SerializeField] Slider hp_bar;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Base enemy = gameObject.GetComponent<Enemy_Base>();
        if (enemy != null)
        {
            enemy.OnHealthChanged += UpdateHealthBar;
        }
        else
        {
            Debug.LogError("대충 enemy에 적 코드가 읎다 그런 이야기");
        }
    }

    void UpdateHealthBar(float h, float max_h)
    {
        hp_bar.value = h / max_h;
    }
}
