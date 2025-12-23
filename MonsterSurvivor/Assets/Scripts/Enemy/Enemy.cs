using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;
    public int health = 1;  
    public GameObject xpOrb;
    private Transform player;
    private SpriteRenderer sr;
    [SerializeField] private PlayerXp playerXp;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        if (playerXp.level > 12)
        {
            health++;
        }
        if (playerXp.level > 18)
        {
            health++;
        }
    }

    void Update()
    {
        if (player == null) return;
        
        Vector2 dir = (player.position - transform.position).normalized;
        transform.position += (Vector3)dir * speed * Time.deltaTime;

        if (player.position.x > transform.position.x)
            sr.flipX = false;
        else
            sr.flipX = true;
    }

    // Call this when enemy takes damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(Damaged());
        
        if (health <= 0)
        {
            Die();
        }
    }
    private IEnumerator Damaged()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }

    void Die()
    {
        Instantiate(xpOrb, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
    PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
    if (playerHealth != null)
    {
        playerHealth.TakeDamage(1);  // deal 1 damage
    }
    }


}
