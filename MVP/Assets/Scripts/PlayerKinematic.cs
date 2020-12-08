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

    // bool isGrounded = false;
    // public Transform isGroundedChecker;
    // public float checkGroundRadius;
    // public LayerMask groundLayer;

    // public float rememberGroundedFor;
    // float lastTimeGrounded;
    //
    // public int defaultAdditionalJumps = 1;
    // int additionalJumps;

    private float fbInput = 1;
    private float lrInput;

    Vector2 direction;

    private Inventory inventory;

    // private SphereCollider col;

    // private Level2Behavior gameManager;
    void Awake()
    {
        inventory = new Inventory();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // col = GetComponent<SphereCollider>();

        // gameManager = GameObject.Find("Game Manager").GetComponent<Level2Behavior>();

        //additionalJumps = defaultAdditionalJumps;
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // fbInput = Input.GetAxis("Vertical") * speed;
        // lrInput = Input.GetAxis("Horizontal") * speed;
        // // Move();
        // Jump();
        // BetterJump();
        // CheckIfGrounded();
    }

    void FixedUpdate(){
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.fixedDeltaTime));
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

    // public void OnTriggerEnter2D(Collider2D collision)
    // {
    //     var item = collision.GetComponent<Item>();
    //     if(item)
    //     {
    //         inventory.AddItem(item, 1);
    //         Destroy(collision.gameObject);
    //     }
    //     Debug.Log(item);
    // }

}
