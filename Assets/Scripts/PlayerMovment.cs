using System.Collections;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float cameraShakeSpeed = 2f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private bool isWalking = false;

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
    }

    private IEnumerator CameraShake()
    {
        while (isWalking)
        {
            playerCamera.transform.position += new Vector3(0f, cameraShakeSpeed * Time.deltaTime, 0f);
            yield return new WaitForSeconds(0.5f);
            playerCamera.transform.position -= new Vector3(0f, cameraShakeSpeed * Time.deltaTime, 0f);
        }
    }

    void Update()
    {
        Walk();

        CameraShake();
    }
}
