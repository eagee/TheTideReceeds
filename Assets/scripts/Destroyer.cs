﻿using UnityEngine;
using System.Collections;

public class DestroyCubes : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "hey")
        {
            Destroy(col.gameObject);
        }
    }
}