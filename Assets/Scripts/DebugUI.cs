using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour
{

    private bool isActive = false;

    [SerializeField]
    private GameObject debugPanel;

    public void OnClickDebugButton()
    {
        isActive = !isActive;
        debugPanel.SetActive(isActive);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
