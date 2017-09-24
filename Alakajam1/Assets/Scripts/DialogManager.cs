using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private Image fireImg;
    [SerializeField]
    private Image airImg;
    [SerializeField]
    private Image waterImg;
    [SerializeField]
    private Image earthImg;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.main.GetFire())
        {
            //fireImg.enabled = true;
            fireImg.gameObject.SetActive(true);
        }
        else
        {
            fireImg.gameObject.SetActive(false);
        }
        if (GameManager.main.GetAir())
        {
            airImg.gameObject.SetActive(true);
        }
        else
        {
            airImg.gameObject.SetActive(false);
        }
        if (GameManager.main.GetWater())
        {
            waterImg.gameObject.SetActive(true);
        }
        else
        {
            waterImg.gameObject.SetActive(false);
        }
        if (GameManager.main.GetEarth())
        {
            earthImg.gameObject.SetActive(true);
        }
        else
        {
            earthImg.gameObject.SetActive(false);   
        }


        if (GameManager.main.GetInvFire())
        {
            setInvocation(fireImg, true);
        }
        else
        {
            setInvocation(fireImg, false);
        }

        if (GameManager.main.GetInvAir())
        {
            setInvocation(airImg, true);
        }
        else
        {
            setInvocation(airImg, false);
        }

        if (GameManager.main.GetInvWater())
        {
            setInvocation(waterImg, true);
        }
        else
        {
            setInvocation(waterImg, false);
        }

        if (GameManager.main.GetInvEarth())
        {
            setInvocation(earthImg, true);
        }
        else
        {
            setInvocation(earthImg, false);
        }
    }

    private void setInvocation(Image spell, bool value)
    {
        foreach (Transform child in spell.transform)
        {
            if (child.tag == "Invocation")
            {
                child.gameObject.SetActive(value);
            }
        }
    }
}
