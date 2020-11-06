using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using System.Net;
public class CustomNetworkManager : NetworkManager
{
    string myIP = "189.213.87.113"; //localIP

    Texture2D qrCode;

    public RawImage qrImage;
    public RawImage qrCamera;

    public void ToggleQrCode()
    {
        qrImage.gameObject.SetActive(!qrImage.gameObject.activeSelf);
    }
    public void ToggleQrCamera()
    {
        qrCamera.gameObject.SetActive(!qrCamera.gameObject.activeSelf);
        if (qrCamera.gameObject.activeSelf)
        {
            camTexture.Play();
        }
        else
        {
            camTexture.Stop();
        }
    }
    public override void OnStartHost()
    {
        base.OnStartHost();
        var address = $"{myIP}:{networkPort}";
        Debug.LogWarning("Address: " + address);
        qrCode = generateQR(address);
        qrImage.texture = qrCode;
        if (!qrCode) Debug.LogWarning("qrCode is null");
    }


    void Start()
    {
        screenRect = new Rect(0, 0, Screen.width, Screen.height);
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = Screen.height;
        camTexture.requestedWidth = Screen.width;
        qrCamera.texture = camTexture;
    }

    void Update()
    {
        if (qrCamera.gameObject.activeSelf)
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            var result = barcodeReader.Decode(camTexture.GetPixels32(),
            camTexture.width, camTexture.height);
            if (result != null)
            {
                Debug.LogWarning("Decode result: " + result);
                try
                {
                    var address = result.ToString().Split(':'); // ej. 192.0.0.1:7777
                    networkAddress = address[0];
                    networkPort = int.Parse(address[1]);

                    ToggleQrCamera();
                }
                catch (Exception ex)
                {
                    Debug.LogError("result is in unexpected format");
                }
            }
        }
    }

    Rect screenRect;
    WebCamTexture camTexture;


    private static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }
    public Texture2D generateQR(string text)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = Encode(text, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        return encoded;
    }
}
