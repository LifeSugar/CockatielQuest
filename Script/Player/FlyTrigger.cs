using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FlyTrigger : MonoBehaviour
{
    public static  int flyDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        RaycastHit hit;

        int layerMask = 1 << 10;

        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            flyDistance = (int)hit.distance;
            Debug.DrawLine(transform.position, hit.transform.position,Color.white);
        }
    }

  

    private void CalculateFlyDistance()
    {
        
        
        
        
        

    }

    //private void OnTriggerStay(Collider other)
    //{
    //   if (other.gameObject.tag == "wall" || other.gameObject.tag == "barrier")
    //    {
    //        stop = true;
    //        Debug.Log("stop");
    //        Debug.Log(timer);
    //    }
    //}

    
}


