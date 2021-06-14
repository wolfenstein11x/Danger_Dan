using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] GameObject explosionFX = null;
    [SerializeField] float explosionTime = 0.5f;


    public float lifeTime = 3f;

    private float direction;

    // need short time delay between collision and destroying bullet
    private float timeOffset = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        direction = FindObjectOfType<EnemyMovement>().direction;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        // multiply by -direction because enemies oriented front side left
        transform.Translate(Vector2.right * -direction * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // to prevent enemy from accidentally shooting itself
        if (collision.tag == "Enemy") { return; }

        GameObject explosion = Instantiate(explosionFX, transform.position, transform.rotation);
        Destroy(explosion, explosionTime);

        Destroy(gameObject, timeOffset);
    }
}
