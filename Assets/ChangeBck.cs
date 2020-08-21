using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBck : MonoBehaviour
{
    public GameObject Page;
    int counter = 0;
    public void ChangeBackground()
    {
        if (counter % 2 == 0)
        {
            Page.SetActive(true);
        }
        else
        {
            Page.SetActive(false);
        }
        counter++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
