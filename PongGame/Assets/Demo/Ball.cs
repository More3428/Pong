using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed;
    private Vector3 direction; 
    private Rigidbody rb;

    private bool stop = false;

    public float minDirection = 0.5f; 
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        // this.ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += direction * speed * Time.deltaTime; 
    }

   void FixedUpdate()
    {
        if (stop)
        {
            return;
        }
        rb.AddForce(direction * speed);
    }

   private void OnCollisionEnter(Collision other)
   {
       if (other.gameObject.CompareTag("Wall"))
       {
           direction.z = -direction.z; 
       }
        //Racket Ball Direction when hit
       if (other.gameObject.CompareTag("Racket"))
       {
           Vector3 newDirection = (transform.position - other.transform.position).normalized;
           newDirection.x =Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
           newDirection.z =Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);
           direction = newDirection;
       }
   }
    //Function to spawn ball in random Direction
   private void ChooseDirection()
   {
       float signX = Mathf.Sign(Random.Range(-1f, 1f));
       float signY = Mathf.Sign(Random.Range(-1f, 1f));
       this.direction = new Vector3(0.5f * signX, 0, 0.5f * signY); 
   }

   public void Stop()
   {
       this.stop = true; 
   }

   public void Go()
   {
       ChooseDirection();
       this.stop = false; 
   }
}
