using Unity.VisualScripting;
using UnityEngine;

public class AutoWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate;
    public AudioClip shootClip; 
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {

            Shoot();
            SoundManager.instance.PlaySoundClip(shootClip, transform, 1f);
            timer = 0;
        }
    }

    private void Shoot()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3 dir = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(0, 0, angle);

        GameObject p = Instantiate(projectilePrefab, transform.position, rot);

        p.GetComponent<Projectile>().direction = dir;
    }
}
