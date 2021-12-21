using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Dan")
        {
            transform.parent.position += new Vector3(0, 0, 0.1f);
            Destroy(other.gameObject);
        }
    }
}
