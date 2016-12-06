using UnityEngine;
using System.Collections;

public class PlayerMov : MonoBehaviour {

    [SerializeField]
    public float Speed = 10.0f;
    [SerializeField]
    public float JumpSpeed = 10f;

    private Animator m_Animator;
    private Rigidbody2D RB2D;

    private Transform m_GroundCheck;
    [SerializeField]
    public LayerMask GroundLayers;




	// Use this for initialization
	void Start () {
        m_Animator = GetComponent<Animator>();

        RB2D = GetComponent<Rigidbody2D>();

        m_GroundCheck = transform.FindChild("GroundCheck");

	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        bool isGrounded = Physics2D.OverlapPoint(m_GroundCheck.position, GroundLayers);

        if (Input.GetButton("Jump")) {

            if (isGrounded)
            {
                RB2D.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }

        m_Animator.SetBool("IsGrounded", isGrounded);

        float hSpeed = Input.GetAxis("Horizontal");

        m_Animator.SetFloat("Speed", Mathf.Abs(hSpeed));

        if (hSpeed > 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }
            else if(hSpeed<0){
            transform.localScale = new Vector3(1, 1, 1);
            
        }
        RB2D.velocity = new Vector2(hSpeed , RB2D.velocity.y);
        //RB2D.velocity = new Vector2(hSpeed = Speed , RB2D.velocity.y);

	}

    }
