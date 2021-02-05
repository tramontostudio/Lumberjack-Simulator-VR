using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeController : MonoBehaviour
{
    Rigidbody rigidbodyComponent;
    public GameObject partToFall;
    public float treeFirstHitPoints;
    public float treeSecondHitPoints;
    private Settings settings;
    public bool fallen = false;
    private bool updated = false;
    private DateTime cooldownStart;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = partToFall.gameObject.GetComponentInParent<Rigidbody>();
        Settings[] settingsArray = FindObjectsOfType<Settings>();

        if(settingsArray.Length >0)
        {
            settings = settingsArray[0];

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (settings.updated && !updated)
        {
            treeFirstHitPoints = settings.cut1Count;
            treeSecondHitPoints = settings.cut2Count;
            updated = true;
        }
    }

    public void RegisterCut(GameObject cuttedObject, Collider other, float strength)
    {

        if (DateTime.Now.Subtract(cooldownStart).Seconds > 1)
        {
            if (other.gameObject.tag == "AxBlade")
            {
                if (treeFirstHitPoints > 0)
                {
                    if (cuttedObject.name == "cut1")
                    {
                        treeFirstHitPoints -= strength;
                        cooldownStart = DateTime.Now;
                        Debug.Log("First hit points: " + treeFirstHitPoints);
                        if (treeFirstHitPoints <= 0)
                        {
                            Debug.Log("Tree can now be cut on the other side");
                            cuttedObject.SetActive(false);
                        }
                    }
                    else
                    {
                        Debug.Log("Wrong cut place: " + cuttedObject.name);
                    }
                }
                else
                {
                    if (treeSecondHitPoints > 0)
                    {
                        if (cuttedObject.name == "cut2")
                        {
                            treeSecondHitPoints -= strength;
                            cooldownStart = DateTime.Now;
                            Debug.Log("Second hit points: " + treeSecondHitPoints);
                            if (treeSecondHitPoints <= 0)
                            {
                                cuttedObject.SetActive(false);
                                Debug.Log("Tree can now fall");
                                TreeFall();
                            }
                        }
                        else
                        {
                            Debug.Log("Wrong cut place: " + cuttedObject.name);
                        }
                    }
                    else
                    {
                        if (!fallen)
                        {
                            Debug.Log("Tree should now fall");
                            TreeFall();
                            fallen = true;
                        }
                    }
                }
            }
        }
        else
        {
            Debug.Log("Wrong collider tag: " + other.gameObject.tag);
        }
            
    }

    private void TreeFall()
    {
        //rigidbodyComponent.constraints = RigidbodyConstraints.FreezeRotationZ;
        rigidbodyComponent.isKinematic = false;
        //rigidbodyComponent.AddForceAtPosition(new Vector3(0.0f, 1.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f));
        settings.cuttedTrees++;
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "AxBlade")
    //    {

    //        //odblokowanie rotacji po x
    //        rigidbodyComponent.constraints = RigidbodyConstraints.FreezeRotationY;
    //    }
    //}

}
