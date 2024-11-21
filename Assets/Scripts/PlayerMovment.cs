using System.Collections;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float cameraWalkingShakeSpeed = 2f;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerCamera;

    [SerializeField] private bool isWalking = false;
    [SerializeField] private bool baseState = true;

    void Walk()
    {
        if (Input.GetKey(KeyCode.W))
        {
            isWalking = true;
            player.transform.position += new Vector3(0f, 0f, playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            isWalking = true;
            player.transform.position -= new Vector3(0f, 0f, playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            isWalking = true;
            player.transform.position -= new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            isWalking = true;
            player.transform.position += new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
        }
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            isWalking = false;
        }
    }

    void cameraFollow()
    {
        playerCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2.9f, player.transform.position.z - 3.5f);
    }

    void playerAlign()
    {
        if (baseState)
        {
            player.transform.localEulerAngles = new Vector3(0f, 0f, 0f) * Time.deltaTime * 45;
        }
    }

    void Update()
    {
        Walk();

        cameraFollow();

        playerAlign();
    }
}
