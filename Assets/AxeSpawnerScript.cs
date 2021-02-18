using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSpawnerScript : MonoBehaviour
{
    public int _count = 0;
    public GameObject AxePrefab;
    private List<GameObject> axeList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Axe"))
        {
            _count--;
            SpawnNewAxe();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Axe"))
        {
            _count++;
        }
    }

    private void SpawnNewAxe()
    {
        if (_count < 1000)
        {
            GameObject object1 = Instantiate(AxePrefab, transform.position, transform.rotation);
            axeList.Add(object1);
        }
    }
}
