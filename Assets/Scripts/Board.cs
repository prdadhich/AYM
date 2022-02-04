using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Board : MonoBehaviour
{
    // Start is called before the first frame update
    public TouchScreenKeyboard keyboard;
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


public void OpenSystemKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true, true, false, false);
    }
}
