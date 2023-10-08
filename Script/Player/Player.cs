using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int stepLimit;

    public static bool isLose;

    public static bool isWin;



    public static bool isMoving = false;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.5f;

    public bool isRotating = false;
    private Vector3 origAngle, targetAngle;
    private float timeToRotate = 0.2f;
    private float timeToFly = 0.8f;

    public Animator anim;

    public Rigidbody character;

    public static bool isOver = true;

    private float delayTime = 0.1f;

    public static bool isFlying;

    public List<GameObject> barriers;

    public static List<int> ballsGotten = new List<int>();

    [SerializeField] private AudioClip push;
    [SerializeField] private AudioClip no;
    [SerializeField] private AudioSource audioSource;
   


    //private float flySpeed = 1.0f;







    // Start is called before the first frame update
    void Start()
    {

        isLose = false;
        isWin = false;
        isMoving = false;
        isFlying = false;
        isOver = true;
        // Application.targetFrameRate = 60;
        barriers.Clear();
        anim.SetBool("isPushing", false);
        anim.SetBool("isMoving", false);
        anim.SetBool("isFlying", false);
        anim.SetBool("NO", false);

        audioSource = gameObject.GetComponent<AudioSource>();
        Debug.Log("The count of barriers is" + barriers.Count);
    }
    private void Update()
    {
        if (!isFlying && !isWin && !isLose)
        {
            StartCoroutine(DelayFunc());
        }

        if (isFlying&& !isWin && !isLose)
        {
            StartCoroutine(Fly());
        }

        if (Trigger.flyAction)
        {
            anim.SetBool("isFlying", true);
        }
        if (!Trigger.flyAction)
        {
            anim.SetBool("isFlying", false);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            foreach (int ballgotten in Player.ballsGotten)
            {
                Debug.Log(ballgotten);
                // barriers.Clear();
            }
        }
        
    }
    private IEnumerator DelayFunc()
    {


        //if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        //    StartCoroutine(MovePlayer(Vector3.forward));
        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //     StartCoroutine(NoAct());
        // }


        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            isMoving = true;
            
            yield return new WaitForSeconds( delayTime );
            
            if (!Trigger1.barrierDetected && !Trigger1.wallDetected)
            {
                targetAngle = new Vector3(0f, 0f, 0f);
                StartCoroutine(RotatePlyer());
                StartCoroutine(MovePlayer(Vector3.forward));
                //if (!isOver)
                //{
                //    TriggerBack();
                //}
            }

            else if (Trigger1.wallDetected)
            {
                StartCoroutine(NoAct());
                //if (!isOver)
                //{
                //    TriggerBack();
                //}
            }

            else if (Trigger1.barrierDetected)
            {
                if (!Trigger2.objectDetected)
                {
                    targetAngle = new Vector3(0f, 0f, 0f);
                    StartCoroutine(RotatePlyer());
                    StartCoroutine(PushingBarrier(Vector3.forward));
                    //if (!isOver)
                    //{
                    //    TriggerBack();
                    //}
                }

                else
                {
                    StartCoroutine(NoAct());
                    //if (!isOver)
                    //{
                    //    TriggerBack();
                    //}
                }
            }

        }


        //if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        //    StartCoroutine(MovePlayer(Vector3.back));

        if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            isMoving = true;
            yield return new WaitForSeconds( delayTime );
            if (!Trigger1.barrierDetected && !Trigger1.wallDetected)
            {
                targetAngle = new Vector3(0f, 180f, 0f);
                StartCoroutine(RotatePlyer());
                StartCoroutine(MovePlayer(Vector3.back));
                //if (!isOver)
                //{
                //    TriggerBack();
                //}
            }

            else if (Trigger1.wallDetected)
            {
                StartCoroutine(NoAct());
                //if (!isOver)
                //{
                //    TriggerBack();
                //}
            }

            else if (Trigger1.barrierDetected)
            {
                if (!Trigger2.objectDetected)
                {
                    targetAngle = new Vector3(0f, 180f, 0f);
                    StartCoroutine(RotatePlyer());
                    StartCoroutine(PushingBarrier(Vector3.back));
                    //if (!isOver)
                    //{
                    //    TriggerBack();
                    //}
                }

                else
                {
                    StartCoroutine(NoAct());
                    //if (!isOver)
                    //{
                    //    TriggerBack();
                    //}
                }
            }
        }


        //if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        //    StartCoroutine(MovePlayer(Vector3.left));

        if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            isMoving = true;
            yield return new WaitForSeconds( delayTime );
            if (!Trigger1.barrierDetected && !Trigger1.wallDetected)
            {
                targetAngle = new Vector3(0f, 270f, 0f);
                StartCoroutine(RotatePlyer());
                StartCoroutine(MovePlayer(Vector3.left));
                //if (!isOver)
                //{
                //    TriggerBack();
                //}
            }

            else if (Trigger1.wallDetected)
            {
                StartCoroutine(NoAct());
                //if (!isOver)
                //{
                //    TriggerBack();
                //}
            }

            else if (Trigger1.barrierDetected)
            {
                if (!Trigger2.objectDetected)
                {
                    targetAngle = new Vector3(0f, 270f, 0f);
                    StartCoroutine(RotatePlyer());
                    StartCoroutine(PushingBarrier(Vector3.left));
                    //if (!isOver)
                    //{
                    //    TriggerBack();
                    //}
                }

                else
                {
                    ;
                    StartCoroutine(NoAct());
                    //if (!isOver)
                    //{
                    //    TriggerBack();
                    //}
                }
            }
        }


        //if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        //    StartCoroutine(MovePlayer(Vector3.right));

        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            isMoving = true;
            yield return new WaitForSeconds( delayTime );
            if (!Trigger1.barrierDetected && !Trigger1.wallDetected)
            {
                targetAngle = new Vector3(0f, 90f, 0f);
                StartCoroutine(RotatePlyer());
                StartCoroutine(MovePlayer(Vector3.right));
                //if (!isOver)
                //{
                //    TriggerBack();
                //}
            }

            else if (Trigger1.wallDetected)
            {
                StartCoroutine(NoAct());
                //if (!isOver)
                //{
                //    TriggerBack();
                //}
            }

            else if (Trigger1.barrierDetected)
            {
                if (!Trigger2.objectDetected)
                {
                    targetAngle = new Vector3(0f, 90f, 0f);
                    StartCoroutine(RotatePlyer());
                    StartCoroutine(PushingBarrier(Vector3.right));
                    //if (!isOver)
                    //{
                    //    TriggerBack();
                    //}
                }

                else
                {
                    StartCoroutine(NoAct());
                    //if (!isOver)
                    //{
                    //    TriggerBack();
                    //}
                }
            }
        }


    }
    private IEnumerator Fly()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            stepLimit -= 1;
            isMoving = true;
            targetAngle = new Vector3(0f, 0f, 0f);
            StartCoroutine(RotatePlyer());
            yield return new WaitForSeconds(0.25f);

            float elapsedTime = 0;

            origPos = transform.position;
            targetPos = transform.position + FlyTrigger.flyDistance * Vector3.forward;

            while (elapsedTime < timeToFly)
            {
                transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToFly));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;

            if (transform.position == targetPos)
            {
                barriers = GameObject.FindGameObjectsWithTag("barrier").ToList<GameObject>();
                Trigger.flyAction = false;
                GameObject.Find("Trigger1").GetComponent<Trigger1>().Forward();
                anim.SetBool("isPushing", true);
                yield return new WaitForSeconds(0.5f);
                audioSource.PlayOneShot(push);
                foreach (GameObject barrier in barriers)
                {
                    barrier.GetComponent<Barrier>().SelfDestroy();
                }
                anim.SetBool("isPushing", false);
                isMoving = false;
                isFlying = false;
                Trigger1._barrierDetected = false;
                Trigger1._wallDetected = false;
                Trigger1._objectDetected = false;
                barriers.Clear();
                
                Debug.Log("The count of barriers is" + barriers.Count);

            }


        }

        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            stepLimit -= 1;
            isMoving = true;
            targetAngle = new Vector3(0f, 90f, 0f);
            StartCoroutine(RotatePlyer());
            yield return new WaitForSeconds(0.25f);

            float elapsedTime = 0;

            origPos = transform.position;
            targetPos = transform.position + FlyTrigger.flyDistance * Vector3.right;

            while (elapsedTime < timeToFly)
            {
                transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToFly));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;

            if (transform.position == targetPos)
            {
                barriers = GameObject.FindGameObjectsWithTag("barrier").ToList<GameObject>();
                Trigger.flyAction = false;
                GameObject.Find("Trigger1").GetComponent<Trigger1>().Right();
                anim.SetBool("isPushing", true);
                yield return new WaitForSeconds(0.5f);
                audioSource.PlayOneShot(push);
                foreach(GameObject barrier in barriers)
                {
                    barrier.GetComponent<Barrier>().SelfDestroy();
                }
                anim.SetBool("isPushing", false);
                isMoving = false;
                isFlying = false;
                Trigger1._barrierDetected = false;
                Trigger1._wallDetected = false;
                Trigger1._objectDetected = false;
                barriers.Clear();
                
                Debug.Log("The count of barriers is" + barriers.Count);

            }


        }

        if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            stepLimit -= 1;
            isMoving = true;
            targetAngle = new Vector3(0f, 180f, 0f);
            StartCoroutine(RotatePlyer());
            yield return new WaitForSeconds(0.25f);

            float elapsedTime = 0;

            origPos = transform.position;
            targetPos = transform.position + FlyTrigger.flyDistance * Vector3.back;

            while (elapsedTime < timeToFly)
            {
                transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToFly));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;

            if (transform.position == targetPos)
            {
                barriers = GameObject.FindGameObjectsWithTag("barrier").ToList<GameObject>();
                Trigger.flyAction = false;
                GameObject.Find("Trigger1").GetComponent<Trigger1>().Back();
                anim.SetBool("isPushing", true);
                yield return new WaitForSeconds(0.5f);
                audioSource.PlayOneShot(push);
                foreach (GameObject barrier in barriers)
                {
                    barrier.GetComponent<Barrier>().SelfDestroy();
                }
                anim.SetBool("isPushing", false);
                isMoving = false;
                isFlying = false;
                Trigger1._barrierDetected = false;
                Trigger1._wallDetected = false;
                Trigger1._objectDetected = false;
                barriers.Clear();
                
                Debug.Log("The count of barriers is" + barriers.Count);


            }


        }

        if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            barriers = GameObject.FindGameObjectsWithTag("barrier").ToList<GameObject>();
            stepLimit -= 1;
            isMoving = true;
            targetAngle = new Vector3(0f, 270f, 0f);
            StartCoroutine(RotatePlyer());
            yield return new WaitForSeconds(0.25f);

            float elapsedTime = 0;

            origPos = transform.position;
            targetPos = transform.position + FlyTrigger.flyDistance * Vector3.left;

            while (elapsedTime < timeToFly)
            {
                transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToFly));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;

            if (transform.position == targetPos)
            {
                Trigger.flyAction = false;
                GameObject.Find("Trigger1").GetComponent<Trigger1>().Left();
                anim.SetBool("isPushing", true);
                yield return new WaitForSeconds(0.5f);
                audioSource.PlayOneShot(push);
                foreach (GameObject barrier in barriers)
                {
                    barrier.GetComponent<Barrier>().SelfDestroy();
                }
                anim.SetBool("isPushing", false);
                isMoving = false;
                isFlying = false;
                Trigger1._barrierDetected = false;
                Trigger1._wallDetected = false;
                Trigger1._objectDetected = false;
                barriers.Clear();
                
                Debug.Log("The count of barriers is" + barriers.Count);


            }


        }
    }
   private IEnumerator MovePlayer(Vector3 direction)
    {
        stepLimit -= 1;
        isMoving = true;
        anim.SetBool("isMoving", true);

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
        anim.SetBool("isMoving", false);

        isOver = false;

    }
   private IEnumerator RotatePlyer()
    {
        isRotating = true;

        float elapsedTime2 = 0;

        origAngle = transform.eulerAngles;

        while (elapsedTime2 < timeToRotate)
        {
            if (targetAngle.y - origAngle.y > 180) { targetAngle.y = targetAngle.y - 360f; }
            if (targetAngle.y - origAngle.y < -180) { targetAngle.y = targetAngle.y + 360f; }
            transform.eulerAngles = Vector3.Lerp(origAngle, targetAngle, (elapsedTime2 / timeToRotate));
            elapsedTime2 += Time.deltaTime;
            yield return null;
        }

        transform.eulerAngles = targetAngle;

        isRotating = false;

        //isOver = false;
    }
   public IEnumerator NoAct()
    {
        anim.SetBool("NO", true);
        audioSource.PlayOneShot(no);
        yield return new WaitForSeconds(0.6f);
        anim.SetBool("NO", false);

        isMoving = false;
    }
   public IEnumerator PushingBarrier(Vector3 direction)
    {
        isMoving = true;
        stepLimit -= 2;


        anim.SetBool("isPushing", true);
        
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(push);
        anim.SetBool("isPushing", false);

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;

        isOver = false;
    }



   
    
    

    

    

    
}




