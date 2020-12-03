
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateX : MonoBehaviour
{

    public float moveSpeed = 0.1f;
    public float delta = 45f;
    private Vector2 startPos;
    public Rigidbody2D rb;
    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        this.startPos = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // void FixedUpdate()
    // {
    //     Vector2 newPos = startPos;
    //     newPos.x += delta * Mathf.Sin(Time.time * moveSpeed);
    //     transform.position = newPos;
    // }


    
    void Update()
    {
       timeLeft -= Time.deltaTime;
       if(timeLeft <= 0)
       {
         movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
         timeLeft += accelerationTime;
       }
    }
     
    void FixedUpdate()
    {
       rb.AddForce(movement * maxSpeed);
    }




}
