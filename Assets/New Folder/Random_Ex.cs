using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Random_Numbers_Multipication : MonoBehaviour
{
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
        AnswerInput.text = "0";
        //if (Boolean)
        {
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
        Debug.Log(Answer);
        Answer = First_Random * Second_Random;
        string c = AnswerInput.text;
        if (Answer.ToString() == AnswerInput.text)
        {
            Correct.text = "Correct! Move On!";
        }
        else
            Correct.text = "";
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
