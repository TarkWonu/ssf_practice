using UnityEngine;
using UnityEngine.UI;

public class Bosshealthbar : MonoBehaviour
{
    Slider slider;
    Boss_base boss;

    void Start()
    {
        slider = GetComponent<Slider>();
        boss = GameObject.FindWithTag("Boss").GetComponent<Boss_base>();
        slider.maxValue = boss.boss_maxhp;
        slider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = boss.boss_hp;
    }
}

