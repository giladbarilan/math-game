using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class NEWONE1 : MonoBehaviour
{
    public BecomePremium bp;
    public GettingDiamonds GD;
    public AudioSource ToMuchTime;
    public float Timerr = 0;
    public AudioSource CorrectSource;
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
        {
            if (tries % 7 == 0)
            {
                if (Advertisement.IsReady())
                {
                    Advertisement.Show();
                }
            }
        }
        ToMuchTime.enabled = false;
        if (Timerr > 0)
        {
            GD.NumberOfDiamonds.text = (int.Parse(GD.NumberOfDiamonds.text) + 1).ToString();
        }
        Timerr = 0;
        CorrectSource.enabled = false;
        Timer.color = Color.black;
        AnswerInput.text = "0";
        //if (Boolean)
        {
            if (Boolean)
            {
                tries++;
                Boolean = false;
            }
            KeepScoreBool = true;
            Result += TimeTookYou;
            TimeTookYou = 0;
            First_Random = Random.Range(1, 100);
            Second_Random = Random.Range(1, 100);
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
        if(TimeTookYou>50)
        {
            ToMuchTime.enabled = true;
            Timer.color = Color.red;
        }
        Timer.text = TimeTookYou.ToString("0");
        Debug.Log(Answer);
        Answer = Mathf.Max(First_Random, Second_Random) *Mathf.Min(First_Random, Second_Random);
        string c = AnswerInput.text;
        /*if (AnswerInput.text == "")
        {
            AnswerInput.text = "0";
        }*/
        if (Answer.ToString() == AnswerInput.text)
        {
            if (TimeTookYou < 20)
            {
                Timer.color = Color.green;
            }
            KeepScoreBool = false;
            Correct.color = Color.green;
            Correct.text = "Correct! Move On!";
            CorrectSource.enabled = true;
            Boolean = true;
            Timerr += Time.deltaTime;
            if (Timerr > 3)
            {
                Start();
            }
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
