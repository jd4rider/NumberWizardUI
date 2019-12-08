using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{

    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    [SerializeField] TextMeshProUGUI thinkingText;

    int guess;
    ArrayList alreadyGuessed = new ArrayList();
    bool isPicked = false;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        thinkingText.text = "The number you are thinking of is:";
        NextGuess();
    }

    public void OnPressHigher()
    {
        min = guess;
        NextGuess();
    }

    public void OnPressLower()
    {
        max = guess;
        NextGuess();
    }

    private void NextGuess()
    {
        guess = Random.Range(min, max);

        if (max - min > 1)
        {
            if (alreadyGuessed.Contains(guess))
            {
                NextGuess();
            }
            alreadyGuessed.Add(guess);
            guessText.text = guess.ToString();
        }
        else if (isPicked)
        {
            thinkingText.text = "Now you are just messing with me, there is no other possible answer:";
        }
        else
        {
            if (guess >= 999 && guess < 1000) guess = 1000;
            isPicked = true;
            guessText.text = guess.ToString();
        }
    }
}
