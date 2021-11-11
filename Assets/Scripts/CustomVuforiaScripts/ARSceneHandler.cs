using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ARSceneHandler : MonoBehaviour
{
    public Transform ARMenuPanel;

    // item to instantiate
    public GameObject infoTextItem;

    public Transform infoTextPanel;
    public GameObject infoPanel;

    // card data
    public Image cardImage;
    public GameObject cardPanel;

    // description data
    public Text descriptionText;
    public GameObject descriptionPanel;

    public GameObject uiButton;

    // active tracker data
    int trackerIndex;
    string trackerName;
    
    ARData[] arData;
    ARDataKeys[] arDataKeys;
    List<ARApplication> arApplication;

    void Awake()
    {
        // shorten singleton property
        arData = SingletonManager.instance.language.ARApplication[0].ARData;
        arDataKeys = SingletonManager.instance.language.ARApplication[0].ARDataKeys;
        arApplication = SingletonManager.instance.language.ARApplication;
    }

    public void OnTrackingFound()
    {
        int y =0;
        
        // loop through tracker name upon finding a tracker
        foreach (var item in arData)    
        {
            if (VuforiaConnector.instance.activeTrackerName == arData[y].TrackerName)
            {
                trackerIndex = y;
                trackerName = arData[y].TrackerName;
            }
            else
                y++;

        }

        // ****assign key:value info from JSON**** = prevent memory leaks
    
        // check if AnimalName key is empty
        if (arData[0].BasicInfoText[0].AnimalName != null)
        {
            // use key in appropriate language with :
            CreateTextItem(String.Concat (arDataKeys[0].AnimalName,":"));

            // use value of AnimalName and add it to panel
            CreateTextItem(arData[y].BasicInfoText[0].AnimalName);
        }

        // check if OrderName key is empty
        if (arData[0].BasicInfoText[0].OrderName != null)
        {
            // use key in appropriate language with :
            CreateTextItem(String.Concat (arDataKeys[0].OrderName,":"));
            CreateTextItem(arData[y].BasicInfoText[0].OrderName);

        }

        // check if Lifespan key is empty
        if (arData[0].BasicInfoText[0].Lifespan != null)
        {
            // use key in appropriate language with :
            CreateTextItem(String.Concat (arDataKeys[0].Lifespan,":"));

            // use value of AnimalName and add it to panel
            CreateTextItem(arData[y].BasicInfoText[0].Lifespan);
        }

        // ***main buttons***
        // basic info button

        CreateButtonItem(arApplication[0].BasicInfo, infoPanel,descriptionPanel,cardPanel);

        // description button
        CreateButtonItem(arApplication[0].Description, descriptionPanel, infoPanel,cardPanel);

        // change description on screen
        descriptionText.text = arData[y].DescriptionText;

        // card button
        CreateButtonItem(arApplication[0].Card, cardPanel,descriptionPanel, infoPanel);

        // load and assign required sprite
        var sprite = Resources.Load<Sprite>("ARMuseum/"+trackerName);
        cardImage.enabled =true;
        cardImage.sprite = sprite;

        
    }
    // enable only panel which one of buttons enables
    public void BasicInfoTextDisplay(GameObject panel, GameObject disablePanel1, GameObject disablePanel2)
    {
        panel.SetActive(true);

        if (disablePanel1.activeSelf)
            disablePanel1.SetActive(false);

        if (disablePanel2.activeSelf)
            disablePanel2.SetActive(false);
    }

    
    public void OnTrackingLost()
    {
        // disable all UI panels
        if (cardPanel.activeSelf)
            cardPanel.SetActive(false);

        if (descriptionPanel.gameObject.activeSelf)
            descriptionPanel.gameObject.SetActive(false);

        if (infoPanel.gameObject.activeSelf)
            infoPanel.gameObject.SetActive(false);

        // destroy 3 main UI buttons
        for (int i=0; i<ARMenuPanel.childCount; i++)
            Destroy(ARMenuPanel.GetChild(i).gameObject);

        // destroy JSON key:value text items
        for (int i=0; i<infoTextPanel.childCount; i++)
            Destroy(infoTextPanel.GetChild(i).gameObject);
    }

    // create GO with text component (key value texts)- assign required text and add it to text panel panel
   public void CreateTextItem(string textToAssign)
    {
        // instantiate item
        GameObject itemToInstantiate = Instantiate(infoTextItem, new Vector3(0, 0, 0), Quaternion.identity);
     
        // assign text to the item
        itemToInstantiate.GetComponent<Text>().text = textToAssign;

        // parent the text item
        itemToInstantiate.transform.parent = infoTextPanel;
    }

    // create GO with button component - for main menu to be added
    public void CreateButtonItem(string textToAssign, GameObject enablePanel,GameObject disablePanel1,GameObject disablePanel2)
    {
        GameObject buttonItem = Instantiate(uiButton, new Vector3(0, 0, 0), Quaternion.identity);
        buttonItem.transform.GetComponentInChildren<Text>().text = textToAssign;
        buttonItem.GetComponent<Button>().onClick.AddListener(delegate { BasicInfoTextDisplay(enablePanel,disablePanel1,disablePanel2); });
        buttonItem.transform.parent = ARMenuPanel;
    } 
}