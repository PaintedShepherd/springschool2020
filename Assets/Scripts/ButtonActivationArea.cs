using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonActivationArea : MonoBehaviour
{
    public GameObject[] gameObjectsToListenTo;
    public string[] tagsToListenTo;
    public UnityEvent onObjectEntered;
    public UnityEvent onObjectExit;
    public UnityEvent onControllerTriggerPressed;
    public UnityEvent onControllerTriggerReleased;
    private bool isControllerAllowedToPress = true;
    private bool isControllerAllowedToRelease = false;
    private bool isObjectEntered = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsOjectValid(other.gameObject))
        {
            onObjectEntered.Invoke();

            isObjectEntered = true;
        }

    }

    private bool IsOjectValid(GameObject other)
    {
        foreach (GameObject gameObject in gameObjectsToListenTo)
        {
            if (gameObject.tag.Equals(other.gameObject.tag) && gameObject.name.Equals(other.gameObject.name))
            {
                return true;
            }
        }

        foreach (string tag in tagsToListenTo)
        {
            if (tag.Equals(other.gameObject.tag))
            {
                return true;
            }
        }

        return false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsOjectValid(other.gameObject))
        {
            onObjectExit.Invoke();

            isObjectEntered = false;

            if(isControllerAllowedToRelease)
            {
                onControllerTriggerReleased.Invoke();

                isControllerAllowedToPress = true;
                isControllerAllowedToRelease = false;
            }
        }
    }
}
