using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VuforiaConnector : MonoBehaviour
{

    public static VuforiaConnector instance = null;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }

    public string activeTrackerName;

    public UnityEvent onTrackingFound;
    public UnityEvent onTrackingLost;


    public void OnTrackingFound(string trackerName)
    {

       activeTrackerName = trackerName;
       onTrackingFound.Invoke();

    }

    public void OnTrackingLost(string trackerName)
    {
        activeTrackerName = trackerName;
        onTrackingLost.Invoke();
    }
}
