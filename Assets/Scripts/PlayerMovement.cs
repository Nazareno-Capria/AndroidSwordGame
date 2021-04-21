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

    [SerializeField]
    private bool touchStart = false;
    [SerializeField]
    private Vector2 pointA;
    [SerializeField]
    private Vector2 pointB;
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        lr = GetComponent<LineRenderer>();
        rotateTo = new Vector3();
        //lr.material = new Material(Shader.Find("Sprites/Defautl"));
        //lr.widthMultiplier = 0.2f;
        lr.positionCount = 2;
        Gradient gradient = new Gradient();
        Color violeta = new Color(179, 136, 255);

        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(violeta, 0), new GradientColorKey(violeta, 1) },
            new GradientAlphaKey[] { new GradientAlphaKey(0, 0f), new GradientAlphaKey(0, 0.35f), new GradientAlphaKey(1f, 1) }
            );
        lr.colorGradient = gradient;
        //lr.startColor = Color.red;
        //lr.endColor = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            pointA = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            if (!PauseMenu.GameIsPaused)
            {
                lr.SetPosition(0, pointA);
                lr.enabled = true;
            }
            
        }
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
        {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
            if (!PauseMenu.GameIsPaused)
            {
                lr.SetPosition(1, pointB);
            }

        }
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            if (!PauseMenu.GameIsPaused)
            {
                lr.enabled = false;
            }
            touchStart = false;
        }
        //else 



        //if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && !isRotating)
        //{
        //    isRotating = true;
        //    dir = Camera.main.ScreenToWorldPoint(Input.touches[0].position) - transform.position;
        //    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //    rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //}
            //else if (isRotating)
            //{
            //    Vector3 dirFromAtoB = dir.normalized;
            //    dotProd = Vector3.Dot(dirFromAtoB, transform.right);
            //    if (dotProd >= 0.99f) 
            //    {
            //        isRotating = false;
            //    }
            //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            //}

    }
    void FixedUpdate()
    {
        if (touchStart)
        {

            dir = pointB - pointA;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Vector3 dirFromAtoB = dir.normalized;
            dotProd = Vector3.Dot(dirFromAtoB, transform.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
;
    }
}
