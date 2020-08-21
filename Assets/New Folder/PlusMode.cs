using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class PlusMode : MonoBehaviour
{
    public BecomePremium BP;
    public GettingDiamonds GD;
    public AudioSource ToMuchTime;
    float Timer2;
    public AudioSource CorrectSource;
    public Color Color;
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
    private int First_Random;
    private int Second_Random;
    public int Answer;
    // Update is called once per frame
    public void Start()
    {
        if (tries % 7 == 0)
        {
           if (Advertisement.IsReady())
           {
              Advertisement.Show();
           }
        }
        ToMuchTime.enabled = false;
        if (Timer2 > 0)
        {
            GD.NumberOfDiamonds.text = (int.Parse(GD.NumberOfDiamonds.text) + 1).ToString();
        }
        Timer2 = 0;
        CorrectSource.enabled = false;
        //if (Boolean)
        {
            Timer.color = Color.black;
            if (Boolean)
            {
                tries++;
                Boolean = false;

            }
            KeepScoreBool = true;     
            Result += TimeTookYou;
            TimeTookYou = 0;
            First_Random = Random.Range(1, 5000);
            Second_Random = Random.Range(1, 5000);
            if (First_Random >= Second_Random)
            {
                First_Num.text = Stringi(First_Random);
                Second_Num.text = Stringi(Second_Random);
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
        Answer = Mathf.Max(First_Random, Second_Random) + Mathf.Min(First_Random, Second_Random);
        string c = AnswerInput.text;
        /*if (AnswerInput.text == "")
        {
            AnswerInput.text = "0";
        }*/
        if (Answer.ToString() == AnswerInput.text)
        {
            if(TimeTookYou<20)
            {
                Timer.color = Color.green;
            }
            KeepScoreBool = false;
            Correct.color = Color.green;
            Correct.text = "Correct! Move On!";
            CorrectSource.enabled = true;
            Boolean = true;
            Timer2 += Time.deltaTime;
            if(Timer2>3)
            Start();
        }
        else
        {
            Correct.color = Color.black;
            Correct.text = "";
            Boolean = false;
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

