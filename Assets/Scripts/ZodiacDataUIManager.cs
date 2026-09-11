using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class ZodiacDataUIManager : MonoBehaviour
{
    public TMP_Text NameTMP;
    public TMP_Text DescriptionTMP;
    public RawImage SymbolRawImage;

    private ZodiacData zodiacData;

    public void LoadData(string json)
    {
        if (SymbolRawImage.texture != null)
            SymbolRawImage.texture = null;

        zodiacData = JsonUtility.FromJson<ZodiacData>(json);

        NameTMP.text = zodiacData.Name;
        DescriptionTMP.text = zodiacData.Description;

        StartCoroutine(LoadImage(zodiacData.Symbol));
    }

    IEnumerator LoadImage(string url)
    {
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(url);
        yield return req.SendWebRequest();

        if (req.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Image Load Error: " + req.error);
            yield break;
        }

        SymbolRawImage.texture = DownloadHandlerTexture.GetContent(req);
    }

    public void ClearUI()
    {
        NameTMP.text = "";
        DescriptionTMP.text = "";
        SymbolRawImage.texture = null;
        zodiacData = null;
    }
}
