using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private TileType type;

    [SerializeField]
    private Tile doorPair; //if tile is a door in the underworld, it has a pair

    [SerializeField]
    //if tile is a door in the overworld, it has a level
    //underworld has a door to the overworld
    private string mapID; 

    private bool warped = false;

    // Use this for initialization
    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (type == TileType.Floor)
        {
            collider.enabled = false;
        }
        else if(type == TileType.Door)
        {
            collider.isTrigger = true;
            collider.size = new Vector2(0.5f, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDoorPair(Tile door)
    {
        doorPair = door;
        if (door.GetDoorPair() == null)
        {
            door.SetDoorPair(this);
        }
    }

    public Tile GetDoorPair()
    {
        return doorPair;
    }

    public void SetWarped(bool w)
    {
        warped = w;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !warped)
        {
            if (doorPair != null)
            {
                doorPair.SetWarped(true);
                other.gameObject.transform.position = doorPair.transform.position;
            }
            else if(mapID != "")
            {
                LevelManager.main.ChangeLevel(mapID);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SetWarped(false);
        }
    }

    public void SetMapID(string v)
    {
        mapID = v;
    }
}
