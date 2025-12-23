using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        if (mousePos.x > transform.position.x)
            sr.flipX = false; 

        else
            sr.flipX = true;  
    }
}
