using UnityEditor;
using UnityEngine;

public class CutCollision : MonoBehaviour
{
    public GameObject prefabRoot;
    public treeController rootTreeController;
    // Start is called before the first frame update
    void Start()
    {
        //rootTreeController = PrefabUtility.GetNearestPrefabInstanceRoot(gameObject).GetComponent<treeController>();
        rootTreeController =prefabRoot.GetComponent<treeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        rootTreeController.RegisterCut(gameObject, other, 1.0f, true);
    }

    public void OnTriggerExit(Collider other)
    {
        rootTreeController.RegisterCut(gameObject, other, 1.0f, false);
    }
}
