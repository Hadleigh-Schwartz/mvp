using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKinematicClouds : MonoBehaviour
{
    private Rigidbody2D rb;
    public Rigidbody2D RB {
        get {return rb;}
        set {rb = value;}
    }

    [SerializeField]
    private bool canMove = true;
    public bool CanMove {
        get {return canMove;}
        set {canMove = value;}
    }
    public float speed;

    Vector2 direction;

    public bool isEvaporating = false;
    public bool isCondensing = false;


    Vector2 startEvapPos, endEvapPos;
    Vector2 startCondPos, endCondPos;

    float currentLerpTime;
    float lerpTime = 2f;

    public StateManager gameManager;



    // private SphereCollider col;

    // private Level2Behavior gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // col = GetComponent<SphereCollider>();
    }

    void Update()
    {
        if(canMove == true)
        {
            direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }



    void FixedUpdate(){
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.fixedDeltaTime));
        


        if (isEvaporating)
         {
             //increment timer once per frame
             currentLerpTime += Time.deltaTime;
             if (currentLerpTime > lerpTime)
             {
                 currentLerpTime = lerpTime;
                 isEvaporating = false;
             }

             //lerp
             float percentComplete = currentLerpTime / lerpTime;
             rb.MovePosition(Vector3.Lerp(startEvapPos, endEvapPos, percentComplete));
         }

         if (isCondensing)
         {
             //increment timer once per frame
             currentLerpTime += Time.deltaTime;
             if (currentLerpTime > lerpTime)
             {
                 currentLerpTime = lerpTime;
                 isCondensing = false;
             }

             //lerp
             float percentComplete = currentLerpTime / lerpTime;
             rb.MovePosition(Vector3.Lerp(startCondPos, endCondPos, percentComplete));
         }



    }


    public void startCondense(){
        if (gameManager.state != "gas"){
            Debug.Log("Error!");
            gameManager.showErrorScreen = true;
        }
        else
        {
            gameManager.state = "liquid";
            startCondPos = transform.position;
            endCondPos = new Vector2(transform.position.x, -10);
            isCondensing = true;
            currentLerpTime = 0f;
        }

    }


    public void startEvaporate(){
        if (gameManager.state != "liquid"){
            Debug.Log("Error!");
            gameManager.showErrorScreen = true;
        }
        else
        {
            gameManager.state = "gas";
            startEvapPos = transform.position;
            endEvapPos = new Vector2(transform.position.x, 18);
            isEvaporating = true;
            currentLerpTime = 0f;
        }

    }



}
