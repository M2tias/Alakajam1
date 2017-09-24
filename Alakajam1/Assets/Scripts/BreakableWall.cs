using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour {
    [SerializeField]
    private string dir;

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
            if (summon.GetType() == "Bomb")
            {
                GameObject newFlames = LevelManager.main.Instantiate(Resources.Load("Flames", typeof(GameObject)) as GameObject);
                GameObject newFloor = null;
                if (dir == "Top")
                {
                    newFloor = LevelManager.main.Instantiate(Resources.Load("Flames", typeof(GameObject)) as GameObject);
                }
                else if (dir == "Bottom")
                {
                    newFloor = LevelManager.main.Instantiate(Resources.Load("Flames", typeof(GameObject)) as GameObject);
                }
                newFloor.transform.position = transform.position;
                newFlames.transform.position = transform.position;
                Destroy(coll.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
