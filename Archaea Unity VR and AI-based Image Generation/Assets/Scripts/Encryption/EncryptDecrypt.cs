using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;

public class EncryptDecrypt : MonoBehaviour
{
    // Anahtar ve IV için sabit değerler (Örnek amaçlı, gerçek uygulamalarda rastgele ve güvenli değerler kullanılmalıdır)
    private static string anahtar = "BuBirAnahtar1234"; // 16 byte (128 bit)
    private static string iv = "BuBirIV987656789"; // 16 byte (128 bit)

    public TMP_InputField input;
    public TMP_InputField output;



    public void Encdec()
    {
        string metin = input.text;
        string sifrelenmisMetin = Sifrele(metin);
        Debug.Log("Şifrelenmiş Metin: " + sifrelenmisMetin);
        output.text = sifrelenmisMetin;
        string orjinalMetin = Coz(sifrelenmisMetin);
        Debug.Log("Çözülen Metin: " + orjinalMetin);
    }

    // Metni AES ile şifrelemek için kullanılır
    public static string Sifrele(string metin)
    {
        using (Aes aesAlg = Aes.Create())
        {
            byte[] a = Encoding.UTF8.GetBytes(anahtar);
            byte[] ivb = Encoding.UTF8.GetBytes(iv);
            Debug.Log(a.Length);
            Debug.Log(ivb.Length);
            aesAlg.Key = Encoding.UTF8.GetBytes(anahtar);
            Debug.Log(aesAlg.Key.Length);
            aesAlg.IV = Encoding.UTF8.GetBytes(iv);
            
            ICryptoTransform sifrelemeTransformu = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, sifrelemeTransformu, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(metin);
                    }
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    // Şifrelenmiş metni AES ile çözmek için kullanılır
    public static string Coz(string sifrelenmisMetin)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(anahtar);
            aesAlg.IV = Encoding.UTF8.GetBytes(iv);

            ICryptoTransform cozmeTransformu = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(sifrelenmisMetin)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, cozmeTransformu, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}
