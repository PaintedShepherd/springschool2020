using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treefall : MonoBehaviour
{
    public int counter=0;
    public float force = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "axe")
        {
            counter++;
        }
        if (counter == 30)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        }
    }
}
