using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableObject : MonoBehaviour
{
    const int objectLifeTime = 3;

    void Start() { Invoke("DestroyObject", objectLifeTime); }

    void DestroyObject() { Destroy(this.gameObject); }
}
