using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class DivideScript : MonoBehaviour
{
    public BecomePremium BP;
    public GettingDiamonds GD;
    public AudioSource ToMuchTime;
    float Timer2;
    public AudioSource CorrectS;
    bool KeepScoreBool = true;
    public Text Timer;
    public int tries;
    public float Result;
    public float TimeTookYou;
    public Text Correct;
    public InputField AnswerInput;
    public bool Boolean;
    public Text First_Num;
    public Text Second_Num;
    public int First_Random;
    public int Second_Random;
    public float Answer;
    // Update is called once per frame
    void Start()
    {
            if (tries % 7 == 0)
            {
                if (Advertisement.IsReady())
                {
                    Advertisement.Show();
                }
           }
        
        ToMuchTime.enabled = false;
        if(Timer2>0)
        {
            GD.NumberOfDiamonds.text = (int.Parse(GD.NumberOfDiamonds.text) + 1).ToString();
        }
        Timer2 = 0;
        CorrectS.enabled = false;
        Timer.color = Color.black;
    StartOfProgram:;
        if (Boolean)
        {
            tries++;
            Boolean = false;

        }
        KeepScoreBool = true;    
        Result += TimeTookYou;
        TimeTookYou = 0;
        First_Random = Random.Range(1, 10000);
            Second_Random = Random.Range(1, 1000);
            if (First_Random >= Second_Random)
            {
            if ((float)First_Random / (float)Second_Random != First_Random / Second_Random)
            {
                goto StartOfProgram;
            }
            else
            {
                First_Num.text = Stringi(First_Random);
                Second_Num.text = Stringi(Second_Random);
            }
            }
            else
            {
                if (((double)(Second_Random / (double)First_Random) != (int)(Second_Random / First_Random)))
                {
                goto StartOfProgram;
                }
                else
                {
                    Second_Num.text = Stringi(First_Random);
                    First_Num.text = Stringi(Second_Random);
                }
            }
        }
    private void Update()
    {
        if (KeepScoreBool)
            TimeTookYou += Time.deltaTime;
        Timer.text = TimeTookYou.ToString("0");
        if (TimeTookYou > 50)
        {
            ToMuchTime.enabled = true;
            Timer.color = Color.red;
        }
        Debug.Log(Answer);
        Answer = Mathf.Max(First_Random, Second_Random) / Mathf.Min(First_Random, Second_Random);
        string c = AnswerInput.text;
    /*    if (AnswerInput.text == "")
        {
            AnswerInput.text = "0";
        }
        */
        if (Answer.ToString() == AnswerInput.text)
        {
            if (TimeTookYou < 20)
            {
                Timer.color = Color.green;
            }
            Correct.color = Color.green;
            Correct.text = "Correct! Move On!";
            CorrectS.enabled = true;
            KeepScoreBool = false;
            Timer2 += Time.deltaTime;
            if(Timer2>3)
            {
                Start();
            }
        }
        else
        {
            Correct.color = Color.black;
        }
    }
    public static string Stringi(int a)
    {
        string c = "";
        string b = "";
        while (a > 0)
        {
            b += " " + a % 10;
            a /= 10;
        }
        for (int i = 0; i < b.Length; i++)
        {
            c += b[b.Length - i - 1];
        }
        return c;
    }
}
