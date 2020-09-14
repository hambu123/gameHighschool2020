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

    public bool m_ISTouchLadder = false;
    public bool m_m_ISClimbing = false;
    public float m_ClimbSpeed = 2f;
    public bool m_IsJumping = false;

    public float m_HitRecoveringTime = 0;
    protected void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }
    protected void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        m_HitRecoveringTime -= Time.deltaTime;
        if (m_HitRecoveringTime > 0)
        {
            ClimbingExit();

            m_Animator.SetBool("TakingDamage", true);
            return;
        }
        else
        {
            m_Animator.SetBool("TakingDamage", false);
            
        }

        if(m_ISTouchLadder == true
            && Mathf.Abs(yAxis) > 0.5f)
        {
            m_m_ISClimbing = true;
        }
        if ( ! m_m_ISClimbing)
        {
            Vector2 velocity = m_Rigidbody2D.velocity;
            velocity.x = xAxis * m_XAxisSpeed;
            m_Rigidbody2D.velocity = velocity;
            if (Input.GetKeyDown(KeyCode.Space) && jumpbool)
            {
                m_Rigidbody2D.AddForce(Vector3.up * m_YJumpPower);
                jumpbool = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
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
        else
        {
            //사다리 타는 도중의 이동기능
            m_Rigidbody2D.constraints =
                m_Rigidbody2D.constraints | RigidbodyConstraints2D.FreezePosition;

                
            Vector3 movement = Vector3.zero;
            movement.x = xAxis * m_ClimbSpeed * Time.deltaTime;
            movement.y = yAxis * m_ClimbSpeed * Time.deltaTime;

            transform.position += movement;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                ClimbingExit();
            }
        }
        // update 사다리타기 점프 캔슬하는데
        //여기랑
        m_Animator.SetBool("IsClimbing", m_m_ISClimbing);
        m_Animator.SetFloat("ClimbingSpeed",
            Mathf.Abs(xAxis) + Mathf.Abs(yAxis));

        
    }

    private void ClimbingExit()
    {
        m_Rigidbody2D.constraints =
            m_Rigidbody2D.constraints
            & ~RigidbodyConstraints2D.FreezePosition;
        m_m_ISClimbing = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpbool = true;
        }
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                jumpbool = true;

                if (contact.rigidbody)
                {
                    var hp = contact.rigidbody.GetComponent<HpComponent>();
                    if (hp)
                    {
                        //Destroy(hp.gameObject);
                        hp.TakeDamage(10);
                    }
                }
            }
             else if(contact.rigidbody && contact.rigidbody.tag == "Enemy")
            {
                var hp = GetComponent<HpComponent>();
                hp.TakeDamage(10);

                m_HitRecoveringTime = 2f;

                m_Animator.SetTrigger("TakeDamage");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ladder")
        {
            m_ISTouchLadder = true;
        }
        else if(collision.tag == "Item")
        {
            var item = collision.
                GetComponent<ItemComponet>();
            if (item != null)
                item.BeAte();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ladder")
        {
            m_ISTouchLadder = false;

            ClimbingExit();
        }
    }

                                                                                                                                                         


    /*if(! m_IsClimbing)
        {

        }*/

}