using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class YourScores : MonoBehaviour
{
    public Text Minus;
    public Random_Numbers_Minus RNM;
    public Text PlusText;
    public PlusMode NO;
    public Text RNMultiText;
    public NEWONE1 NW;// Update is called once per frame
    public Text Dividng;
    public DivideScript DS;// Update is called once per frame
    void Update()
    {
        Minus.text = "Minus- " + ((RNM.tries*60) / (RNM.TimeTookYou)).ToString("0") + " Exresizes Per Minute";
        PlusText.text = "Plus- " + ((NO.tries*60) / (NO.TimeTookYou)).ToString("0") + " Exresizes Per Minute";
        RNMultiText.text = "Multipication- " + ((NW.tries*60 )/ (NW.TimeTookYou)).ToString("0") + " Exresizes Per Minute";
        Dividng.text = "Dividing- " + ((DS.tries*60) / DS.TimeTookYou).ToString("0") + " Exresizes Per Minute";
    }
}


