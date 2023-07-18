using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class QRCodeScanner : MonoBehaviour
{
    [SerializeField]
    private RawImage rawImageBG;
    [SerializeField]
    private AspectRatioFitter aspectRatioFitter;
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private RectTransform scanZone;

    private bool isCameraAwailable;
    private WebCamTexture camTexture;


    private void Start()
    {
        SetUpCamera();

    }


    private void Update()
    {
        UpdateCameraReader();
    }

    private void SetUpCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if(devices.Length == 0 )
        {
            isCameraAwailable = false;
            return;
        }

        for(int i = 0; i < devices.Length; i++)
        {
            if (devices[i].isFrontFacing==false)
            {
                camTexture = new WebCamTexture(devices[i].name, (int)scanZone.rect.width, (int)scanZone.rect.height);
            }
        }

        camTexture.Play();
        rawImageBG.texture = camTexture;
        isCameraAwailable = true;
    }


    public void Scan()
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(camTexture.GetPixels32(),camTexture.width,camTexture.height);
            if(result!=null)
            {
                text.text = result.Text;
            }
            else
            {
                text.text = "Fail to read QR";
            }
        }
        catch
        {
            text.text = "Fail";
        }
    }

    private void UpdateCameraReader()
    {
        if(isCameraAwailable==false)
        {
            return;
        }
        float ratio = (float)camTexture.width / (float) camTexture.height;
        aspectRatioFitter.aspectRatio = ratio;

        int orientation = -camTexture.videoRotationAngle;
        rawImageBG.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }

}
