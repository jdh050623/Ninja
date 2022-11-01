using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCTR : BaseCharacterCTR
{
    public float initHpMax = 20.0f;
    [Range(0.1f, 100.0f)] public float initSpeed = 12.0f;

    int jumpCount = 0;
    bool breakEnabled = true;
    float groundFriction = 0.0f;

    protected override void Awake()
    {
        base.Awake();
        speed = initSpeed;
        SetHP(initHpMax, initHpMax);
    }

    protected override void FixedUpdateCharacter()
    {
        if (jumped)
        {
            if((grounded && !groundedPrev) || (grounded && Time.fixedTime > jumpStartTime + 1.0f))
            {
                animator.SetTrigger("Idle");
                jumped = false;
                jumpCount = 0;
            }
        }
        if(!jumped)
        {
            jumpCount = 0;
        }

        transform.localScale = new Vector3(basScaleX * dir,
            transform.localScale.y, transform.localScale.z);

        if(jumped && !grounded)
        {
            if(breakEnabled)
            {
                breakEnabled = false;
                speedVx *= 0.9f;
            }
        }

        if (breakEnabled)
        {
            speedVx *= groundFriction;
        }

        Camera.main.transform.position = transform.position - Vector3.forward;
    }

    public override void ActionMove(float n)
    {
        if(!activeSts)
        {
            return;
        }

        float dirOld = dir;
        breakEnabled = false;

        float moveSpeed = Mathf.Clamp(Mathf.Abs(n), -1.0f, +1.0f);
        animator.SetFloat("MoveSpeed", moveSpeed);
        //animator.speed = 1.0f + moveSpeed;

        if(n != 0.0f)
        {
            dir = Mathf.Sign(n);
            moveSpeed = (moveSpeed < 0.5f) ? (moveSpeed * (1.0f / 0.5f)) : 1.0f;
            speedVx = initSpeed * moveSpeed * dir;
        }

        else
        {
            breakEnabled = false;
        }

        if(dirOld != dir)
        {
            breakEnabled = true;
        }
    }

    public void ActionJump()
    {
        switch(jumpCount)
        {
            case 0 :
                if (grounded)
                {
                    animator.SetTrigger("Jump");
                    GetComponent<Rigidbody2D>().velocity = Vector2.up * 30.0f;
                    jumpStartTime = Time.fixedTime;
                    jumped = true;
                    jumpCount++;
                }
                break;
            case 1:
                if(!grounded)
                {
                    animator.Play("Player_Jump", 0, 0.0f);
                    GetComponent<Rigidbody2D>().velocity = new Vector2
                        (GetComponent<Rigidbody2D>().velocity.x, 20.0f);
                    jumped = true;
                    jumpCount++;
                }
                break;
        }
    }
}
