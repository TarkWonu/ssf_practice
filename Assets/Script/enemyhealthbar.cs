using UnityEngine;
using UnityEngine.UI;
public class enemyhealthbar : MonoBehaviour
{
    private Slider healthbar;
    
    public void updatehealthbar(float health, float max)
    {
        healthbar.value = health / max;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
