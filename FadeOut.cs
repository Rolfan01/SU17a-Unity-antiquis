using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{

    public Texture2D fadeOutTexture;    // The afading out texture
    public float fadeSpeed = 0.8f;      // The speed in which it fades

    private int drawDepth = -1000;      // The order in the draw hierarchy, low means top
    private float alpha = 1.0f;         // The texture's aplha value between 0 and 1
    private float fadeDir = -1;         // The direction to fade: = -1 or out = 1


    private void OnGUI()                // Fade out/in the alpha value using a direction, a speed and a Time.deltatime to convert the operation to seconds
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // Force (clamp) to number between 0 and 1 becuse GUI.color uses alpha values between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        // Set the colour of the GUI (in this case out texture). All colour values remain the same and the alpha is set to the alpha variabel
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);            // Set the alpha value
        GUI.depth = drawDepth;                                                          // Make the black texture render on top (drawn last)
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);   // Draw the texture to fit the entire screen area
    }
    
    
    // sets fadeDir to the reaction parameter making this scene fade in if -1 and out if 1
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);             // Return the fadeSpeed variable so it's easy to time the application.LoadLevel();
    }



    // OnLevelWasLoaded is called when a level is loaded. It takes loaded index (int) as a parametetr so youcan limit the fade in to certain scenes
    private void OnLevelWasLoaded()
    {
        // alpha =  1;                  // Use this if the alpha is not set to 1 by default
        BeginFade(-1);                  // Call the fade in function
    }

    /*float fadeTime = GameObject.Find("_GM").GetComponent<Fade>().BeginFade(1);
    yield return new WaitForSeconds(fadeTime);                                      // Use at the object that will change scene
    Application.LoadLevel(Application.loadedLevel + 1); */
}
