using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class TrinomGenerator : MonoBehaviour
{
    public GettingDiamonds GD;
    public AudioSource ToMuchTime;
    float Timer2 = 0;
    public AudioSource CorrectSource;
    bool KeepScoreBool = true;
    public Text Timer;
    public int tries;
    public float Result;
    public float TimeTookYou;
    public Diamond_Value DV;
    public Text Correct;
    public InputField AnswerInput;
    public InputField AnswerInput2;
    public bool Boolean;
    public Text First_Num;
    public Text Second_Num;
    private int a;
    private int b;
    private int c;
    public int Answer;
    float checkanswer;
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
        if (Timer2 > 0)
        {
            GD.NumberOfDiamonds.text = (int.Parse(GD.NumberOfDiamonds.text) + 1).ToString();
        }
        Timer2 = 0;
        ToMuchTime.enabled = false;
        CorrectSource.enabled = false;
        Timer.color = Color.black;
        AnswerInput.text = "";
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
        Begin:;
            a = Random.Range(-100, 100);
            b = Random.Range(-100, 100);
            c = Random.Range(-100, 100);
            if ((b * b) < (4 * a * c))
            {
                goto Begin;
            }
            if ((int)Mathf.Sqrt((b * b) - 4 * a * c) != Mathf.Sqrt((b * b) - 4 * a * c))
            {
                goto Begin;
            }
            checkanswer = (b - Mathf.Sqrt((b * b) - 4 * a * c))/(2*a);
            if(checkanswer!=(int)checkanswer)
            {
                goto Begin;
            }
            checkanswer = b + Mathf.Sqrt((b * b) - 4 * a * c) / (2 * a);
            if(checkanswer!=(int)checkanswer)
            {
                goto Begin;
            }
            if(a==1)
            {
                First_Num.text = "x ";
            }
            else if(a==-1)
            {
                First_Num.text = "-x ";
            }
            else
            First_Num.text = a + "x" + " ";
            if (b >= 0)
            {
                First_Num.text += "+"+ b+"x"+" ";
            }
            else
                First_Num.text += b+"x"+" ";
            if (c >= 0)
            {
                First_Num.text += "+" + c;
            }
            else
                First_Num.text += c;

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
        float Answer=(-b+Mathf.Sqrt((b*b)-4*a*c))/(2*a);
        float Answer2 = ((-b - Mathf.Sqrt((b * b) - 4 * a * c)) / (2 * a));
        Debug.Log(Answer);
        Debug.Log(Answer2);
        //float Answer3 = Mathf.Max(Answer2, Answer);
        //float Answer4 = Mathf.Min(Answer2, Answer);
       /* if(AnswerInput2.text=="")
        {
            AnswerInput2.text = "0";
        }
        if (AnswerInput.text == "")
        {
            AnswerInput.text = "0";
        }
        */
        if (Answer.ToString() == AnswerInput.text && Answer2.ToString() == AnswerInput2.text)
        {
            if (TimeTookYou < 200)
            {
                Timer.color = Color.green;
            }
            KeepScoreBool = false;
            Correct.color = Color.green;
            Correct.text = "Correct! Move On!";
            CorrectSource.enabled = true;
            Boolean = true;
            Timer2 += Time.deltaTime;
            if (Timer2 > 3)
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
