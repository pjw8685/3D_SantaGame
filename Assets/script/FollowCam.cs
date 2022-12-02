using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    private Transform camTr;
    float xRotateMove;
    float yRotateMove;
    [SerializeField]
    float rotateSpeed = 100;
    float xRotate;
    float yRotate;

    private Vector3 velocity = Vector3.zero;
    float pdis;

    void Start()
    {
     
        camTr = GetComponent<Transform>();
    }
    void LateUpdate() //��������
    {
        //xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
        //yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;
        transform.position = new Vector3(player.transform.position.x+30, player.transform.position.y+10, player.transform.position.z);
        camTr.LookAt(player.transform.position + Vector3.up * 2.0f);
        //yRotate = transform.eulerAngles.y + yRotateMove;
        ////xRotate = transform.eulerAngles.x + xRotateMove; 
        //xRotate = xRotate + xRotateMove;
        //xRotate = Mathf.Clamp(xRotate, -90, 90); // 위, 아래 고정
        //transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
        yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

        yRotate = transform.eulerAngles.y + yRotateMove;
        //xRotate = transform.eulerAngles.x + xRotateMove; 
        xRotate = xRotate + xRotateMove;

        xRotate = Mathf.Clamp(xRotate, -90, 90); // 위, 아래 고정

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
    }
    //Update is called once per frame
    void Update()
    {
        Cursor.visible = false;                     //마우스 커서가 보이지 않게 함
        Cursor.lockState = CursorLockMode.Locked;
       
    }

}
