using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class QRGenerator : MonoBehaviour
{

    public RawImage rawImage;
    private string textEncode;
    private Texture2D texture2D;

    // Start is called before the first frame update
    void Start()
    {
        texture2D = new Texture2D(256,256);
        textEncode = GeneratedTicketManager.Instance.id;

    }

    private Color32[] Encode(string textForEncoding,int width,int height)
    {
        BarcodeWriter barcodeWriter = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Width = width,
                Height = height,
            }
        };
        return barcodeWriter.Write(textForEncoding);
    }

    public void onCLickEnable()
    {
        TextToQRcode();
    }

    public void TextToQRcode()
    {
        string text = string.IsNullOrEmpty(textEncode) ? "null" : textEncode;

        Color32[] convertPixeltoTexture = Encode(text, texture2D.width, texture2D.height);
        texture2D.SetPixels32(convertPixeltoTexture);
        texture2D.Apply();
        rawImage.texture = texture2D;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
