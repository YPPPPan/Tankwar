using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap1 : MonoBehaviour
{
    // Start is called before the first frame update
    internal void OnTriggerEnter2D(Collider2D other)
    {
         Destroy(other.gameObject);
    }
}
