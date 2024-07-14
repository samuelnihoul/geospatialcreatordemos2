using TMPro;
using UnityEngine;

public class ZombieMover : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    public int hp = 5;
    [SerializeField]
    private float altitudeCameraOffset = -2f;
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (Camera.main.transform.position - transform.position).normalized;
        direction.y = 0; // Set y component to zero to move only horizontally
        transform.Translate(direction * speed * Time.deltaTime, Space.World); // Use World space to move horizontally
        transform.rotation = Quaternion.LookRotation(direction);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        Vector3 a = transform.position;
        a.y = Camera.main.transform.position.y + altitudeCameraOffset;
        transform.position = a;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            hp--;
            Destroy(collision.gameObject);
        }
        if (collision.transform.CompareTag("MainCamera"))
        {

            GameObject.FindGameObjectWithTag("hintText").GetComponent<TextMeshProUGUI>().text = "you got bitten by zombies";
        }
    }

}
