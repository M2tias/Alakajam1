using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    private Vector3 dir;
    private bool isEnabled = true;
    private string type;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isEnabled) return;
        else isEnabled = false;

        if(other.gameObject.tag == "Barrel" && type == "Air")
        {
            other.GetComponent<Barrel>().Move(dir);
            Destroy(gameObject);
        }
    }

    public void SetDir(Vector3 dir)
    {
        this.dir = dir;
    }

    public void SetType(string t)
    {
        type = t;
    }

    public string GetType()
    {
        return type;
    }
}
