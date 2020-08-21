using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour
{
    public Diamond_Value DV;
    public Text Bougth;
    public bool Boolean;
    public void DecreaseAndRealese()
    {
        if (Boolean)
        {
            if (DV.Number_Of_Diamonds >= 10)
            {
                DV.Number_Of_Diamonds -= 10;
                Bougth.text = "    Bougth";
                Boolean = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
