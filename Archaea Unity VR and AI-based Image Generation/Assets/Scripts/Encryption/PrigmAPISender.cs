using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using UnityEngine.Rendering;

public class PrigmAPISender : MonoBehaviour
{
    private string apiKey = "d5b835f09ceb6068a1db073375ff6013e7c212afee1d4429cc430cac5b371ec7562890e5dc218403e9e7b63cef829c7b"; // Replace with your API key
    private string apiUrl = "192.168.1.138:8080/post";

    public TMP_InputField promptInput;
    public RawImage resultImage;
    public Texture2D tex;
    public RenderTexture renderTexture;


    public async Task SendRequestAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://clipdrop-api.co/text-to-image/v1");
        request.Headers.Add("x-api-key", "d5b835f09ceb6068a1db073375ff6013e7c212afee1d4429cc430cac5b371ec7562890e5dc218403e9e7b63cef829c7b");
        var content = new MultipartFormDataContent();
        content.Add(new StringContent(promptInput.text), "prompt");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        // API yanıtını bir byte dizisine dönüştürün
        byte[] imageData = await response.Content.ReadAsByteArrayAsync();
        Debug.Log("Length"+imageData.Length);
        Debug.Log("Byte Array: " + System.Text.Encoding.UTF8.GetString(imageData));

        File.WriteAllBytes("Assets/Resources/file2.png", imageData);

        Texture2D tex = new Texture2D(1024, 1024);
        tex.LoadImage(imageData);
        tex.Apply();
        //resultImage.texture = tex;
        //tex.Apply();
        //Graphics.Blit(tex, renderTexture);
        tex.LoadImage(imageData);
        resultImage.material.mainTexture = tex;
    }


    void LoadPNGImage(string path)
    {
        // Texture2D oluştur
        Texture2D tex = new Texture2D(1024, 1024);

        // PNG dosyasını yükle
        byte[] fileData = System.IO.File.ReadAllBytes(path);
        tex.LoadImage(fileData);

        // RawImage bileşenine atama yap
        resultImage.texture = tex;
    }

    public void SendRequest()
    {

        Task a = Task.Run(async () => { await SendRequestAsync(); });


    }
}
