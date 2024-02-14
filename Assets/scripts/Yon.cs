using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yon : MonoBehaviour
{
    public Vector3 yon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vagon")
        {
            other.gameObject.GetComponent<VagonController>().yon = yon;
        }
    }
}
