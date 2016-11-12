using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TerminalHandler : MonoBehaviour {

    public Text currenPath;
    private CommandLog commandLog;

    private string currentSearchPath = "C:\\";

    private string[] locations = { "C:\\patients\\", "C:\\journals\\" };
    private string[] patientFiles = { "" };

    void Start()
    {
        commandLog = FindObjectOfType<CommandLog>();
    }

	public void handleCommand(string commandString)
    {
        if (commandString.Contains(" "))
        {
            // Switch search path command
            if (commandString.Substring(0, commandString.IndexOf(' ')) == "cd")
            {
                bool validPath = false;
                for (int i = 0; i < locations.Length; i++)
                {
                    print(commandString.Split(' ')[1]);
                    if (commandString.Split(' ')[1] == locations[i])
                        validPath = true;
                }
                if (validPath)
                {
                    currentSearchPath = commandString.Split(' ')[1];
                    commandLog.addEvent("Moved to " + currentSearchPath);
                    currenPath.text = "Path: " + currentSearchPath;
                }
                else
                    commandLog.addEvent("Invalid path");
            }
            // Echo command simply log a string
            else if (commandString.Contains("echo") && commandString.Contains(" "))
            {
                commandLog.addEvent(commandString.Split(' ')[1]);
            }
        }
        // List all command
        else if (commandString == "ls")
        {
            if(currentSearchPath == "C:\\")
            {
                commandLog.addEvent("[patients\\], [journals\\]");
            }
            else if(currentSearchPath == "C:\\patients\\")
            {

            }
            else if(currentSearchPath == "C:\\journals\\")
            {

            }
        }
        // Print some help
        else if(commandString == "help")
        {
            commandLog.addEvent("cd - [parameter] path");
            commandLog.addEvent("echo - [parameter] string");
            commandLog.addEvent("ls - listes possible files");
            commandLog.addEvent("clear - clears command log");
        }
        // Clears the command log 
        else if(commandString == "clear")
        {
            commandLog.ClearScreen();
        }
    }


}
