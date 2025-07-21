using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundcheckTransform;
    [SerializeField] private LayerMask playerMask;
   


    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    private bool isGrounded;
    private float speed = 2f;
    private int  superJumpsRemaining;
    public bool hasCoin;
    public GameObject Coinspawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("update tapahtuu");
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
        
    }


    void FixedUpdate()
    {
        rigidbodyComponent.linearVelocity = new Vector3(horizontalInput, rigidbodyComponent.linearVelocity.y, 0);



        if (Physics.OverlapSphere(groundcheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            float jumpPower = 5;
            if (superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                superJumpsRemaining--;
            }
            


            rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
      
        
        if (!isGrounded)
        {
            return;
        }


        Vector3 moveDirection = new Vector3(horizontalInput, 0).normalized;
       transform.position += moveDirection * speed * Time.fixedDeltaTime;
        





    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        
    }
    void OnCollisionExit(Collision collision)
    {
        isGrounded = false; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)

        {
            Destroy(other.gameObject);
            superJumpsRemaining++;

            hasCoin = false;

            Instantiate(Coinspawner, transform.position, Quaternion.identity);
        }
        

    }

}
