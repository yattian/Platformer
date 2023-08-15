using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // Important for accessing the Button type

public class ButtonDisabler : MonoBehaviour
{
    public Button yourButton;  // Assign this through the editor
    public Button yourButton2;  // Assign this through the editor

    void Start()
    {
        yourButton.interactable = false;
        yourButton2.interactable = false; // This will disable the button
    }

    // To enable it again:
    // yourButton.interactable = true;
}
