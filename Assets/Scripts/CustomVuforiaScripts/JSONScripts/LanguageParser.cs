using System.Collections;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;

public class LanguageParser : MonoBehaviour
{
    // button to run application with specific language
    public GameObject languageButton;

    public GameObject noInternetConnectionPanel;

    public Transform languagesParentGameObject;
    public string urlToJSON;

    Root items;
    string filePath;
    private string gameDataFileName = "languages.json";
    
    string x;

    IEnumerator DownloadDataSetupScene()
    {
        UnityWebRequest www = UnityWebRequest.Get(urlToJSON);
        yield return www.SendWebRequest();

        filePath= Path.Combine(Application.persistentDataPath, gameDataFileName);

        if (www.isNetworkError || www.isHttpError)
        {
            ReadJSONSetupMenu();
        }
        else
        {
            // read, parse and save JSON locally
            x = System.Net.WebUtility.HtmlDecode(www.downloadHandler.text);
            System.IO.File.WriteAllText(filePath, x);
            
            ReadJSONSetupMenu();
        }
    }

    // read data from locally saved file
    public void ReadJSONSetupMenu()
    {
        try
        {
            // read locally saved file containing JSON 
            string dataAsJson = File.ReadAllText(filePath);
            items=JsonUtility.FromJson<Root>(dataAsJson);

            int y=0;

            // assign each language button its data
            foreach (var item in items.Languages)    
            {
                languageButton.GetComponentInChildren<Text>().text = item.LanguageName;

                GameObject currentLanguage = Instantiate(languageButton, new Vector3(0, 0, 0), Quaternion.identity);
                int x = y;
                currentLanguage.GetComponent<Button>().onClick.AddListener(delegate { LanguageButtonHandler(x); });
            
                currentLanguage.transform.parent = languagesParentGameObject;
                y++;
            }
        }
        catch (FileNotFoundException e)
        {
            noInternetConnectionPanel.SetActive(true);
        }
    }


    // handlers for ID assignment to each language button
    public void LanguageButtonHandler(int languageIndex) 
    {
        SingletonManager.instance.language = items.Languages[languageIndex];
        SceneManager.LoadScene(1);
    }

    // upon start & repeat check when internet is down
    public void DownloadDataSetupSceneHandler()
    {
        StartCoroutine(DownloadDataSetupScene());
    }

    // on repeat button press
    public void RepeatJSONDownload()
    {
        noInternetConnectionPanel.SetActive(false);
        StartCoroutine(DownloadDataSetupScene());
    }

    void Start()
    {
        DownloadDataSetupSceneHandler();
    }
}
