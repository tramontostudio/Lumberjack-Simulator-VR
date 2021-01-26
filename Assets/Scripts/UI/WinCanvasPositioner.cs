using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCanvasPositioner : MonoBehaviour
{
    public GameObject PlayerHead;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = PlayerHead.transform.position + PlayerHead.transform.forward;
        gameObject.transform.rotation = PlayerHead.transform.rotation;
    }
}
