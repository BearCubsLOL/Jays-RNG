using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private GameObject player;
    [SerializeField] private bool isWalking = true;

    void Walk()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += new Vector3(0f, 0f, playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position -= new Vector3(0f, 0f, playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position -= new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
        }
    }

    void CameraShake()
    {

    }

    void Update()
    {
        Walk();

        CameraShake();
    }
}
