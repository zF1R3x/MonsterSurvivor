using Unity.VisualScripting;
using UnityEngine;

public class XPorb : MonoBehaviour
{
    public float xpValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {           
            collision.GetComponent<PlayerXp>().AddXP(xpValue);
            gameObject.SetActive(false);
        }
    }
}
