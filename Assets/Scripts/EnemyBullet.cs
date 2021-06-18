using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float lifeTime = 3f;
    [SerializeField] GameObject explosionFX = null;
    [SerializeField] float explosionTime = 0.5f;

    private Vector2 target;

    // need short time delay between collision and destroying bullet
    private float timeOffset = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().transform.position;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        float step = bulletSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        // if the bullet misses, blow it up so it's not just floating there
        if (Mathf.Abs(transform.position.x - target.x) <= Mathf.Epsilon) { ExplodeBullet(); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // to prevent enemy from accidentally shooting itself
        if (collision.tag == "Enemy") { return; }

        ExplodeBullet();
    }

    private void ExplodeBullet()
    {
        GameObject explosion = Instantiate(explosionFX, transform.position, transform.rotation);
        Destroy(explosion, explosionTime);

        Destroy(gameObject, timeOffset);
    }
}
