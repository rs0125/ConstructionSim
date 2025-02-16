using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabAction : MonoBehaviour
{
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    public string objectName;  // Set this to Object1, Object2, or Object3 in the Inspector
    public Material miscMaterial; // Assign the material you want to change

    private Color defaultColor;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (miscMaterial != null)
        {
            defaultColor = miscMaterial.color;
        }
    }

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    // This function runs when the object is grabbed
    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log($"{gameObject.name} was grabbed!");

        // Check if the object's name contains "wrong" (case insensitive)
        if (gameObject.name.ToLower().Contains("wrong"))
        {
            if (miscMaterial != null)
            {
                miscMaterial.color = Color.red;
            }
        }
        else
        {
            GameManager.Instance.SetObjectStatus(gameObject.name, true);
            if (miscMaterial != null)
            {
                miscMaterial.color = Color.green;
            }
        }
    }

    // This function runs when the object is released
    private void OnRelease(SelectExitEventArgs args)
    {
        // Revert the material's color if it was changed for a "wrong" object
        if (miscMaterial != null)
        {
            miscMaterial.color = defaultColor;
        }
    }
}