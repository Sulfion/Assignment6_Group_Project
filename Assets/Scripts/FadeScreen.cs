using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public FishGoalPositionController fishGoalPositionController;
    public FlockManager flockManager;

    public bool fadeOnStart = true;
    public float fadeDuration = 5;
    public Color fadeColor;
    private Renderer rend;

    public bool dontRefade = false;
    public int yetAnotherTracker = 0;

    // Start is called before the first frame update
    void Start()
    {
        flockManager = GameObject.FindWithTag("FlockManager").GetComponent<FlockManager>();

        rend = GetComponent<Renderer>();
        if (fadeOnStart)
        {
            FadeIn();
        }
    }

    public void Update()
    {
        fishGoalPositionController = GameObject.FindWithTag("Fish").GetComponent<FishGoalPositionController>();

        FadeInAndOutTwo();

        Debug.Log(fishGoalPositionController.currentLevelTracker);
        Debug.Log("Yet Another Tracker: " + yetAnotherTracker);
    }

    //use variable from fishgoalpositioncontroller to control fades based on number of fish caught
    //this is necessary because transition does not like to work properly while being called from another script
    //so it's variable is tracked here and sent to it instead
    //public IEnumerator FadeInAndOut()
    public void FadeInAndOutTwo()
    {
        if (fishGoalPositionController.currentLevelTracker == 1 && yetAnotherTracker == 0)
        {
            ManualAlphaChange();
            FadeIn();
            yetAnotherTracker++;
        }
        if (fishGoalPositionController.currentLevelTracker == 2 && yetAnotherTracker == 1)
        {
            ManualAlphaChange();
            FadeIn();
            yetAnotherTracker++;
        }
        if (fishGoalPositionController.currentLevelTracker == 3 && yetAnotherTracker == 2)
        {
            ManualAlphaChange();
            FadeIn();
            yetAnotherTracker++;
        }
        if (fishGoalPositionController.currentLevelTracker == 4 && yetAnotherTracker == 3)
        {
            ManualAlphaChange();
            FadeIn();
            yetAnotherTracker++;
        }
        if (fishGoalPositionController.currentLevelTracker == 5 && yetAnotherTracker == 4)
        {
            ManualAlphaChange();
            FadeIn();
            yetAnotherTracker++;
        }
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    //take alpha in/out, change alpha from 0-1/1-0, adjust alpha transition duration based on fade duration time, smooth alpha from one value to another
    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }
        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor("_Color", newColor2);
    }

    public void ManualAlphaChange()
    {
        Color newColor3 = rend.material.color;
        newColor3.a = 1;
        rend.material.SetColor("_Color", newColor3);
    }
}
