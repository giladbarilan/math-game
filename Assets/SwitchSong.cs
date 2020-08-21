using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSong : MonoBehaviour
{
    public AudioClip AC1;
    public AudioClip AC2;
    public AudioSource AS;
    int times = 0;
    public void Start()
    {
        times++;
        if (times % 2 == 1)
        {
            AS.clip = AC1;
            AS.enabled = false;
            AS.enabled = true;
        }
        else
        {
            AS.clip = AC2;
            AS.enabled = false;
            AS.enabled = true;
        }
        }
}
