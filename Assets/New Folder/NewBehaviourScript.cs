using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class NewBehaviourScript : MonoBehaviour
{
    public int NumberOfDiamonds;

    public NewBehaviourScript(GettingDiamonds GD)
    {
        NumberOfDiamonds = int.Parse(GD.NumberOfDiamonds.text);
    }
}
