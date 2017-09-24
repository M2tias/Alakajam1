using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JailDoor : MonoBehaviour
{
    private GameObject button;
    private GameObject overlap;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetButton(GameObject obj)
    {
        button = obj;
    }

    public void SetOverlap(GameObject obj)
    {
        overlap = obj;
    }

    public GameObject GetButton()
    {
        return button;
    }

    public GameObject GetOverlap()
    {
        return overlap;
    }

    public void CreateOverlap()
    {
        if(overlap != null)
        {
            GameObject newBars = LevelManager.main.Instantiate(Resources.Load("object_bars_overlap", typeof(GameObject)) as GameObject);
            newBars.transform.position = overlap.transform.position;
            Destroy(overlap);
            overlap = newBars;
        }
    }

    public void RemoveOverlap()
    {
        if (overlap != null)
        {
            GameObject newBars = LevelManager.main.Instantiate(Resources.Load("object_bars", typeof(GameObject)) as GameObject);
            newBars.transform.position = overlap.transform.position;
            Destroy(overlap);
            overlap = newBars;
        }
    }
}
