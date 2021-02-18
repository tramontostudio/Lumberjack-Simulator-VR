using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SteamPlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public SteamVR_Action_Vector2 input;
    public float speed = 1.0f;
    public GameObject head;
    public GameObject bodyCollider;

    public float _rotationSpeed = 60;

    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(0, 0, input.axis.y));
        //Vector3 toHead = Vector3.MoveTowards(head.transform.position, gameObject.transform.position, 10.0f);
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0) * Time.deltaTime);
        this.rotation = new Vector3(0, input.axis.x * _rotationSpeed * Time.deltaTime, 0);
        this.transform.Rotate(this.rotation);
    }
}
