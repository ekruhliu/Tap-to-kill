using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class ObjectFactory
{
    public abstract GameObject CreateObject();
}

class StarFactory : ObjectFactory
{
    public override GameObject CreateObject()
    {
        GameObject star = Resources.Load<GameObject>("Prefubs/Star");

        Transform objectTransform = star.GetComponent<Transform>();
        objectTransform.position = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-4.2f, 3.2f), 0);

        return star;
    }
}

class BombFactory : ObjectFactory
{
    public override GameObject CreateObject()
    {
        GameObject bomb = Resources.Load<GameObject>("Prefubs/Bomb");

        Transform objectTransform = bomb.GetComponent<Transform>();
        objectTransform.position = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-4.2f, 3.2f), 0);

        return bomb;
    }
}
