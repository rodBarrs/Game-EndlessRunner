using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestreScript : MonoBehaviour
{
    private CharacterController controller;
    
    public float speed;
    public float jumpHeight;
    public float gravity;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        direction = Vector3.back * speed;
    }

    // Update is called once per frame
    void Update()
    {
        

        controller.Move(direction * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
      
    }

}
