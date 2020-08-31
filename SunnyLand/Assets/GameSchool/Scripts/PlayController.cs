using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    private Animator m_Animator;

    public float m_XAxisSpeed = 3f;
    public float m_YJumpPower = 3f;
    bool jumpbool;

    public bool m_IsJumping = false;

    protected void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }
    protected void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector2 velocity = m_Rigidbody2D.velocity;
        velocity.x = xAxis * m_XAxisSpeed;
        m_Rigidbody2D.velocity = velocity;

    
        if (Input.GetKeyDown(KeyCode.Space) &&jumpbool)
        {
            m_Rigidbody2D.AddForce(Vector3.up * m_YJumpPower);
            jumpbool = false;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        var animator = GetComponent<Animator>();
        animator.SetFloat("VelocityY", velocity.y);

        m_IsJumping = Mathf.Abs(velocity.y) >= 0.1f ? true : false;

        m_Animator.SetBool("isJumping", m_IsJumping);
        m_Animator.SetFloat("VelocityX", Mathf.Abs(xAxis));

        m_Animator.SetFloat("Velocity", velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpbool = true;
        }
    }
}