﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Collider))]

public class GlowOnOff : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    [SerializeField]
    private Material originalMaterial;

    [SerializeField]
    private Material redMaterial;

    [SerializeField]
    private Material gruenMaterial;

    public static int status;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        EnableHighlight(0);
    }

    public void EnableHighlight(int nummer)
    {
        if(meshRenderer != null && originalMaterial != null && redMaterial != null &&gruenMaterial!=null)
        {
            switch (nummer)
            {
                case 0:
                    meshRenderer.material = originalMaterial;
                    break;
                case 1:
                    meshRenderer.material = redMaterial;
                    break;
                case 2:
                    meshRenderer.material = gruenMaterial;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnableHighlight(status);
    }
}
