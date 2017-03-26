using UnityEngine;
using System.Collections;

public class Snazzy : MonoBehaviour {
    public float maxSpeed = 10f;
    bool facingRight = true;

     private Animator m_anim;


    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float JumpForce = 50000.0f; 
    private Rigidbody2D m_RigidBody;

    void Awake() {
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    void Start () 
    {
        m_anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void FixedUpdate () 
    {
        grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
        m_anim.SetBool ("Ground", grounded);

        m_anim.SetFloat("vSpeed", m_RigidBody.velocity.y);

        float move = Input.GetAxis ("Horizontal");
        m_anim.SetFloat ("Speed", Mathf.Abs (move));
        m_RigidBody.velocity = new Vector2(move * maxSpeed, m_RigidBody.velocity.y);
        if (move > 0 && !facingRight)
            Flip ();
        else if (move < 0 && facingRight)
            Flip ();
    }

    void Update()
    {
        if (grounded && (Input.GetKeyDown (KeyCode.Space) || Input.GetButtonDown("Fire1")))
        {
            m_anim.SetBool("Ground", false);
            if(Time.timeScale != 0f)
            {
                m_RigidBody.AddForce(new Vector2(0, JumpForce));
            }

        }

    }


    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
