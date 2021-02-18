using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomScaleFollow : MonoBehaviour
{
    public GameObject head;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(head.transform.position.x - transform.position.x, 0, head.transform.position.z - transform.position.z);
        rigidbody.AddForce(direction);
    }
}
