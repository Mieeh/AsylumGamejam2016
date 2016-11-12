using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CommandLog : MonoBehaviour
{

    private List<string> events = new List<string>();
    private int maxNumberOfEvents = 13;

    public Text eventText;

    public void addEvent(string _event)
    {
        if (events.Count < maxNumberOfEvents)
        {
            // We have room so just add the event 
            events.Insert(0, _event);
        }
        else
        {
            // This will be executed if the events is filled to the brink 
            events.RemoveAt(12);
            events.Insert(0, _event);
        }
        DrawText();
    }

    void DrawText()
    {
        eventText.text = string.Empty;
        for (int i = 0; i < events.Count; i++)
        {
            eventText.text += events[i] + "\n";
        }
    }

    public void ClearScreen()
    {
        eventText.text = string.Empty;
        events.Clear();
    }
}
