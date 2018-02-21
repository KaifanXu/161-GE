using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlatform : MonoBehaviour {

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Platform")
        {
            this.transform.parent = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Platform")
        {
            this.transform.parent = null;
        }
    }
}
