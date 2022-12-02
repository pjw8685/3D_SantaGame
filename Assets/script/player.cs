using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    int santaHP = 100;
    public int damage = 30;

    Rigidbody rigid;
    Animator anim;
    public float speed;
    float hAxis;
    float vAxis;
    [SerializeField]
    Transform orientation;
    Vector3 moveVec;

    float rotAxis;
    public float rotSpeed = 500.0f;

    int isJ = 0;
    public float jumpForce;
    bool isjump = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        tr = GetComponent<Transform>();
    }

    private Transform tr;

    void Update()
    {
        Input_Axis();
        Move();
        Shooting();
        Jump();
        //Turn();
    }

    void Input_Axis()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        //rotAxis = Input.GetAxis("Mouse X");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        //Vector3 moveDir = (Vector3.forward * vAxis + Vector3.right * hAxis).normalized;
      
        anim.SetBool("IsRun", moveVec != Vector3.zero);

       
        //tr.Rotate(Vector3.up * rotAxis * rotSpeed * Time.deltaTime);
        Quaternion q;
        Vector3 vec;


        //prigidbody.AddForce(moveDir.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        if (hAxis != 0 || vAxis != 0)
        {

            vec = Camera.main.transform.TransformDirection(new Vector3(hAxis, 0, vAxis));
            vec.y = 0;
            q = Quaternion.LookRotation(vec);

            //moveDir = orientation.forward * vAxis + orientation.right * hAxis;
            //rigid.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
            Vector3 moveDir = orientation.forward * vAxis + orientation.right * -hAxis;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 15f * Time.deltaTime);
            tr.Translate(moveDir.normalized * speed * 1f * Time.deltaTime);
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isjump && isJ < 2)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetBool("DoJump", true);
            isjump = true;
            isJ++;
        }
    }

    //void Turn()
    //{
    //    if (hAxis == 0 && vAxis == 0)
    //    {
    //        transform.rotation = Camera.main.transform.rotation;
    //        return;
    //    }
     

    //    //Quaternion newRotation = Quaternion.LookRotation(moveVec);

       
    //    //rigid.rotation = Quaternion.Slerp(rigid.rotation, newRotation, rotSpeed * Time.deltaTime);
        
    //}


    private float bspeed = 2f;

    void Shooting()
    {
        //transform.Rotate(0f, rotAxis * bspeed, 0f, Space.Self);
        //transform.Rotate(Input.GetAxis("Mouse Y") * bspeed, 0f, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("DoShot");
        }
    }

    public void OnDamage()
    {
        santaHP = santaHP - 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isjump = false;
            isJ = 0;
        }
    }
}

