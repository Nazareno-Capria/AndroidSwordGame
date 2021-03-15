using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject sword;
    public float rotationSpeed;
    public bool canMove = true;
    public bool isRotating;
    public Vector3 rotateTo;
    public float angle;
    public Quaternion quatToRotate;
    public Quaternion startRotation;
    private Transform playerTransform;

    public Quaternion rotation;
    public Vector2 dir;
    public float dotProd;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        rotateTo = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && !isRotating)
        {
            isRotating = true;
            dir = Camera.main.ScreenToWorldPoint(Input.touches[0].position) - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
        }
        else if (isRotating)
        {
            Vector3 dirFromAtoB = dir.normalized;
            dotProd = Vector3.Dot(dirFromAtoB, transform.right);
            if (dotProd >= 0.99f) 
            {
                isRotating = false;
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }

    }
    void FixedUpdate()
    {
        //if (canMove)
        //{
        //    angle = Mathf.Atan2(rotateTo.y - this.transform.position.y, rotateTo.x - this.transform.position.x) * Mathf.Rad2Deg;
        //    Vector3 vector = new Vector3(0, 0, angle);

        //    if(Vector3.Distance(transform.eulerAngles, rotateTo) < 0.01f)
        //    {

        //            transform.eulerAngles = rotateTo;
        //            isRotating = false;
                
        //    }
        //    if (Vector3.Distance(transform.eulerAngles, rotateTo) >= 0.01f)
        //    {
        //        isRotating = true;
                
        //        Rotate(startRotation, quatToRotate);
        //    }
            
        //    if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && Input.touches[0].phase != TouchPhase.Moved && !isRotating)
        //    {
        //        checkAndMoveTouch();
        //    }
        //    else if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
        //    {
        //        checkAndMoveSlide();

        //    }
        //}
    }

    public void checkAndMoveTouch()
    {
        
            Vector3 touchPos = Input.GetTouch(0).position;
            touchPos.z = -Camera.main.transform.position.z;
            rotateTo = Camera.main.ScreenToWorldPoint(touchPos);
            quatToRotate = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, angle);
            startRotation = transform.rotation;
    }
    public void Rotate(Quaternion thisEuler, Quaternion to)
    {
        this.transform.rotation = Quaternion.Lerp(thisEuler, to, Time.deltaTime);
    }
    public void checkAndMoveSlide()
    {
            isRotating = false;

            Vector3 touchPos = Input.GetTouch(0).position;
            touchPos.z = -Camera.main.transform.position.z;
            Vector3 rotateTo = Camera.main.ScreenToWorldPoint(touchPos);

            Vector3 lookAtDir = rotateTo - this.transform.position;

           
            //Vector3 vector = new Vector3(playerTransform.rotation.x, playerTransform.rotation.y, angle);
            this.transform.right = lookAtDir;
    }
}
