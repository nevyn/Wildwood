
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public Button playButton;
  
    void Start()
    {
        playButton.onClick.AddListener(GameScene);
    


    }

    void GameScene()
    {

        SceneManager.LoadScene("GameScene");
    }

   


}
