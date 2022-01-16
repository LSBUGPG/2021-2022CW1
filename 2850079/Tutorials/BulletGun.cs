using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    public float range;
    public Transform target;
    Vector2 direction;
    public GameObject gun;
    public GameObject bullet;
    public float fireRate;
    public Transform shootPoint;
    public float bulletSpeed;
    bool detected;
    public float nextTimeToFire;
    RaycastHit2D hit;
    public LayerMask player;

    void Update()
    {
        Vector2 targetposition = target.position;
        direction = targetposition - (Vector2)transform.position;
        gun.transform.up = direction;
        CheckIfPlayer();
    }

    private void CheckIfPlayer()
    {
        hit = Physics2D.Raycast(transform.position, direction, range, player);
        detected = hit ? true : false;
        if (detected)
        {
            if (hit.rigidbody == target.GetComponent<Rigidbody2D>() && (Time.time > nextTimeToFire))
            {

                nextTimeToFire = Time.time + 1 / fireRate;
                shoot();
            }
        }
    }

    void shoot()
    {
        GameObject BulletIns = Instantiate(bullet, shootPoint.position, gun.transform.rotation);
        BulletIns.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        AudioSource audio = GetComponentInParent<AudioSource>();
        audio.Play();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

