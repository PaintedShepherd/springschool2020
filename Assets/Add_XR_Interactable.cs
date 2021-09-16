using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Add_XR_Interactable : MonoBehaviour
{
    public void AddComponent()
    {
        gameObject.AddComponent<XRGrabInteractable>();
    }
}
