using UnityEngine;
using UnityEngine.UI;


public class UIButtonClickSound : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(PlayClickSound);
    }

    private void PlayClickSound()
    {
        if (UIAudioManager.Instance != null)
        {
            UIAudioManager.Instance.PlayClick();
        }
    }
}
