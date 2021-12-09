using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene1 : MonoBehaviour
{
    public string LevelToLoad;

    void LoadNiveau2()
    {
        SceneManager.LoadScene("Niveau2");
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            LoadNiveau2();
        }
    }
}
