using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float damage;

    private void OnTriggerStay(Collider other)
    {
        other.transform.SendMessage("Damage", damage, SendMessageOptions.DontRequireReceiver);
    }
}
