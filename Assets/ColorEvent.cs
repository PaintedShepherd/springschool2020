﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMaterial(Material material)
    {
        this.GetComponent<Renderer>().material = material;
    }
}