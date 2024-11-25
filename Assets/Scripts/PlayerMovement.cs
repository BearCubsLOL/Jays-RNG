using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerWalkSpeed = 8f;
    [SerializeField] private float playerSprintSpeed = 5f;
    [SerializeField] private float playerCrouchSpeed = 2.5f;
    [SerializeField] private float cameraWalkingShakeSpeed = 2f;
    [SerializeField] private float playerJumpSpeed = 7f;
    [SerializeField] private float gravity = 10f;
    [SerializeField] private float playerLookSpeed = 2f;

    [SerializeField] private float playerLookXLimit = 45f;
    [SerializeField] private float playerRotationX = 0f;

    [SerializeField] private Vector2 currentMousePos;
    [SerializeField] private Vector2 newMousePos;
    [SerializeField] private Vector2 moveMouse;
    [SerializeField] private Quaternion oldCameraPos;
    [SerializeField] private Quaternion newCameraPos;


    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerCamera;

    [SerializeField] private bool canWalk = true;
    [SerializeField] private bool canMoveCamera = true;
    [SerializeField] private bool isWalking = false;
    [SerializeField] private bool baseState = true;

    public string[] pointOfViews = {"First Person", "Second Person", "ThirdPerson"};
    public string currentPointOfView;

    void Temp()
    {
        currentPointOfView = pointOfViews[0];
    }

    void Walk()
    {
        if (canWalk)
        {
            if (Input.GetKey(KeyCode.W))
            {
                isWalking = true;
                player.transform.position += new Vector3(0f, 0f, playerWalkSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                isWalking = true;
                player.transform.position -= new Vector3(0f, 0f, playerWalkSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                isWalking = true;
                player.transform.position -= new Vector3(playerWalkSpeed * Time.deltaTime, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                isWalking = true;
                player.transform.position += new Vector3(playerWalkSpeed * Time.deltaTime, 0f, 0f);
            }
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                isWalking = false;
            }
        }
    }
    void MoveCameraFirstPerson()
    {
        if (canMoveCamera)
        {
            
        }
    
        playerCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.8f, player.transform.position.z);
    }

    void CameraCheck()
    {
        if (currentPointOfView == "First Person")
        {
            MoveCameraFirstPerson();
        }
        else if (currentPointOfView == "Second Person")
        {
            Debug.Log("idk");
        }
        else if (currentPointOfView == "Third Person")
        {
            Debug.Log("idkman");
        }
    }

    void PlayerAlign()
    {
        if (baseState)
        {
            player.transform.localEulerAngles = new Vector3(0f, 0f, 0f) * Time.deltaTime * 45;
        }
    }

    void Update()
    {
        Temp();

        Walk();

        CameraCheck();

        PlayerAlign();
    }
}