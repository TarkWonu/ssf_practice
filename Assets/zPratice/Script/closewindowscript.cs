using UnityEngine;

public class closewindowscript : MonoBehaviour
{
    bool close = false;
    void Start()
    {
        transform.parent.localScale = new Vector3(1f, 0, 1f);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider != null && hit.collider.transform == this.transform) { close = true; }
        }
        if (close)
        {
            if(transform.parent.localScale.y > 0f)transform.parent.localScale -= new Vector3(0f, 30f, 0f) * Time.deltaTime;
            if(transform.parent.localScale.y <= 0f) Destroy(transform.parent.gameObject);
        }
        else
        {
            if (transform.parent.localScale.y < 1f) { transform.parent.localScale += new Vector3(0f, 20f, 0f) * Time.deltaTime; }
            else { transform.parent.localScale = new Vector3(1f, 1f, 1f); }
        }
    }
}
