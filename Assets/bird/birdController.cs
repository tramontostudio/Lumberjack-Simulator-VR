using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdController : MonoBehaviour
{
    public float speed = 1;
    public float radius = 5;
    float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    //float speed = (2 * Mathf.PI) / 5 //2*PI in degress is 360, so you get 5 seconds to complete a circle

    void Update()
    {
        angle += speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
        transform.position = new Vector3(transform.position.x + Mathf.Cos(angle) * radius, transform.position.y + Mathf.Cos(angle*50f)/80f, transform.position.z + Mathf.Sin(angle) * radius);
        transform.Rotate(0f, -(speed * Time.deltaTime )* 180/Mathf.PI, 0f);
    }
}
