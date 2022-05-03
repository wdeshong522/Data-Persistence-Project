using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public string nameInput;
    public void SubmitName(string s)
    {
        SaveData.Instance.nameInput = s;
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
}
