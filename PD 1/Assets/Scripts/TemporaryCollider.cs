using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryCollider : MonoBehaviour
{
    BoxCollider col;
    private void Awake()
    {
        col = GetComponent<BoxCollider>();
    }
    void DisCol()
    {
        col.enabled = false;
    }
    void EnCol()
    {
        col.enabled = true;
    }
}
