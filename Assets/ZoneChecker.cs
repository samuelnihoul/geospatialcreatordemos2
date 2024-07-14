using TMPro;
using UnityEngine;

public class ZoneChecker : MonoBehaviour
{
    private TextMeshProUGUI t;
    [SerializeField]
    public string zone = "No Zone";
    public float objectif = 40f; 
    // Start is called before the first frame update
    void Start()
    {
        t = GameObject.FindGameObjectWithTag("GameController").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
      /* if(Vector3.Distance(Camera.main.transform.position,transform.position) < objectif)
        {
            Debug.Log(gameObject.name);
            t.text = zone;
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {

        //check if the collider is the camera
        if (other.CompareTag("MainCamera"))
        {
            t.text = zone;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            t.text = "No Zone";
        }
    }
   /* private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, objectif);
    }*/

}
