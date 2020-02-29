using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform player;
    public Vector2 limit1;
    public Vector2 limit2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y, -1);
        transform.position = pos;
        if(transform.position.x < limit1.x)
        {
            transform.position = new Vector3(limit1.x, transform.position.y, transform.position.z); 
        }
        else if (transform.position.x > limit2.x)
        {
            transform.position = new Vector3(limit2.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y < limit1.y)
        {
            transform.position = new Vector3(transform.position.x, limit1.y, transform.position.z);
        }
        else if (transform.position.y > limit2.y)
        {
            transform.position = new Vector3(transform.position.x, limit2.y, transform.position.z);
        }
    }
}
