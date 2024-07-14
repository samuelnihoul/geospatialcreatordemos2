using UnityEngine;

public class ARCameraMovement : MonoBehaviour
{
    public float speed = 100.0f; // Adjust this to control movement speed
    private void Start()
    {
        transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        Debug.Log("Moved to respawn");
    }
    void Update()
    {
        // Get input from arrow keys or WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Get input for vertical movement (up and down)
        float upDownInput = 0f;
        float rotationUp = 0f;
        if (Input.GetKey(KeyCode.Space)) // Move up

    {
            upDownInput = 1f;

        Debug.Log("Space");

        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) // Move down
            upDownInput = -1f;
        float rotationLeft = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            rotationLeft = 1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotationLeft = -1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rotationUp = 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rotationUp = -1f;
        }
        // Calculate movement direction based on input
        Vector3 movement = new Vector3(horizontalInput, upDownInput, verticalInput);
        Vector3 rotation = new Vector3(rotationUp, rotationLeft);


        // Translate the position of the camera
        transform.Translate(movement * speed * Time.deltaTime);
        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
