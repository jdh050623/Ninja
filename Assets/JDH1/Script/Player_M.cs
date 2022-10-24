using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_M : MonoBehaviour
{
    public float maxSpeed; //최대 속력 변수 
    Rigidbody2D rigid; //물리이동을 위한 변수 선언 
    SpriteRenderer spriteRenderer; //방향전환을 위한 변수 
    public Animator animator; //애니메이터 조작을 위한 변수 

    private void Awake()
    {

        rigid = GetComponent<Rigidbody2D>(); //변수 초기화 
        spriteRenderer = GetComponent<SpriteRenderer>(); // 초기화 
    }


    void Update()
    {
        if (Mathf.Abs(rigid.velocity.x) < 0.2) //속도가 0 == 멈춤 
            animator.SetBool("P_Walk", false); //isWalking 변수 : false 
        else// 이동중 
            animator.SetBool("P_Walk", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        {
            //오른쪽으로 이동 (+) , 최대 속력을 넘으면 
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y); //해당 오브젝트의 속력은 maxSpeed 
        }

        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            // 왼쪽으로 이동 (-) 
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y); //y값은 점프의 영향이므로 0으로 제한을 두면 안됨 
        }
        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        else if (h > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }
}
