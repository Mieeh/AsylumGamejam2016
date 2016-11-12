using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

/*
 * Will handle writing to the main input line
 * And when entered is press it will send the input text string 
 * To terminal handler where the command entered will be processed
 */

public class TerminalInput : MonoBehaviour {

    public InputField textInput;
    private TerminalHandler terminalHandler;

    void Start()
    {
        terminalHandler = FindObjectOfType<TerminalHandler>();
        textInput.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            sendStringCommand();
    }

    void sendStringCommand()
    {
        print("Sending string " + textInput.text);
        terminalHandler.handleCommand(textInput.text);
    }
  
}
