using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject John;

    private float LastShoot;
    private int Health = 3;

    private void Update()
    {
        if (John == null) return;

        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); // hướng quái về John
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 0.5f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
        // Vector3 direction ;
        // if (transform.localScale.x == 1.0f) direction = Vector2.right; // đổi hướng đạn
        // else direction = Vector2.left;

        // GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        // bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit() // chết sau 5 đòn đạn
    {
        Health = Health - 1;
        if (Health == 0)
        {
            Destroy(gameObject);
            ScoreScript.scoreValue += 1;
        }
    }
}
