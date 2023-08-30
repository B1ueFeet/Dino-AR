using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private GameObject playButton;
    public void GameInit()
    {
        UIManager.Instance.ChangeScene("Game");
    }
    public void Restart()
    {

    }
    public void Play()
    {
        GameController.Instance.Iniciar();
    }

    public void Pause()
    {

    }

    public void Credits()
    {

    }

    public void ShowPlayButton()
    {
        playButton.SetActive(true);
    }



}
