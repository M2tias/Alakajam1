using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField]
    private string type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (type == "Fire") GameManager.main.SetFire(true);
            else if (type == "Air") GameManager.main.SetAir(true);
            else if (type == "Earth") GameManager.main.SetEarth(true);
            else if (type == "Water") GameManager.main.SetWater(true);
            Destroy(gameObject);
        }
    }
}
