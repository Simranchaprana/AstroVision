using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using System.Collections;

public class StudentDataUIManager : MonoBehaviour
{
    // Create Data Fields according to your JSON data
    [Header("UI Elements")]
    public TMP_Text studentNameTMP;  
    public TMP_Text locationTMP;
    public TMP_Text studentprofileURLTMP;

    public RawImage photoRawImage;
    public RawImage videoRawImage;
    public Button audioToggleButton;

    [Header("Media Players")]
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    StudentData studentData; // Replace StudentData studentData;

    // Method to save data from studentData to UI data fields
    public void LoadData(string json)
    {

        // Stop currently playing media
        if (videoPlayer.isPlaying) videoPlayer.Stop();
        if (audioSource.isPlaying) audioSource.Stop();

        // Clear old textures
        photoRawImage.texture = null;  // Replace photoRawImage
        videoRawImage.texture = null;  // Replace videoRawImage

        studentData = JsonUtility.FromJson<StudentData>(json); // Replace studentData and StudentData 
         
        studentNameTMP.text = studentData.studentName; // Replace
        locationTMP.text = studentData.location; // Replace
        studentprofileURLTMP.text = studentData.studentprofileURL; // Replace

        StartCoroutine(LoadImage(studentData.photo)); // Replace
        StartCoroutine(LoadVideo(studentData.shortVideoDescription)); // Replace
        StartCoroutine(LoadAudio(studentData.audioDescription)); // Replace
    }

    // Coroutine to download Image
    IEnumerator LoadImage(string url)
    {
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);
        yield return req.SendWebRequest();
        if (req.result != UnityWebRequest.Result.Success) yield break;

        photoRawImage.texture = DownloadHandlerTexture.GetContent(req);
    }

    // Coroutine to download Video
    IEnumerator LoadVideo(string url)
    {
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.targetTexture = new RenderTexture(512, 512, 0);
        videoRawImage.texture = videoPlayer.targetTexture;

        videoPlayer.Play();
        yield return null;
    }

    // Coroutine to download Audio
    IEnumerator LoadAudio(string url)
    {
        UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);
        yield return req.SendWebRequest();
        if (req.result != UnityWebRequest.Result.Success) yield break;

        AudioClip clip = DownloadHandlerAudioClip.GetContent(req);
        audioSource.clip = clip;
    }

    // OnClick Event for AudioBTN
    public void ToggleAudio()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();
        else
            audioSource.Play();
    }

    // OnClick Event for Student Profile URL
    // Attach Button component to studentprofileURL TMP
    public void OpenURL()
    {
        if (!string.IsNullOrEmpty(studentData.studentprofileURL)) // Replace studentData.studentprofileURL
            Application.OpenURL(studentData.studentprofileURL); // Replace studentData.studentprofileURL
    }

    // Called inside RestartScanning() in StudentDataCloudReco script
    // Clears UI
    public void ClearUI()
    {
        // Clear text fields
        studentNameTMP.text = "";   // Replace studentNameTMP
        locationTMP.text = "";      // Replace locationTMP
        studentprofileURLTMP.text = ""; // Replace locationTMP


        // Stop media
        if (videoPlayer != null && videoPlayer.isPlaying)
            videoPlayer.Stop();

        if (audioSource != null && audioSource.isPlaying)
            audioSource.Stop();

        // Clear thumbnail
        if (photoRawImage != null)  // Replace photoRawImage
            photoRawImage.texture = null; // Replace photoRawImage

        // Clear video texture
        if (videoRawImage != null) // Replace videoRawImage
            videoRawImage.texture = null; // Replace videoRawImage

        // Reset data reference
        studentData = null; // Replace studentData
    }
}
