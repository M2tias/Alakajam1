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

    [SerializeField]
    private float invokeTime = 5f;
    private float lastInvoke = 0f;

    private Vector3 dir;

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

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.J))
        {
            animator.ResetTrigger("WalkUp");
            animator.ResetTrigger("WalkDown");
            animator.SetTrigger("WalkLeft");
            move_h = -1;
            dir = Vector3.left;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.L))
        {
            animator.ResetTrigger("WalkUp");
            animator.ResetTrigger("WalkDown");
            animator.SetTrigger("WalkLeft");
            move_h = 1;
            dir = Vector3.right;
        }
        else
        {
            move_h = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.I))
        {
            //animator.ResetTrigger("IdleTrigger");
            animator.ResetTrigger("WalkLeft");
            animator.ResetTrigger("WalkDown");
            animator.SetTrigger("WalkUp");
            move_v = 1;
            dir = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.K))
        {
            animator.ResetTrigger("WalkLeft");
            animator.ResetTrigger("WalkUp");
            animator.SetTrigger("WalkDown");
            move_v = -1;
            dir = Vector3.down;
        }
        else
        {
            move_v = 0;
        }

        if (invokeTime < (Time.fixedTime - lastInvoke))
        {
            if (GameManager.main.GetFire() && Input.GetKey(KeyCode.A))
            {
                GameManager.main.SetInvFire(!GameManager.main.GetInvFire());
                lastInvoke = Time.fixedTime;
            }
            if (GameManager.main.GetAir() && Input.GetKey(KeyCode.S))
            {
                GameManager.main.SetInvAir(!GameManager.main.GetInvAir());
                lastInvoke = Time.fixedTime;
            }
            if (GameManager.main.GetWater() && Input.GetKey(KeyCode.D))
            {
                GameManager.main.SetInvWater(!GameManager.main.GetInvWater());
                lastInvoke = Time.fixedTime;
            }
            if (GameManager.main.GetEarth() && Input.GetKey(KeyCode.F))
            {
                GameManager.main.SetInvEarth(!GameManager.main.GetInvEarth());
                lastInvoke = Time.fixedTime;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            hand.SetActive(true);
            invoke();
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

    private void invoke()
    {
        if (GameManager.main.GetInvFire())
        {
            if (GameManager.main.GetInvAir())
            {
                if (GameManager.main.GetInvWater())
                {
                    if (GameManager.main.GetInvEarth())
                    {
                        //f, a, w, e
                    }
                }
                else if (GameManager.main.GetInvEarth())
                {
                    //f, a, e
                }
                else
                {
                    //f, a
                }
            }
            else if (GameManager.main.GetInvWater())
            {
                if (GameManager.main.GetInvEarth())
                {
                    //f, w, e
                }
                else
                {
                    //f, w
                }
            }
            else if (GameManager.main.GetInvEarth())
            {
                //f, e
            }
            else
            {
                //f 
                GameObject prefab = Resources.Load("Fire", typeof(GameObject)) as GameObject;
                GameObject summon = LevelManager.main.Instantiate(prefab);
                summon.transform.position = front();
                Summon s = summon.GetComponent<Summon>();
                s.SetDir(dir);
                s.SetType("Fire");
                GameManager.main.SetInvFire(false);

                StartCoroutine(DeleteLater(summon));
            }
        }
        else if (GameManager.main.GetInvAir())
        {
            if (GameManager.main.GetInvWater())
            {
                if (GameManager.main.GetInvEarth())
                {
                    //a, w, e
                }
                else
                {
                    //a, w
                    GameObject prefab = Resources.Load("Steam", typeof(GameObject)) as GameObject;
                    GameObject summon = LevelManager.main.Instantiate(prefab);
                    summon.transform.position = front();
                    GameManager.main.SetInvAir(false);
                    GameManager.main.SetInvWater(false);

                    StartCoroutine(DeleteLater(summon));
                }
            }
            else if (GameManager.main.GetInvEarth())
            {
                //a, e
            }
            else
            {
                //a
                GameObject prefab = Resources.Load("summon", typeof(GameObject)) as GameObject;
                GameObject summon = LevelManager.main.Instantiate(prefab);
                Summon s = summon.GetComponent<Summon>();
                s.SetDir(dir);
                s.SetType("Air");
                summon.transform.position = front();
                GameManager.main.SetInvAir(false);

            }
        }
        else if (GameManager.main.GetInvWater())
        {
            if (GameManager.main.GetInvEarth())
            {
                //w, e
            }
            else
            {
                //w
                GameObject prefab = Resources.Load("summon", typeof(GameObject)) as GameObject;
                GameObject summon = LevelManager.main.Instantiate(prefab);
                Summon s = summon.GetComponent<Summon>();
                s.SetDir(dir);
                s.SetType("Water");
                summon.transform.position = front();
                GameManager.main.SetInvWater(false);
            }
        }
        else if (GameManager.main.GetInvEarth())
        {
            //e
            GameObject prefab = Resources.Load("object_rock", typeof(GameObject)) as GameObject;
            GameObject rock = LevelManager.main.Instantiate(prefab);
            rock.transform.position = front();
            GameManager.main.SetInvEarth(false);
        }
    }

    private Vector3 front()
    {
        return transform.position + dir;
    }

    private IEnumerator DeleteLater(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        Destroy(obj);
    }
}
