using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private TileType type;

    // Use this for initialization
    void Start()
    {
        if(type == TileType.Floor)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(type == TileType.Door)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
