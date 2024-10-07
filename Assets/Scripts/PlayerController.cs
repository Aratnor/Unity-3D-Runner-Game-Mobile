using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canJump)
         {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision collision)
     {
        if (collision.gameObject.tag == "Ground")
         {
            canJump = true;
        }
     }
     
     void OnCollisionExit(Collision collision) {
         if (collision.gameObject.tag == "Ground")
         {
             canJump = false;
         }
     }
     
     void OnTriggerEnter(Collider other)
     {
         if(other.gameObject.tag == "Obstacle") 
         {
             SceneManager.LoadScene("GameScene");
         }
     }
}
