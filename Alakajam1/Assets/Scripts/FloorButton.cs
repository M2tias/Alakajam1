using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    private bool pressed = false;
    private GameObject door;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Rock" || coll.gameObject.tag == "Player" || coll.gameObject.tag == "Barrel")
        {
            GameObject newDoor = LevelManager.main.Instantiate(Resources.Load("object_bars_open", typeof(GameObject)) as GameObject);
            newDoor.transform.position = door.transform.position;
            JailDoor oj = door.GetComponent<JailDoor>();
            oj.CreateOverlap();
            JailDoor nj = newDoor.GetComponent<JailDoor>();
            nj.SetButton(oj.GetButton());
            nj.SetOverlap(oj.GetOverlap());
            Destroy(door);
            door = newDoor;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Rock" || coll.gameObject.tag == "Player" || coll.gameObject.tag == "Barrel")
        {
            GameObject newDoor = LevelManager.main.Instantiate(Resources.Load("object_bars_door", typeof(GameObject)) as GameObject);
            newDoor.transform.position = door.transform.position;
            JailDoor oj = door.GetComponent<JailDoor>();
            oj.RemoveOverlap();
            JailDoor nj = newDoor.GetComponent<JailDoor>();
            nj.SetButton(oj.GetButton());
            nj.SetOverlap(oj.GetOverlap());
            Destroy(door);
            door = newDoor;
        }
    }

    public void SetDoor(GameObject obj)
    {
        door = obj;
    }
}
