using UnityEngine;
using System.Collections;

public class MovementCore : MonoBehaviour {

    public Transform WuWrPoint;
    public Transform PuPoint;
    public MovementTrigger groundCheck;
    public float forward;
    public float horizontal;
    public float vertical;
    float maxForward;
    float maxHorizontal;
    float flatVelocity = 0f;
    float verticalVelocity = 0f;
    enum WuWr {Wu, Wr, None};
    WuWr WState = WuWr.None;
    enum State {Wu, Wr, Pu, G, Ng };
    State currentState = State.Ng;
    Rigidbody rb;
    RaycastHit hit;
    RaycastHit[] tempHit;
    public bool grounded = false;
    bool jump = false;
    int count = 0;
    Vector3 velocityHolder;

    void ToggleGrounded(bool toggle)
    {
        grounded = toggle;
    }

    void Start()
    {
        groundCheck.ActiveToggle = ToggleGrounded;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(StartNotGrounded());
    }



    IEnumerator StartGrounded()
    {
        currentState = State.G;
        jump = true;
        StartCoroutine(GroundedLoop());
        yield return null;
    }
    IEnumerator GroundedLoop()
    {
        while(grounded && jump)
        {
            Move();
            Jump(false);
            yield return null;
        }
        StartCoroutine(StartNotGrounded());
        yield return null;
    }



    IEnumerator StartWallRun()
    {
        currentState = State.Wr;
        Jump(true);
        jump = true;
        yield return null;
        StartCoroutine(WallRunLoop());
        print("Start Run");
    }
    IEnumerator WallRunLoop()
    {
        tempHit = Physics.RaycastAll(WuWrPoint.position, WuWrPoint.forward, 4f);
        for(count = 0; count < tempHit.Length; count++)
        {
            if(!tempHit[count].transform.tag.Contains(tag))
            {
                hit = tempHit[count];
                break;
            }
        }
        while (count < tempHit.Length && Vector3.Angle(-hit.normal, -WuWrPoint.forward) >= 15 && Vector3.Angle(-hit.normal, -WuWrPoint.up) > 70 && Vector3.Angle(-hit.normal, -WuWrPoint.up) < 110 && !hit.transform.tag.Contains(tag) && !grounded)
        {
            print("run loop");
            rb.AddForce(-Physics.gravity / 2);
            Jump(false);
            yield return null;
            tempHit = Physics.RaycastAll(WuWrPoint.position, WuWrPoint.forward, 4f);
            for (count = 0; count < tempHit.Length; count++)
            {
                if (!tempHit[count].transform.tag.Contains(tag))
                {
                    hit = tempHit[count];
                    break;
                }
            }
        }
        print(hit.transform.tag);
        yield return null;
        StartCoroutine(StartNotGrounded());
    }



    IEnumerator StartWallUp()
    {
        currentState = State.Wu;
        Jump(true);
        jump = true;
        yield return null;
        StartCoroutine(WallUpLoop());
    }
    IEnumerator WallUpLoop()
    {
        tempHit = Physics.RaycastAll(WuWrPoint.position, -hit.normal, 2f);
        for (count = 0; count < tempHit.Length; count++)
        {
            if (!tempHit[count].transform.tag.Contains(tag))
            {
                hit = tempHit[count];
                break;
            }
        }
        while (count < tempHit.Length && Vector3.Angle(hit.normal, -WuWrPoint.forward) < 15 /*&& !hit.transform.tag.Contains(tag)*/ && !grounded)
        {
            print("up loop");
            Jump(false);
            Move();
            tempHit = Physics.RaycastAll(WuWrPoint.position, -hit.normal, 2f);
            for (count = 0; count < tempHit.Length; count++)
            {
                if (!tempHit[count].transform.tag.Contains(tag))
                {
                    hit = tempHit[count];
                    break;
                }
            }
            yield return null;
        }
        yield return null;
        StartCoroutine(StartNotGrounded());
    }



    IEnumerator StartPullUp()
    {
        currentState = State.Pu;
        jump = true;
        print("start pull");
        StartCoroutine(PullUpLoop());
        yield return null;
    }
    IEnumerator PullUpLoop()
    {
        while (Physics.Raycast(PuPoint.position, -transform.up, out hit, 3f) && jump && !hit.transform.tag.Contains(tag))
        {
            Jump(false);
            yield return null;
        }
        yield return null;
        StartCoroutine(StartNotGrounded());
    }

    IEnumerator StartNotGrounded()
    {
        currentState = State.Ng;
        jump = true;
        while (currentState == State.Ng && !grounded)
        {
            tempHit = Physics.RaycastAll(WuWrPoint.position, WuWrPoint.forward, 4f);
            for (count = 0; count < tempHit.Length; count++)
            {
                if (!tempHit[count].transform.tag.Contains(tag))
                {
                    hit = tempHit[count];
                    break;
                }
            }
            if (count < tempHit.Length && !hit.transform.tag.Contains(tag) && Input.GetButton("Advanced"))//WallRun/WallUp check
            {
                Debug.DrawLine(WuWrPoint.position, hit.point);
                if (Vector3.Angle(hit.normal, -WuWrPoint.forward) < 15)
                {
                    //print(Vector3.Angle(hit.normal, -WuWrPoint.forward));
                    yield return null;

                    print("change to up");
                    StartCoroutine(StartWallUp());
                }
                else if (Vector3.Angle(-hit.normal, -WuWrPoint.up) > 70 && Vector3.Angle(-hit.normal, -WuWrPoint.up) < 110)
                {
                    //print(Vector3.Angle(hit.normal, -WuWrPoint.forward));
                    yield return null;
                    print("change to run");
                    StartCoroutine(StartWallRun());
                }
            }
            Move();
            Jump(false);
            yield return null;
        }
        if (grounded)
        {
            yield return null;
            StartCoroutine(StartGrounded());
        }
    }
    IEnumerator NotGroundedLoop()
    {
        while (currentState == State.Ng && !grounded)
        {
            tempHit = Physics.RaycastAll(WuWrPoint.position, WuWrPoint.forward, 4f);
            for (count = 0; count < tempHit.Length; count++)
            {
                if (!tempHit[count].transform.tag.Contains(tag))
                {
                    hit = tempHit[count];
                    break;
                }
            }
            if (count < tempHit.Length && !hit.transform.tag.Contains(tag) && Input.GetButton("Advanced"))//WallRun/WallUp check
            {
                Debug.DrawLine(WuWrPoint.position, hit.point);
                if (Vector3.Angle(hit.normal, -WuWrPoint.forward) < 15)
                {
                    //print(Vector3.Angle(hit.normal, -WuWrPoint.forward));
                    yield return null;

                    print("change to up");
                    StartCoroutine(StartWallUp());
                }
                else if(Vector3.Angle(-hit.normal, -WuWrPoint.up) > 70 && Vector3.Angle(-hit.normal, -WuWrPoint.up) < 110)
                {
                    //print(Vector3.Angle(hit.normal, -WuWrPoint.forward));
                    yield return null;
                    print("change to run");
                    StartCoroutine(StartWallRun());
                }
            }
            Move();
            Jump(false);
            yield return null;
        }
        if (grounded)
        {
            yield return null;
            StartCoroutine(StartGrounded());
        }
    }

    void Move()
    {
        flatVelocity = Mathf.Abs(rb.velocity.x + rb.velocity.z);
        velocityHolder = Vector3.zero;
        if (Input.GetButton("Advanced"))
        {
            maxForward = forward;
            maxHorizontal = horizontal;
        }
        else
        {
            maxForward = forward / 2;
            maxHorizontal = horizontal / 2;
        }

        if(Input.GetButton("Forwards"))
        {
            //rb.AddForce(transform.forward * (forward - flatVelocity));
            velocityHolder += transform.forward * maxForward;
        }
        else if(Input.GetButton("Backwards"))
        {
            //rb.AddForce(-transform.forward * (forward - flatVelocity));
            velocityHolder += -transform.forward * maxForward;
        }


        if(Input.GetButton("Right"))
        {
            //rb.AddForce(transform.right * (horizontal - flatVelocity));
            velocityHolder += transform.right * maxHorizontal;
        }
        else if(Input.GetButton("Left"))
        {
            //rb.AddForce(-transform.right * (horizontal - flatVelocity));
            velocityHolder += -transform.right * maxHorizontal;
        }
        if (!grounded && velocityHolder == Vector3.zero)
        {
            velocityHolder = rb.velocity;
        }
        else
        {
            velocityHolder += new Vector3(0f, rb.velocity.y, 0f);
        }
        rb.velocity = velocityHolder;
    }

    void Jump(bool active)
    {
        if(active || (Input.GetButtonDown("Jump") && jump))
        {
            print("jump");
            jump = false;
            rb.velocity = new Vector3(rb.velocity.x, vertical, rb.velocity.z);
        }
    }
}