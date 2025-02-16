using UnityEngine;

public class TriggerZoneDisabler : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Some object entered the trigger zone.");
        Debug.Log("Colliding object: " + other.gameObject.name);
        
        
            if (other.gameObject.name == "CorrectShoes")
            {
                object1.SetActive(false);
                Debug.Log("object1 disabled");
            }
            else if (other.gameObject.name == "CorrectJacket")
            {
                object2.SetActive(false);
                Debug.Log("object2 disabled");
            }
            else if (other.gameObject.name == "CorrectHat")
            {
                object3.SetActive(false);
                Debug.Log("object3 disabled");
            }
        
    }
}