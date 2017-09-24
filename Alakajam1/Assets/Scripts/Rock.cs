using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private bool used;

    // Use this for initialization
    void Start()
    {
        used = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool Used()
    {
        return used;
    }

    public void Use()
    {
        used = true;
    }
}
