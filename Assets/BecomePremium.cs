using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class BecomePremium : MonoBehaviour
{
    public bool IsPurchased;
    public void Start()
    {
        IsPurchased = false;
    }
    public void IsClicked()
    {
        IsPurchased = true;
    }

}
