using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackTrigger : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Text you wish to show when the player enters")]
    private string textToShow;
    [SerializeField]
    [Tooltip("Furation you wish the text to show.")]
    private float durationToShow;
    [SerializeField]
    [Tooltip("By default, this trigger checks for the player (object tagged player). If you turn this on, you can check for a different game object.")]
    public bool checkForSpecificGameObject = false;
    [SerializeField]
    [Tooltip("What game object would you like the trigger to check for (by default it checks for the player tag)")]
    public GameObject gameObjectToCheckFor;
    [SerializeField]
    [Tooltip("Enabling the debug will show the green box during gameplay")]
    public bool debug = false;
    private FeedbackManager fbm;

    // Start is called before the first frame update
    void Start()
    {
        fbm = FindObjectOfType<FeedbackManager>();
        if(!debug)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(checkForSpecificGameObject)
        {
            if(other.gameObject == gameObjectToCheckFor)
            {
                ShowText();
            }
        }
        else if(other.tag == "Player")
        {
            ShowText();
        }
    }

    private void ShowText()
    {
        fbm.ShowFeedback(textToShow, durationToShow);
    }
}
