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

public class StableDiffusionAPISender : MonoBehaviour
{
    private string apiKey = "-------"; // Replace with your API key
    private string apiUrl = "https://clipdrop-api.co/text-to-image/v1";

    public TMP_InputField promptInput;
    public RawImage resultImage;
  


    public async Task SendRequestAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://clipdrop-api.co/text-to-image/v1");
        request.Headers.Add("x-api-key", "------");
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

       
        Texture2D texture = ByteArrayToTexture2D(imageData);
        resultImage.texture = texture;
        texture.Apply();
    }

    public Texture2D ByteArrayToTexture2D(byte[] byteArray)
    {
        Texture2D texture = new Texture2D(2, 2);
        if (texture.LoadImage(byteArray))
        {
            return texture;
        }
        return null;
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
