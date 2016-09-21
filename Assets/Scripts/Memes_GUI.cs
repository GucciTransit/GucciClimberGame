using UnityEngine;
using System.Collections;

public class Memes_GUI : MonoBehaviour
{
    public Rect position = new Rect(Screen.width / 2, Screen.height / 2, 100, 100);
    public string text = "";
    public GUIStyle style = null;

    // Variables for making the text disappear
    public float hideTextDuration;
    private bool shouldCheckInput = true;
    private bool shouldShowText = false;

    // Update is called once per frame
    private void Update()
    {
        if (shouldCheckInput)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                shouldCheckInput = false;
                shouldShowText = true;
                StartCoroutine(WaitAndMakeTextDisappear(hideTextDuration));
            }
        }
    }

    private IEnumerator WaitAndMakeTextDisappear(float waitTimeInSeconds)
    {
        yield return new WaitForSeconds(.5f);
        shouldShowText = false;
        shouldCheckInput = true;
    }

    // Called (several times per frame) for rendering and handling GUI events.
    private void OnGUI()
    {
        if (shouldShowText)
        {
            GUI.Label(position, text, style);
        }
    }
}