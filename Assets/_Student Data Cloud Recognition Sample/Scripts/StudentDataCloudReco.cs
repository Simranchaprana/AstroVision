using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public class StudentDataClodReco : MonoBehaviour
{
    public StudentDataUIManager studentDataUIManager; // Replace StudentDataUIManager studentDataUIManager;
    CloudRecoBehaviour mCloudRecoBehaviour;
    bool mIsScanning = false;
    string mTargetMetadata = "";

    public TMP_Text scanningStatusTMP;
    public Button scanBTN;

    public ImageTargetBehaviour ImageTargetTemplate;

    public GameObject worldSpaceDataCanvas;

    // Register cloud reco callbacks
    void Awake()
    {
        mCloudRecoBehaviour = GetComponent<CloudRecoBehaviour>();
        mCloudRecoBehaviour.RegisterOnInitializedEventHandler(OnInitialized);
        mCloudRecoBehaviour.RegisterOnInitErrorEventHandler(OnInitError);
        mCloudRecoBehaviour.RegisterOnUpdateErrorEventHandler(OnUpdateError);
        mCloudRecoBehaviour.RegisterOnStateChangedEventHandler(OnStateChanged);
        mCloudRecoBehaviour.RegisterOnNewSearchResultEventHandler(OnNewSearchResult);
    }
    //Unregister cloud reco callbacks when the handler is destroyed
    void OnDestroy()
    {
        mCloudRecoBehaviour.UnregisterOnInitializedEventHandler(OnInitialized);
        mCloudRecoBehaviour.UnregisterOnInitErrorEventHandler(OnInitError);
        mCloudRecoBehaviour.UnregisterOnUpdateErrorEventHandler(OnUpdateError);
        mCloudRecoBehaviour.UnregisterOnStateChangedEventHandler(OnStateChanged);
        mCloudRecoBehaviour.UnregisterOnNewSearchResultEventHandler(OnNewSearchResult);
    }

    public void OnInitialized(CloudRecoBehaviour cloudRecoBehaviour)
    {
        //Debug.Log("Cloud Reco initialized");
        scanningStatusTMP.text = "Scanning...";
        scanBTN.interactable = false;
    }

    public void OnInitError(CloudRecoBehaviour.InitError initError)
    {
        //Debug.Log("Cloud Reco init error " + initError.ToString());
        scanningStatusTMP.text = "Init Error";
        scanBTN.interactable = true;
    }

    public void OnUpdateError(CloudRecoBehaviour.QueryError updateError)
    {
        //Debug.Log("Cloud Reco update error " + updateError.ToString());
        scanningStatusTMP.text = "Update Error";
        scanBTN.interactable = true;

    }

    public void OnStateChanged(bool scanning)
    {
        mIsScanning = scanning;

        scanningStatusTMP.text = scanning ? "Scanning..." : "Not Scanning";
    }

    // Here we handle a cloud target recognition event
    public void OnNewSearchResult(CloudRecoBehaviour.CloudRecoSearchResult cloudRecoSearchResult)
    {
        string json = cloudRecoSearchResult.MetaData;

        Debug.Log(json);

        // Pass JSON to UI Manager
        studentDataUIManager.LoadData(json); // Replace studentDataUIManager

        // Build augmentation based on target 
        if (ImageTargetTemplate)
        {
            worldSpaceDataCanvas.SetActive(true);
            /* Enable the new result with the same ImageTargetBehaviour: */
            mCloudRecoBehaviour.EnableObservers(cloudRecoSearchResult, ImageTargetTemplate.gameObject);
        }

        // Stop scanning
        mCloudRecoBehaviour.enabled = false;
        scanningStatusTMP.text = "Not Scanning";
        scanBTN.interactable = true;
    }

    // OnClick Event for Scan BTN
    public void RestartScanning()
    {
        studentDataUIManager.ClearUI(); // Replace studentDataUIManager
        mCloudRecoBehaviour.enabled = true;
        scanningStatusTMP.text = "Scanning...";
        worldSpaceDataCanvas.SetActive(false);
    }
}
