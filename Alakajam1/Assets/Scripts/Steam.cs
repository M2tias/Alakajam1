using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Transform child in LevelManager.main.GetContainer().transform)
        {
            if (child.tag == "Fire")
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
