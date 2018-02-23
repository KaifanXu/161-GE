using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundary: MonoBehaviour {
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
            Destroy(other.gameObject);
    }
}
