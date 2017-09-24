using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool hasFire;
    [SerializeField]
    private bool hasAir;
    [SerializeField]
    private bool hasEarth;
    [SerializeField]
    private bool hasWater;

    [SerializeField]
    private bool invokedFire;
    [SerializeField]
    private bool invokedAir;
    [SerializeField]
    private bool invokedEarth;
    [SerializeField]
    private bool invokedWater;

    public static GameManager main;
    void Awake()
    {

        if (GameObject.FindGameObjectsWithTag("GameManager").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            this.tag = "GameManager";
            main = this;
        }

    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool GetFire() { return hasFire; }
    public bool GetAir() { return hasAir; }
    public bool GetEarth() { return hasEarth; }
    public bool GetWater() { return hasWater; }

    public void SetFire(bool value) { hasFire = value; }
    public void SetAir(bool value) { hasAir = value; }
    public void SetEarth(bool value) { hasEarth = value; }
    public void SetWater(bool value) { hasWater = value; }

    public bool GetInvFire() { return invokedFire; }
    public bool GetInvAir() { return invokedAir; }
    public bool GetInvEarth() { return invokedEarth; }
    public bool GetInvWater() { return invokedWater; }

    public void SetInvFire(bool value) { invokedFire = value; }
    public void SetInvAir(bool value) { invokedAir = value; }
    public void SetInvEarth(bool value) { invokedEarth = value; }
    public void SetInvWater(bool value) { invokedWater = value; }
}
