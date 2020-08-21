using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class GettingDiamonds : MonoBehaviour
{
    public GameObject NotEnough;
    public BecomePremium BP;
    public int NumberOFdiamondsforbad;
    private float timer = 0;
    private int count = 0;
    public Text text;
    public GameObject Page1;
    public Text NumberOfDiamonds;
    private bool SetAgainBool=true;
    private bool SetAgainBoolOfBackground = true;
    public Text ChangeThis;
    public GameObject Switch_Song;
    // Start is called before the first frame update
    public void HeWatchedIt()
    {
        NumberOFdiamondsforbad = int.Parse(NumberOfDiamonds.text);
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
            timer += Time.deltaTime;
            if (Application.isPlaying)
                NumberOfDiamonds.text = (int.Parse(NumberOfDiamonds.text) + 5).ToString();
            else
            {
                NumberOfDiamonds.text = NumberOFdiamondsforbad.ToString();
            }    
        }
    }
    public void HeWantNewSong()
    {
        if (SetAgainBool)
        {
            if (int.Parse(NumberOfDiamonds.text) >= 150)
            {
                NumberOfDiamonds.text = (int.Parse(NumberOfDiamonds.text) - 150).ToString();
                Switch_Song.SetActive(true);
                ChangeThis.text = "Bought,Can be changed in options";
                SetAgainBool = false;
            }
            else
            {
                NotEnough.SetActive(true);
            }
        }
    }

    public void HeWantNewBackground()
    {
        if (SetAgainBoolOfBackground)
        {
            if (int.Parse(NumberOfDiamonds.text) >= 120)
            {
                NumberOfDiamonds.text = (int.Parse(NumberOfDiamonds.text) - 120).ToString();
                SetAgainBoolOfBackground = false;
                text.text = "Bought,can be changed in the options";
                Page1.SetActive(true);
            }
            else
                NotEnough.SetActive(true); 
        }
      /*  if(!(SetAgainBoolOfBackground))
        {
            if (count % 2 == 0)
            {
                text.text = "Ecquied";
                Page2.SetActive(true);
                Page1.SetActive(false);
                count++;
            }
            else
            {
                text.text = "Not Ecquied";
                Page2.SetActive(false);
                Page1.SetActive(true);
                count++;

            }
        }
        */
    }

    public void Payment()
    {
        NumberOfDiamonds.text = (int.Parse(NumberOfDiamonds.text) + 200).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.Save();
    }
}
