using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    
    void Start()
    {
        
        // gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            // Debug.Log("hhhaha");
            
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
