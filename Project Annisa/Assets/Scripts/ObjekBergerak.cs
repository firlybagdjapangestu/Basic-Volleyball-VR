using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjekBergerak : MonoBehaviour
{
    public float speed = 5f; // Kecepatan gerak objek  
    public Vector3 direction = Vector3.right; // Arah gerak objek  

    // Update is called once per frame  
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
