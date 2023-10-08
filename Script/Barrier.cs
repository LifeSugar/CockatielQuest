using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public bool readyToMove;
    public bool _readyToMove;
    private bool readyToDestroy;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.1f;
    private Vector3 direction;


    [SerializeField] private AudioClip getBalls;

    [SerializeField] private AudioSource _audioSource;
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        yield return null;
        readyToDestroy = false;
        readyToMove = false;
        _readyToMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RecordCondition());
        StartCoroutine(MoveBarrier());

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Trigger1")
        {
            _readyToMove = true;
            readyToDestroy = true;
            //Debug.Log("ready");
        }

        if (other.gameObject.tag == "balls")
        {
            _audioSource.PlayOneShot(getBalls);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Trigger1")
        {
            _readyToMove = false;
            readyToDestroy = false;
            
        }
    }

    private IEnumerator RecordCondition()
    {
        yield return new WaitForSeconds(0.03f);
        readyToMove = _readyToMove;
        yield return new WaitForSeconds(0.04f);
        
    }

    private IEnumerator MoveBarrier()
    {
        

        if (Input.GetKeyDown(KeyCode.W) && !Player.isMoving)
        {
            direction = Vector3.forward;
            yield return new WaitForSeconds(0.08f);
            if (readyToMove && !Trigger2.objectDetected)
            {
                float elapsedTime = 0;

                origPos = transform.position;
                targetPos = origPos + direction;

                yield return new WaitForSeconds(0.5f);

                while (elapsedTime < timeToMove)
                {
                    transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                transform.position = targetPos;
            }
        }

        if (Input.GetKeyDown(KeyCode.S) && !Player.isMoving)
        {
            direction = Vector3.back;
            yield return new WaitForSeconds(0.08f);
            if (readyToMove && !Trigger2.objectDetected)
            {
                float elapsedTime = 0;

                origPos = transform.position;
                targetPos = origPos + direction;

                yield return new WaitForSeconds(0.5f);

                while (elapsedTime < timeToMove)
                {
                    transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                transform.position = targetPos;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && !Player.isMoving)
        {
            direction = Vector3.left;
            yield return new WaitForSeconds(0.08f);
            if (readyToMove && !Trigger2.objectDetected)
            {
                float elapsedTime = 0;

                origPos = transform.position;
                targetPos = origPos + direction;

                yield return new WaitForSeconds(0.5f);

                while (elapsedTime < timeToMove)
                {
                    transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                transform.position = targetPos;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) && !Player.isMoving)
        {
            direction = Vector3.right;
            yield return new WaitForSeconds(0.08f);
            if (readyToMove && !Trigger2.objectDetected)
            {
                float elapsedTime = 0;

                origPos = transform.position;
                targetPos = origPos + direction;

                yield return new WaitForSeconds(0.5f);

                while (elapsedTime < timeToMove)
                {
                    transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                transform.position = targetPos;
            }
        }

    }

    public void SelfDestroy()
    {
        if (readyToDestroy)
        {
            Destroy(gameObject);
        }
        else
        {
            
        }
    }
}
