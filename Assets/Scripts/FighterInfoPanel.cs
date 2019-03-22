using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FighterInfoPanel : MonoBehaviour
{
    public GameObject fighterPanel;

    RawImage fighterImage;

    RawImage flagImage;
    
    Text fighterText;


     void Awake() // Сработает при загрузке объекта к которому будет привязан
    {
        Transform panel = fighterPanel.transform.Find("Image_fighter"); // С Наследниками 2 ступени их поиск только через Transform !

        fighterImage = panel.GetComponent<RawImage>();

        Transform fighterFlag = fighterPanel.transform.Find("Flag");

        flagImage = fighterFlag.GetComponent<RawImage>();
        
        fighterText = fighterPanel.transform.Find("Text").GetComponent<Text>();
    }
    

    public string imagePath = "C:/Users/Максим/Desktop/PTF/Punch_to_Face_Convas_1/Assets/Fighters/31b770c0b75cd3b4f766e96b7857ed46.png"; //"C:/Users/Максим/Desktop/PTF/Punch_to_Face_Convas_1/Assets/Fighters";   //"https://cdn.vox-cdn.com/thumbor/-7HA2GJVif4JX4D238Hm-wUAAA0=/0x0:4392x2856/1200x800/filters:focal(1765x769:2467x1471)/cdn.vox-cdn.com/uploads/chorus_image/image/60725107/960223600.jpg.0.jpg"

    void Start()
    {
        StartCoroutine(GetTexture());
        StartCoroutine(GetText());
        StartCoroutine(GetFlag());
    }

    IEnumerator GetTexture() // UnityWebRequest, а не WWW(WWW устарел)
    {
        UnityWebRequest img = UnityWebRequestTexture.GetTexture(imagePath);
        
        yield return img.SendWebRequest();

        if (img.isNetworkError || img.isHttpError)
        {
            Debug.Log(img.error);
        }
        else
        {

            Texture2D texture = DownloadHandlerTexture.GetContent(img); 
            fighterImage.texture = texture;
        }
    }

    IEnumerator GetText()
    {
        UnityWebRequest txt = UnityWebRequest.Get("C:/Users/Максим/Desktop/PTF/Punch_to_Face_Convas_1/Assets/Text.txt");
        yield return txt.SendWebRequest();

        if (txt.isNetworkError || txt.isHttpError)
        {
            Debug.Log(txt.error);
        }
        else
        {
            fighterText.text = txt.downloadHandler.text; 
        }
    }
    IEnumerator GetFlag()
    {

        UnityWebRequest imgFlag = UnityWebRequestTexture.GetTexture("C:/Users/Максим/Desktop/PTF/Punch_to_Face_Convas_1/Assets/Image/dfd.png");
        yield return imgFlag.SendWebRequest();
        if (imgFlag.isNetworkError || imgFlag.isHttpError)
        {
            Debug.Log(imgFlag.error);
        }
        else
        {

            Texture2D texture = DownloadHandlerTexture.GetContent(imgFlag);
            flagImage.texture = texture;
        }
    }
}


