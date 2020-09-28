using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    public bool isReverseListening = false;
    public string[] tagsToListenTo;
    public GameObject[] objectsToListenTo;
    public int requiredNumberOfObjects = 1;
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;

    public List<GameObject> triggeredObjects;
    public int numberOfObjects = 0;

    // Start is called before the first frame update
    void Start()
    {
        Collider collider = GetComponent<Collider>();

        if (collider != null)
        {
            collider.isTrigger = true;
        }
        else
        {
            Destroy(this);
        }

        triggeredObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyObjects()
    {
        foreach (GameObject triggeredObject in triggeredObjects)
        {
            PhotonNetwork.Destroy(triggeredObject);
        }
    }

    public void ChangeTagOfObject(string newTag)
    {
        foreach (GameObject triggeredObject in triggeredObjects)
        {
            triggeredObject.tag = newTag;
        }
    }

    public void ChangeMaterialOfObject(Material material)
    {
        foreach (GameObject triggeredObject in triggeredObjects)
        {
            triggeredObject.GetComponent<Renderer>().material = material;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isValid(other.gameObject))
        {
            triggeredObjects.Add(other.gameObject);

            numberOfObjects++;

            if (numberOfObjects >= requiredNumberOfObjects)
                onTriggerEnter.Invoke();

            return;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (isValid(other.gameObject))
        {
            if (numberOfObjects == requiredNumberOfObjects)
                onTriggerExit.Invoke();

            numberOfObjects--;

            triggeredObjects.Remove(other.gameObject);
        }
    }

    private bool isValid(GameObject other)
    {
        foreach (string tag in tagsToListenTo)
        {
            if (tag.Equals(other.gameObject.tag))
            {
                return !isReverseListening;
            }
        }

        foreach (GameObject thisObject in objectsToListenTo)
        {
            if (thisObject == other.gameObject)
            {
                return !isReverseListening;
            }
        }

        foreach (GameObject thisObject in triggeredObjects)
        {
            if (thisObject == other.gameObject)
            {
                return !isReverseListening;
            }
        }



        return isReverseListening;
    }
}
