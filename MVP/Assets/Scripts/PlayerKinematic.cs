using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKinematic : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    public float jumpForce;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public float rememberGroundedFor;
    float lastTimeGrounded;

    public int defaultAdditionalJumps = 1;
    int additionalJumps;

    private float fbInput;
    private float lrInput;

    Vector2 direction;

    public bool isEvaporating = false;
    public bool isCondensing = false;

    float accum = 0.0f;

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

        gameManager = GameObject.Find("GameManager").GetComponent<StateManager>();

    

        additionalJumps = defaultAdditionalJumps;
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), 0);
        // fbInput = Input.GetAxis("Vertical") * speed;
        // lrInput = Input.GetAxis("Horizontal") * speed;
        // // Move();
        // Jump();
        // BetterJump();
        // CheckIfGrounded();

        // if (p1 == p2){
        //     isLerping = false;
        //     Debug.Log("done lerping");
        // }

        // if (isLerping){
        //     accum += 1.1f * Time.deltaTime;
        //     this.transform.position = Vector2.Lerp(p1,p2, Mathf.SmoothStep(0,1,accum));
        // }
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

    // void OnCollisionEnter(Collision collision)
    // {
    //     if(collision.gameObject.name == "acidic_mol"){
    //         gameManager.HP -= 1;
    //     }
    // }


    void Move() {
        // var bottomLeft = camera.ScreenToWorldPoint(Vector3.zero);
        // var topRight =  camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight));

        // var cameraRect = new Rect(
        //  bottomLeft.x,
        //  bottomLeft.y,
        //  topRight.x - bottomLeft.x,
        //  topRight.y - bottomLeft.y);


        //  transform.position = new Vector3(
        //      Mathf.Clamp(transform.position.x, cameraRect .xMin, cameraRect .xMax),
        //      Mathf.Clamp(transform.position.y, cameraRect .yMin, cameraRect .yMax),
        //      transform.position.z);

        // float x = Input.GetAxisRaw("Horizontal");

        // float moveBy = x * speed;

        // // rb.velocity = new Vector2(moveBy, rb.velocity.y);
        // r.MovePosition(transform.position + x*speed);

        rb.MovePosition(this.transform.position + this.transform.forward * fbInput * Time.fixedDeltaTime);

        
    }

    // void Jump() {
    //     if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0)) {
    //         rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    //         additionalJumps--;
    //     }
    // }

    // void BetterJump() {
    //     if (rb.velocity.y < 0) {
    //         rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
    //     } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
    //         rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
    //     }
    // }

    // void CheckIfGrounded() {
    //     Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

    //     if (colliders != null) {
    //         isGrounded = true;
    //         additionalJumps = defaultAdditionalJumps;
    //     } else {
    //         if (isGrounded) {
    //             lastTimeGrounded = Time.time;
    //         }
    //         isGrounded = false;
    //     }
    // }

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
