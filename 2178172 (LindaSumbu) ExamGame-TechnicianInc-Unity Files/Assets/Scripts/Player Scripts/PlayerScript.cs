using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



    public class PlayerScript : MonoBehaviour
    {

       
        public float moveSpeed;
        public float jumpForce;
        public int checkpointOn = 0;
        public BoxCollider2D doorCollider;
        public Animator Anim;
        public PlayerPos pos;
        public GameObject CPlight;
        public GameObject CPLight2;
        public GameObject CPLight3;
        public bool isGrounded;
        public Transform groundCheck;
        public float checkRadius;
        public LayerMask whatIsGround;
        private bool isFacingRight = true;
    //bool AllLightsOn = false;

    public Light MClight;
        public int intensity;
        

        bool isJumping = false;

        [SerializeField]
       
        private Rigidbody2D RB;




    private void Start()
    {

        
        RB = RB.GetComponent<Rigidbody2D>();
        //doorAnim = doorAnim.GetComponent<Animator>();
        doorCollider.GetComponent<BoxCollider2D>().enabled = false;
        Anim = Anim.GetComponent<Animator>();
    }

    



    void Update()
        {
          

            float moveInput = Input.GetAxisRaw("Horizontal");
            RB.velocity = new Vector2(moveInput * moveSpeed, RB.velocity.y);
           

        if (moveInput == 0)
        {
            Anim.SetBool("IsWalk", false);
        }
        else
        {
            Anim.SetBool("IsWalk", true);
        }


        if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                Anim.SetBool("IsJump", true);
                RB.velocity = Vector2.up * jumpForce;
                isGrounded = false;
            }

        else
        {
            isJumping = false;
            Anim.SetBool("IsJump", false);
            isGrounded = true;
        }

        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }

        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }




    }


    private void Flip()
    {
        isFacingRight = !isFacingRight;

        UnityEngine.Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }




    private void FixedUpdate()
        {
         
         
            

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

            if (isGrounded = true && Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
               // RB.velocity = Vector2.up * jumpForce;
            }

        else
        {
            isJumping = false;
        }


    }

      
    public void PlusCP()
    {
        checkpointOn++;
        if(checkpointOn == 3)
        {
            doorCollider.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

         public void DecreaseBright()
        {
            intensity--;
        }

        public void IncreaseBright()
          {
        intensity++;
          }
      

    public void IsDead()
    {
        

        pos.ReloadScene();
        
    }

        

      

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.CompareTag("Spike"))
            {
                IsDead();
               // IncreaseBright();
               // MClight.range+=1;
           // StartCoroutine(LastForSeconds());
            }

      


        }


    
    /* IEnumerator LastForSeconds()
     {
         yield return new WaitForSeconds(7f);
         MClight.range-=1;
     }
    */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Checkpoint 1"))
        {
            CPlight.SetActive(true);
            PlusCP();
        }
        if(other.gameObject.CompareTag("Checkpoint 2"))
        {
            CPLight2.SetActive(true);
            PlusCP();
        }
        if (other.gameObject.CompareTag("Checkpoint 3"))
        {
            CPLight3.SetActive(true);
            PlusCP();
        }

        if (other.gameObject.CompareTag("Door"))
        {
           // doorAnim.SetTrigger("Open");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
       

        
    }

}

   

