using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GvrControllerVisual gvrControllerVisual;
    public CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gvrControllerVisual.displayState.touching)
        {
            Vector2 touchPos = gvrControllerVisual.displayState.touchPos;
            transform.position+= new Vector3((touchPos.x) * Time.deltaTime, 0, (touchPos.y) * Time.deltaTime);
        }

        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(transform.localPosition.x + horizontalInput, transform.localPosition.y + verticalInput,0);
        transform.position = move;
        // characterController.Move(move);

        //transform.position += new Vector3((horizontalInput) * Time.deltaTime, 0, (verticalInput) * Time.deltaTime);

    }

}

