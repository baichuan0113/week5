using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class MovementManager : MonoBehaviour
{
    private float xInput;
    private float yInput;
    private float movementSpeed = 10f;

    private PhotonView myView;

    private InputData inputData;
    //[SerializeField] private GameObject myObjectToMove;

    private Rigidbody myRB;
    private Transform myXRRig;
    private GameObject myChild;

    // Start is called before the first frame update
    void Start()
    {
        myView = GetComponent<PhotonView>();

        myChild = transform.GetChild(0).gameObject;
        GameObject myXrOrigin = GameObject.Find("XR Origin");
        inputData = myXrOrigin.GetComponent<InputData>();
        
        myRB = myChild.GetComponent<Rigidbody>();

        myXRRig = myXrOrigin.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (myView.IsMine)
        {
            myXRRig.position = myChild.transform.position;

            if (inputData.rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 movement))
            {
                xInput = movement.x;
                yInput = movement.y;
            }
        }
        
    }

    private void FixedUpdate()
    {
        myRB.AddForce(xInput * movementSpeed, 0, yInput * movementSpeed);
    }
}
