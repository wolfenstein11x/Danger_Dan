using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] GameObject explosionFX = null;
    [SerializeField] float explosionTime = 0.5f;
    [SerializeField] float lifeTime = 3f;

    private float direction;

    // need short time delay between collision and destroying bullet
    private float timeOffset = 0.1f; 
    

    // Start is called before the first frame update
    void Start()
    {
        // match bullet orientation with direciton player is facing
        direction = FindObjectOfType<Player>().transform.localScale.x;
        transform.localScale = new Vector2(Mathf.Sign(direction), 1f);

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * direction * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision: " + collision);
        GameObject explosion = Instantiate(explosionFX, transform.position, transform.rotation);
        Destroy(explosion, explosionTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // for some reason the bullet hits itself, so this is a workaround to fix that
        if (collision.tag == "projectile") { return; }

        GameObject explosion = Instantiate(explosionFX, transform.position, transform.rotation);
        Destroy(explosion, explosionTime);

        Destroy(gameObject, timeOffset);
    }
}
