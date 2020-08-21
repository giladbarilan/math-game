using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Advertisements;
using UnityEngine.Advertisements;
public class PickRandomOfAd : MonoBehaviour
{
    
    public void PickRandom()
    {
            if (Random.Range(1, 4) == 2)
            {
                if (Advertisement.IsReady())
                {
                    Advertisement.Show();
                }
            }
        
    }
}
