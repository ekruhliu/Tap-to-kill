using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class ObjectFactory
{
    public const float rangeXmin = -2.0f;
    public const float rangeXmax = 2.0f;
    public const float rangeYmin = -4.2f;
    public const float rangeYmax = 3.2f;
    public const float objectPositionZ = 0.0f;
    public abstract GameObject CreateObject();
}

class StarFactory : ObjectFactory
{
    public override GameObject CreateObject()
    {
        GameObject star = Resources.Load<GameObject>("Prefubs/Star");

        Transform objectTransform = star.GetComponent<Transform>();
        objectTransform.position = new Vector3(Random.Range(rangeXmin, rangeXmax), Random.Range(rangeYmin, rangeYmax), objectPositionZ);

        return star;
    }
}

class BombFactory : ObjectFactory
{
    public override GameObject CreateObject()
    {
        GameObject bomb = Resources.Load<GameObject>("Prefubs/Bomb");

        Transform objectTransform = bomb.GetComponent<Transform>();
        objectTransform.position = new Vector3(Random.Range(rangeXmin, rangeXmax), Random.Range(rangeYmin, rangeYmax), objectPositionZ);

        return bomb;
    }
}
