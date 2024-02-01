using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 9f;
    [SerializeField] float slowSpeed = 6f;
    [SerializeField] float boostSpeed = 14f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collision!");
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //When the car goes over a booster
        if (other.tag == "Booster")
        {
            Debug.Log("Booster!");
            moveSpeed = boostSpeed;
        }
        
    }
}
