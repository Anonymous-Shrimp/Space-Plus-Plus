using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    public int health = 100;
    public float speed = 8;
    public int bulletDamage = 10;
    public int missileDamage = 50;
    public int crashDamage = 100;
    public int explodeDamage = 50;
    public scoreManager player;
    public GameObject explosion;
    
    

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0, speed);
        transform.Translate(movement * Time.deltaTime * speed);

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            takeDamage(crashDamage);
        }
        if (collision.gameObject.CompareTag("Bullet2"))
        {
            takeDamage(bulletDamage);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Missile"))
        {
            takeDamage(missileDamage);
            GameObject clone = Instantiate(explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            Destroy(clone, 0.1f);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Health"))
        {
            health += 25;
            
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("explode"))
        {
            takeDamage(explodeDamage);
        }
    }

    void takeDamage(int theDamage)
    {
        health -= theDamage;
        if(health <= 0)
        {
            player.score += 1;
            GameObject clone = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(clone, 0.1f);
            Destroy(gameObject);
            
        }
    }
}
