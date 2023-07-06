using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDrawThings : MonoBehaviour
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }
    private MeshRenderer[] rend;

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D col) {
        
        if (col.gameObject.GetComponentInChildren<MeshRenderer>() != null) {
            Debug.Log(col.tag);
            rend = col.gameObject.GetComponents<MeshRenderer>();
            for (int i = 0; i < rend.Length; i = i + 1) {
                rend[i].enabled = false;
            }
        }

    }
}
