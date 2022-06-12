using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    
    public float velocidade;
    public float forcaDoPulo;
    public float gravidade;
    private float velocidadeDoPulo;
    public float veloHorizontal;
  //  private bool moverLeft;
 //   private bool moverRight;
    public float rayRadius;
    public LayerMask layer;
    public Animator anim;
    public bool isDead;
 //   public LayerMask moedaLayer;
   

    private GameController gameC;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        gameC = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.forward * velocidade;

        if (controller.isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                velocidadeDoPulo = forcaDoPulo; 
            }


            if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 3f && transform.position.x <= -4.8f)

            {
        //        moverRight = true;
                StartCoroutine(LeftToCenterMove());
                
            
            } else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 3f )

            {
        //        moverRight = true;
                StartCoroutine(CenterToRightMove());
                
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -3f && transform.position.x >= 5.3f)
            {
         //       moverLeft = true;
                StartCoroutine(RightToCenterMove());
               
              
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -3f )
            {
         //       moverLeft = true;
                StartCoroutine(CenterToLeftMove());
            
            }

        }
        else
        {
            velocidadeDoPulo -= gravidade;
        }

        OnCollision();

        direction.y = velocidadeDoPulo;

        controller.Move(direction * Time.deltaTime);

        

    }

    IEnumerator CenterToLeftMove()
    {
        while (transform.position.x >= -4.8 )
        {
            controller.Move(Vector3.left * Time.deltaTime * veloHorizontal);
            yield return null;
          
        }

     //   moverLeft = false; 
    }

    IEnumerator CenterToRightMove()
    {
        while (transform.position.x <= 5.8)
        {
            controller.Move(Vector3.right * Time.deltaTime * veloHorizontal);
            yield return null;
         
        }

      //  moverRight = false; 
    }

    IEnumerator LeftToCenterMove()
    {
        while (transform.position.x <= 0.5)
        {
            controller.Move(Vector3.right * Time.deltaTime * veloHorizontal);
            yield return null;
        }

     //   moverLeft = false;
    }

    IEnumerator RightToCenterMove()
    {
        while (transform.position.x >= 0.5)
        {
            controller.Move(Vector3.left * Time.deltaTime * veloHorizontal);
            yield return null;
        }

      //  moverRight = false;
    }

    void OnCollision()
    {
        RaycastHit hit;
         

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayRadius, layer) && !isDead)
        {
            //chama gamer over.
            anim.SetTrigger("die");
            velocidade = 0;
            forcaDoPulo = 0;
            veloHorizontal = 0;
            Invoke("GameOver", 3f);            
            isDead = true; 

        }

      //  RaycastHit moedaHit;  
    //    if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + new Vector3(10f, 10f,10f)), out moedaHit, rayRadius, moedaLayer))
     //   {
      //      Debug.Log("Colidiu");
        //    Destroy(moedaHit.transform.gameObject); 
       // }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameC.AddCoin();
        Destroy(other.gameObject);
        
    }
    void GameOver()
    {
        gameC.ShowGameOver();
    }

 
}
