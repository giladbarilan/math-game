using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnValueChanged : MonoBehaviour
{
    public AudioSource audio;
    public bool Boolean_ByInt;
    public int Boolean = 1;
    public void Mute_By_Creation()
    {
        Boolean++;
        if (Boolean % 2 == 0)
        {
            audio.mute = true;
        }
        else
            audio.mute = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
