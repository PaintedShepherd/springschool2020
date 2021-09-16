using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildraft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Child Count: " + transform.childCount);
        foreach (Transform child in transform)
        {
            parts.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}

