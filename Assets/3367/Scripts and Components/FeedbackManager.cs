using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackManager : MonoBehaviour
{
    private Text UIText;
    private float counter = 0;
    private float durationToShow = 1;
    private bool activated = false;

    void Start()
    {
        UIText = GetComponent<Text>();
    }

    void Update()
    {
        //Check if activated already
        if (activated)
        {
            //countdown timer
            counter += Time.deltaTime;
            if (counter >= durationToShow)
            {
                //Once timer is reached
                activated = false;
                //set text to nothing
                UIText.text = "";
            }
        }
    }


    public void ShowFeedback(string TextToShow, float _durationToShow)
    {
        counter = 0;
        activated = true;
        durationToShow = _durationToShow;
        UIText.text = TextToShow;
    }
}
