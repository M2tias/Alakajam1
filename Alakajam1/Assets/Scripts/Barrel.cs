using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    Vector3 oldPos;
    bool canMove = true;

    // Use this for initialization
    void Start()
    {
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector3 pos)
    {
        if (canMove)
        {
            transform.position = transform.position + pos;
            StartCoroutine(WaitASec());
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        /*if(coll.gameObject.tag == "Player")
        {
            canMove = true;
        }
        else*/ if(transform.position != oldPos)
        {
            transform.position = oldPos;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        /*if (coll.gameObject.tag == "Player")
        {
            canMove = false;
        }*/
    }

    private IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(0.1f);
        oldPos = transform.position;
    }
}
