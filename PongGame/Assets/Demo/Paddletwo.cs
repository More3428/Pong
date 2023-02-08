using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddletwo : MonoBehaviour
{
    public float unitperSecond = 3f;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalValue = Input.GetAxis("Vertical");
        Vector3 force = Vector3.right * horizontalValue * speed; // * unitperSecond * Time.deltaTime;
        
        Rigidbody rb = GetComponent<Rigidbody>(); 
        rb.AddForce(force, ForceMode.Force);
    }
}
