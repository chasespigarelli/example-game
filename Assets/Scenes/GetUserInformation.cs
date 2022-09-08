using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetUserInformation : MonoBehaviour
{
    public GameObject userInfoContainer;
    public GameObject userInfoTemplate;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("http://localhost/UnityBackendTutorial/getAllTeachers.php"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    // Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    
                    
                    string rawresponse = webRequest.downloadHandler.text;

                    string[] users = rawresponse.Split(' ');

                    for( int i = 0; i < users.Length; i++ )
                    {
                        // Debug.Log("Current data: " + users[i]);
                        if( users[i] != "")
                        {
                           string[] userInfo = users[i].Split(' ');
                           Debug.Log("Name: " + users[i]);

                           GameObject gobj = (GameObject)Instantiate(userInfoTemplate);
                           gobj.transform.SetParent(userInfoContainer.transform);
                        }

                    }
                    
                    
                    
                    break;
            }
        }
    }

    
}
