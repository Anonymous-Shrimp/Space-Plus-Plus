using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float health = 100;
    public float speed = 8;
    public float rotSpeed = 70;
    private float orginalSpeed;
    public pause pause;
    [Space]
    public GameObject bullet;
    public GameObject missile;
    public Transform barrel;
    public int crashDamage = 20;
    public int explodeDamage = 50;

    public GameObject deathScreen;
    public pause pausey;
    public GameObject explosion;
    [Space]
    public Image healthBar;
    [Space]
    public float ammo;
    public Image ammoImage;
    public bool ammoCooldown = false;
    
    [Space]
    public int missileAmmo = 100;
    public int bulletAmmo = 1;
    [Space]
    public float boost;
    public Image boostImage;
    public bool boostCooldown = false;
 


    // Start is called before the first frame update
    void Start()
    {
        orginalSpeed = speed;
        deathScreen.SetActive(false);
        ammo = 100;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (ammo <= 0.5)
        {

            ammoCooldown = true;
            ammoImage.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        if (ammo >= 100)
        {
            ammoCooldown = false;
            ammoImage.GetComponent<Image>().color = new Color32(0, 255, 0, 255);

        }
        if (boost <= 0)
        {
            boostCooldown = true;
            boostImage.GetComponent<Image>().color = new Color32(255, 0, 0, 255);

        }
        if(boost >= 100)
        {
            boostCooldown = false;
            boostImage.GetComponent<Image>().color = new Color32(0, 255, 0, 255);

        }
        if (Input.GetKey(KeyCode.K) && ammo >= 0 && !ammoCooldown && !pause.isPaused)
        {
            GameObject clone1 = Instantiate(bullet, barrel.position, barrel.rotation);
            ammo -= bulletAmmo;
            ammoImage.fillAmount = ammo / 100;
            Destroy(clone1, 1);
            if (ammo <= 0)
            {

                ammoCooldown = true;
                ammoImage.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            }
        }
        else if (Input.GetKeyDown(KeyCode.J) && ammo >= missileAmmo && !ammoCooldown && !pause.isPaused)
        {
            GameObject clone2 = Instantiate(missile, barrel.position, barrel.rotation);
            ammo -= missileAmmo;
            ammoImage.fillAmount = ammo / 100;
            Destroy(clone2, 3);
        }
        else
        {
            if (ammo < 100)
            {
                if (ammoCooldown)
                {
                    ammo += 0.5f;
                }
                else
                {
                    ammo = 100f;
                }
                ammoImage.fillAmount = ammo / 100;
            }
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftShift)) && !pause.isPaused)
        {
            if (!boostCooldown)
            {
                speed = orginalSpeed * 3;
                boost -= 1;
                boostImage.fillAmount = boost / 100;

            }
            else
            {
                boost += 0.5f;
                boostImage.fillAmount = boost / 100;
                speed = orginalSpeed;
            }
        }
        else
        {
            if (boost < 100)
            {
                boost += 0.5f;
                boostImage.fillAmount = boost / 100;
                speed = orginalSpeed;
            }
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(0, v);
        transform.Translate(movement * Time.deltaTime * speed);
        Vector3 rot = new Vector3(0, 0, -1 * h);
        transform.Rotate(rot * Time.deltaTime * speed * 50);


        /*
        if (health < 100)
        {
            health += 0.05f;
            healthBar.fillAmount = health / 100;
        }*/
        
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            takeDamage(crashDamage);
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            takeDamage(1);
            Destroy(collision.gameObject);
        }else if (collision.gameObject.CompareTag("Health"))
        {
            health += 25;
            healthBar.fillAmount = health / 100;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("explode"))
        {
            takeDamage(explodeDamage);

        }

    }



    void takeDamage(int theDamage)
    {
        health -= theDamage;
        
        if (health <= 0)
        {
            deathScreen.SetActive(true);
            GameObject clone = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            pausey.disabled = true;
            Destroy(clone, 0.1f);
            Destroy(gameObject);
        }
        healthBar.fillAmount = health / 100;
    }
}
