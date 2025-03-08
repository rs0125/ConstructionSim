using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text uiObject1;
    public Text uiObject2;
    public Text uiObject3;
    public Text uiObject4;

    private bool isObject1Grabbed = false;
    private bool isObject2Grabbed = false;
    private bool isObject3Grabbed = false;
    private bool isObject4Grabbed = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        CheckObjectStatus();
    }

    public void SetObjectStatus(string objectName, bool status, XRBaseController controller = null)
    {
        switch (objectName)
        {
            case "CorrectHat":
                Debug.Log("CorrectHat");
                isObject1Grabbed = status;
                break;
            case "CorrectJacket":
                Debug.Log("correctJacket");
                isObject2Grabbed = status;
                break;
            case "CorrectShoes":
                Debug.Log("correctShoes");
                isObject3Grabbed = status;
                break;
            case "CorrectGloves":
                Debug.Log("correctGloves");
                isObject4Grabbed = status;
                break;
            case "WrongObject":
                if (controller != null)
                {
                    // Trigger heavy haptic feedback
                    Debug.Log("WrongObject");
                    controller.SendHapticImpulse(1.0f, 0.5f); // Max intensity, 0.5 seconds
                }
                break;
        }
    }

    private void CheckObjectStatus()
    {
        if (isObject1Grabbed)
        {
            uiObject1.color = Color.green;
        }
        if (isObject2Grabbed)
        {
            uiObject2.color = Color.green;
        }
        if (isObject3Grabbed)
        {
            uiObject3.color = Color.green;
        }
        if (isObject4Grabbed)
        {
            uiObject4.color = Color.green;
        }
    }
}