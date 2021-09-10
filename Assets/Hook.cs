using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public List<string> hookableTags;
    private List<GameObject> hookedObjects = new List<GameObject>();

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
        Debug.Log("OnTriggerEnter tag " + other.gameObject.tag);

        foreach (string tag in this.hookableTags)
        {
            if (other.gameObject.tag == tag)
            {
                this.HookObject(other.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit tag " + other.gameObject.tag);

        foreach (string tag in this.hookableTags)
        {
            if (other.gameObject.tag.Equals(tag))
            {
                this.UnhookObject(other.gameObject);
            }
        }
    }

    public void HookObject(GameObject _object)
    {
        Debug.Log("HookObject");

        _object.transform.SetParent(this.gameObject.transform);
        _object.GetComponent<Rigidbody>().isKinematic = true;
        this.hookedObjects.Add(_object);
    }

    public void UnhookObject(GameObject _object)
    {
        Debug.Log("UnhookObject");

        GameObject objectToUnhook = null;

        foreach (GameObject hookedObject in hookedObjects)
        {
            if (hookedObject == _object)
            {
                objectToUnhook = hookedObject;

                _object.transform.SetParent(null);
            }
        }

        if (objectToUnhook != null)
        {
            hookedObjects.Remove(objectToUnhook);
        }
    }
}
