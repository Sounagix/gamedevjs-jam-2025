using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echoes : MonoBehaviour
{
    public void SetUp(float lifeTime)
    {
        Destroy(gameObject, lifeTime);
    }
}
