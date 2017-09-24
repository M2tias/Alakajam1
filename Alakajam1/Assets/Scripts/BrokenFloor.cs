using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Rock")
        {
            Rock rock = coll.gameObject.GetComponent<Rock>();
            if (!rock.Used())
            {
                rock.Use();
                GameObject newFloor = LevelManager.main.Instantiate(Resources.Load("object_floor_filled", typeof(GameObject)) as GameObject);
                newFloor.transform.position = transform.position;
                Destroy(coll.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
