using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour
{
    public GameObject bullet;
    public Transform barrel;
    private float wait = 0;
    public float rate = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        wait += Time.deltaTime;
        if (wait >= rate)
        {
            wait = 0;
            GameObject clone = Instantiate(bullet, barrel.position, barrel.rotation);
            Destroy(clone, 1);
        }


    }
    
}
