using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string LevelToLoad;

    void LoadNiveau1()
    {
        SceneManager.LoadScene("Niveau1");
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            LoadLevel();
        }
    }
}
