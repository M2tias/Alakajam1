using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ditch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Summon")
        {
            Summon summon = coll.gameObject.GetComponent<Summon>();
            if (summon.GetType() == "Water")
            {
                GameObject newFloor = LevelManager.main.Instantiate(Resources.Load("object_ditch_filled", typeof(GameObject)) as GameObject);
                newFloor.transform.position = transform.position;
                Destroy(coll.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
