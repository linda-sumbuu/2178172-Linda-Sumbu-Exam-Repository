using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public static bool PlayerWantsToQuit = false;

    public GameObject popUpUI;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PopUp();
        }
    }
    public void SceneChange(int level)

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);

    }

    public void PopUp()
    {
        popUpUI.gameObject.SetActive(true);
        Time.timeScale = 1f;
        PlayerWantsToQuit = true;
    }
}
