using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjects : MonoBehaviour
{
    const int instantiateTiming = 2;
    const int waitForStart = 1;
    const int randomFrom = 0;
    const int randomTo = 7;
    const int bombChance = 2;

    void Start() {
        InvokeRepeating("InstantiateObject", waitForStart, instantiateTiming);
        InvokeRepeating("InstantiateObject", waitForStart + 1, instantiateTiming);
        InvokeRepeating("InstantiateObject", waitForStart + 2, instantiateTiming);
    }

    void InstantiateObject()
    {
        if (Random.Range(randomFrom, randomTo) < bombChance)
            Instantiate(new BombFactory().CreateObject());
        else
            Instantiate(new StarFactory().CreateObject());
    }

}
