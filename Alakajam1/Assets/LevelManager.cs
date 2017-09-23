using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<KeyValuePair<string, string>> levels;

	// Use this for initialization
	void Start () {
        levels = new List<KeyValuePair<string, string>>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
