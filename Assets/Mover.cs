using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 2.0f;
    [SerializeField] Sprite idleUp;
    [SerializeField] Sprite idleDown;
    [SerializeField] Sprite idleHorizontal;
    public Sprite idle;
    bool isIdle = false;
    SpriteRenderer spriteRenderer;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        idle = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalkingHorizontal", false); animator.SetBool("isWalkingUp", false);
        isIdle = true;
        Debug.Log(idle);
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            animator.SetBool("isWalkingUp", true);
            idle = idleUp;
            isIdle = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            animator.SetBool("isWalkingHorizontal", true);
            idle = idleDown;
            isIdle = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            animator.SetBool("isWalkingHorizontal", true);
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            idle = idleHorizontal;
            isIdle = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            animator.SetBool("isWalkingHorizontal", true);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            idle = idleHorizontal;
            isIdle = false;
        }
    }

    private void LateUpdate()
    {
        if (isIdle)
        {
            spriteRenderer.sprite = idle;
        }
    }
}