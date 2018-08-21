﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaptureViewController : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject selectPanel;

    private static Texture2D _photoTexture;
    public static Texture2D PhotoTexture
    {
        get { return _photoTexture; }
    }

    public void CaptureTapped()
    {
        StartCoroutine("CaptureTappedCoroutine");
    }

    private IEnumerator CaptureTappedCoroutine()
    {
        button.SetActive(false);

        yield return new WaitForEndOfFrame();

        _photoTexture = new Texture2D(Screen.width, Screen.height);
        _photoTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        _photoTexture.Apply();

        yield return new WaitForEndOfFrame();

        NextToScene();
    }

    public void SelectTapped()
    {
        selectPanel.SetActive(true);
    }

    public void CloseSelectPanel()
    {
        selectPanel.SetActive(false);
    }

    public void NextToScene()
    {
        SceneManager.LoadScene("SaveViewScene");
    }
}
