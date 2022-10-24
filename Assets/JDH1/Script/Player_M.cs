using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_M : MonoBehaviour
{
    public float maxSpeed; //�ִ� �ӷ� ���� 
    Rigidbody2D rigid; //�����̵��� ���� ���� ���� 
    SpriteRenderer spriteRenderer; //������ȯ�� ���� ���� 
    public Animator animator; //�ִϸ����� ������ ���� ���� 

    private void Awake()
    {

        rigid = GetComponent<Rigidbody2D>(); //���� �ʱ�ȭ 
        spriteRenderer = GetComponent<SpriteRenderer>(); // �ʱ�ȭ 
    }


    void Update()
    {
        if (Mathf.Abs(rigid.velocity.x) < 0.2) //�ӵ��� 0 == ���� 
            animator.SetBool("P_Walk", false); //isWalking ���� : false 
        else// �̵��� 
            animator.SetBool("P_Walk", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
        {
            //���������� �̵� (+) , �ִ� �ӷ��� ������ 
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y); //�ش� ������Ʈ�� �ӷ��� maxSpeed 
        }

        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            // �������� �̵� (-) 
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y); //y���� ������ �����̹Ƿ� 0���� ������ �θ� �ȵ� 
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
