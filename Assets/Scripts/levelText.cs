using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class levelText : MonoBehaviour
{
    public TextMeshProUGUI tmpro;

    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        tmpro.text = sceneName;
    }
}
