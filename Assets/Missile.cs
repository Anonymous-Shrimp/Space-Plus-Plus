using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 10;
    private bool homing = false;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0, speed);
        transform.Translate(movement * Time.deltaTime * speed);
        if (homing)
        {
            Vector3 dis = target.position - transform.position;
            float angle = (Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg) + -90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && homing == false)
        {
            homing = true;
            target = collision.gameObject.transform;
        }
    }
}
