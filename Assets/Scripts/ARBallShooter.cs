using UnityEngine;

public class ARBallShooter : MonoBehaviour
{
    public float force = 500.0f;

    [SerializeField]
    private float frequency = 0.5f;

    [SerializeField]
    private Vector3 initialOffset = new Vector3(0, 0, 1);

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private float lifeInSeconds = 15.0f;

    public bool enableShooting = true;

    private Coroutine shootingCoroutine;


    private void OnDisable()
    {
        StopCoroutine(shootingCoroutine);
    }

    private void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {
            var ball = Instantiate(ballPrefab, Camera.main.transform.position, Camera.main.transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * force);
            ball.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Destroy(ball, lifeInSeconds);
        }
    }
}