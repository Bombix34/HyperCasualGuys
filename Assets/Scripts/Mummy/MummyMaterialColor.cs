﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyMaterialColor : MonoBehaviour
{
    SkinnedMeshRenderer[] renderers;
    public Material[] materials;

    public Material explodeMaterial;

    private void Awake()
    {
        renderers = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    private void Start()
    {
        //InitMummyColor();
    }

    public void InitMummyColor()
    {
        int randomColor = (int)Random.Range(0f, materials.Length);
        foreach(var item in renderers)
        {
            item.material = materials[randomColor];
        }
    }

    public void SetupColor(int index)
    {
        foreach (var item in renderers)
        {
            item.material = materials[index];
        }
    }

    public void SetExplodeMaterial()
    {
        foreach (var item in renderers)
        {
            item.material = explodeMaterial;
        }
    }
}
