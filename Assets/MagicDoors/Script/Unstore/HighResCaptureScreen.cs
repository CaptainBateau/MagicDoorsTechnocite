using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighResCaptureScreen  : MonoBehaviour
{
    public string m_relativePath = "InEditorCapture";

[ContextMenu("Take screen x8")]
public void CaptureScreenshotVeryVeryBig()
{
    CaptureScreenshot(8);
}
[ContextMenu("Take screen x4")]
public void CaptureScreenshotVeryBig()
{
    CaptureScreenshot(4);
}
[ContextMenu("Take screen x2")]
public void CaptureScreenshotBig()
{
    CaptureScreenshot(2);
}

public void CaptureScreenshot(int ratio = 1)
{
    string path = Directory.GetCurrentDirectory()
        +"/"+ m_relativePath
        + "/" + DateTime.Now.ToString("yyyy_MM_dd_h_mm_tt") + ".png";
    Directory.CreateDirectory(Path.GetDirectoryName(path));
    ScreenCapture.CaptureScreenshot(path, ratio);
}


}
