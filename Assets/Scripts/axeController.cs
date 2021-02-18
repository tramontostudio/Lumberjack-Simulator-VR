using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class axeController : MonoBehaviour
{
    Throwable throwable;
    GameObject axeSpawner;

    // Start is called before the first frame update
    void Start()
    {
        axeSpawner = GameObject.Find("AxeSpawner");
        throwable = gameObject.GetComponent<Throwable>();
        throwable.onDetachFromHand.AddListener((UnityEngine.Events.UnityAction)axeSpawner.GetComponent<AxeSpawnerScript>().AxeDetached);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
