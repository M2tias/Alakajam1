using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in LevelManager.main.GetContainer().transform)
        {
            if (child.tag == "Barrel")
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
