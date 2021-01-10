using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ColCheck Feet;
    public float MoveSpeed = 4f;
    public float JumpForce = 7f;

    private Rigidbody2D rb2D;
    private Collider2D col2D;
    private Animator anim;
    private SpriteRenderer sprite;
    public bool isLanding;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    //물리와 관련된 작업은 FixedUpdate에서 처리함
    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(Input.GetAxis("Horizontal")*MoveSpeed,rb2D.velocity.y);
        //땅에 발이 닿아있을 때 (isLanding이 True)일 때 점프함 
        if (isLanding)
        {
            //Space키를 누른 순간에 True가 됨
            if (Input.GetButtonDown("Jump"))
            {
                rb2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            }
        }
    }

    //땅에 발이 닿으면 isLanding을 True로 바꿈
    private void OnCollisionStay2D(Collision2D other)
    {
        if (Feet.IsColliding())
            isLanding = true;
    }

    //땅에서 발이 떨어질 때 isLanding을 False로 바꿈
    private void OnCollisionExit2D(Collision2D other)
    {
        if (!Feet.IsColliding())
            isLanding = false;
    }

    //애니메이션 관련 처리
    void Update()
    {
        anim.SetBool("isLanding", isLanding);
        anim.SetBool("isFalling", rb2D.velocity.y <= 0);
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.001f)
        {
            anim.SetBool("isWalking", true);
            sprite.flipX = Input.GetAxis("Horizontal") < 0;
        }
        else anim.SetBool("isWalking", false);
    }
}
