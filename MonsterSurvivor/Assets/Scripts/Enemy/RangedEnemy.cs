using System.Collections;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer sr;
    public GameObject projectilePrefab;
    public float fireRate;
    private float timer=0;
    private float temp;
    private Vector2 dir;
    private Enemy enemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        enemy = GetComponent<Enemy>();
        temp = enemy.speed;
    }

    void Update()
    {
        if (player == null) return;

        
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            Shoot();
            timer = 0;
            StartCoroutine(StandStill());
        } 
    }
    private IEnumerator StandStill()
    {
        enemy.speed = 0;
        yield return new WaitForSeconds(0.3f);
        enemy.speed = temp;
    } 

    private void Shoot()
    {
        dir = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(0, 0, angle);
        GameObject p = Instantiate(projectilePrefab, transform.position, rot);

        p.GetComponent<EnemyProjectile>().direction = dir;
    }

}
