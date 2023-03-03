using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System.Security.Cryptography;
using System.Text;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SystemInfo.deviceUniqueIdentifier);
        Debug.Log(Encrypt("123", "45621488631456644633443346324661"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static string Encrypt(string Text, string sKey)
    {
        byte[] keyArray = UTF8Encoding.UTF8.GetBytes(sKey);
        RijndaelManaged encryption = new RijndaelManaged();
        encryption.Key = keyArray;
        encryption.Mode = CipherMode.ECB;
        encryption.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = encryption.CreateEncryptor();
        byte[] _EncryptArray = UTF8Encoding.UTF8.GetBytes(Text);
        byte[] resultArray = cTransform.TransformFinalBlock(_EncryptArray, 0, _EncryptArray.Length);
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }
    
}
