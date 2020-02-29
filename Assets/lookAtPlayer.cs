using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dis = target.position - transform.position;
        float angle = (Mathf.Atan2(dis.y, dis.x) * Mathf.Rad2Deg) + -90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
