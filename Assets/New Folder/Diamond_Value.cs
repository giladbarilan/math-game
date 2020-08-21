using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diamond_Value : MonoBehaviour
{
    public int Number_Of_Diamonds = 0;
    public Text Diamond_String;
    void Update()
    {
        Diamond_String.text = Number_Of_Diamonds.ToString();
    }
}
