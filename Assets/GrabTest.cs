using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabAction : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    public string objectName;  // Set this to Object1, Object2, or Object3 in the Inspector

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }

    // This function runs when the object is grabbed
    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log($"{gameObject.name} was grabbed!");
        GameManager.Instance.SetObjectStatus(gameObject.name, true);
    }
}