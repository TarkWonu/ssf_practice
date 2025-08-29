using UnityEngine;

public class PlayerMotionController : MonoBehaviour
{
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (x != 0 || y != 0)
        {
            anim.SetBool("isMove", true);
            anim.SetFloat("dirX", x);
            anim.SetFloat("dirY", y);
        }
        else
        {
            anim.SetBool("isMove", false);
        }
    }
}
