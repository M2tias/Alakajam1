using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    [Range(0.5f, 5f)]
    private float speed = 1f;

    [SerializeField]
    [Range(0.2f, 2f)]
    private float speedFactor = 0.5f;

    [SerializeField]
    private GameObject hand;


    private Vector2 targetSpeed;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer _renderer;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>() as Animator;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float move_h = 0;
        float move_v = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.ResetTrigger("WalkUp");
            animator.ResetTrigger("WalkDown");
            animator.SetTrigger("WalkLeft");
            move_h = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.ResetTrigger("WalkUp");
            animator.ResetTrigger("WalkDown");
            animator.SetTrigger("WalkLeft");
            move_h = 1;
        }
        else
        {
            move_h = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //animator.ResetTrigger("IdleTrigger");
            animator.ResetTrigger("WalkLeft");
            animator.ResetTrigger("WalkDown");
            animator.SetTrigger("WalkUp");
            move_v = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.ResetTrigger("WalkLeft");
            animator.ResetTrigger("WalkUp");
            animator.SetTrigger("WalkDown");
            move_v = -1;
        }
        else
        {
            move_v = 0;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            hand.SetActive(true);
        }

        if (Mathf.Abs(move_h) == 1 && Mathf.Abs(move_v) == 1)
        {
            move_h = move_h / Mathf.Sqrt(2);
            move_v = move_v / Mathf.Sqrt(2);
        }

        if (move_h < 0 && !_renderer.flipX)
        {
            _renderer.flipX = true;
            Debug.Log("Flip");
        }
        else if (move_h > 0 && _renderer.flipX)
        {
            _renderer.flipX = false;
        }

        targetSpeed = new Vector2(speed * move_h, speed * move_v);
        rigidBody2D.AddForce(speedFactor * (targetSpeed - rigidBody2D.velocity), ForceMode2D.Impulse);
    }
}
