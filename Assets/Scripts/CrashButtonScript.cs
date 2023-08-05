using UnityEngine;
using UnityEngine.UI;

public class CrashButtonScript : MonoBehaviour
{
    // Text that will appear on the button
    private string buttonText = "Cause Crash!";

    void OnGUI()
    {
        GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
        myButtonStyle.fontSize = 25;

        // Calculate button position and size
        float buttonWidth = 200;
        float buttonHeight = 70;
        float buttonX = (Screen.width / 2) - (buttonWidth / 2);
        float buttonY = (Screen.height / 2) - (buttonHeight / 2);

        // Create a rect for button
        Rect buttonRect = new Rect(buttonX, buttonY, buttonWidth, buttonHeight);

        // Create a button and add a function to perform when it's clicked
        if (GUI.Button(buttonRect, buttonText, myButtonStyle))
        {
            // Force a native crash for testing Crashlytics
            throw new System.Exception("(ignore) this is a test crash");
        }
    }
}