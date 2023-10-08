using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2 : MonoBehaviour
{
    public static bool barrierDetected;

    public static bool wallDetected;

    public static bool objectDetected;

    private bool _barrierDetected;
    private bool _wallDetected;
    private bool _objectDetected;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !Player.isMoving)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            StartCoroutine(RecordCondition());
        }

        if (Input.GetKeyDown(KeyCode.D) && !Player.isMoving)
        {
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
            StartCoroutine(RecordCondition());
        }

        if (Input.GetKeyDown(KeyCode.S) && !Player.isMoving)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            StartCoroutine(RecordCondition());
        }

        if (Input.GetKeyDown(KeyCode.A) && !Player.isMoving)
        {
            transform.eulerAngles = new Vector3(0f, 270f, 0f);
            StartCoroutine(RecordCondition());
        }


        //if (!Player.isOver)
        //{
        //    wallDetected = false;
        //    objectDetected = false;
        //    barrierDetected = false;
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "barrier" )
        {
            _barrierDetected = true;
            _objectDetected = true;
            //Debug.Log("trigger2 detects a barrier");
        }

        else if (other.gameObject.tag == "wall" )
        {
            _wallDetected = true;
            _objectDetected = true;
        }

        if (other.gameObject.tag == "cube")
        {
            _objectDetected = true;
        }
        //else
        //{
        //    _barrierDetected = false;
        //    _wallDetected = false;
        //    _objectDetected = false;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "barrier")
        {
            _barrierDetected = false;
            _objectDetected = false;
        }

        if (other.gameObject.tag == "wall")
        {
            _wallDetected = false;
            _objectDetected = false;
        }

        if (other.gameObject.tag == "cube")
        {
            _objectDetected = false;
        }
    }

    private IEnumerator RecordCondition()
    {
        yield return new WaitForSeconds(0.03f);
        barrierDetected = _barrierDetected;
        wallDetected = _wallDetected;
        objectDetected = _objectDetected;
        yield return new WaitForSeconds(0.04f);
        //Debug.Log(objectDetected);
        //Debug.Log("_trigger2barrierDetected = " + _barrierDetected);
    }
}
