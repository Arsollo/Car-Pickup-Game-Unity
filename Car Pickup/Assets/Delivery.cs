using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32 (13,239,253,255);
    [SerializeField] Color32 noPackageColor = new Color32 (253,40,13,255);

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  
        spriteRenderer.color = noPackageColor;  
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collision!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //When the car picks up a package
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;

            //Changing the car color 
            spriteRenderer.color = hasPackageColor;

            //Removing the package from game
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered!");
            hasPackage = false;

            //Changing the car color 
            spriteRenderer.color = noPackageColor;
        }
    }
}
