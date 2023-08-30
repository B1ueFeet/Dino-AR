using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    private GameObject playButton;
    [SerializeField] private GameObject principal;
    [SerializeField] private GameObject creditos;
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
        principal.gameObject.SetActive(false);
        creditos.gameObject.SetActive(true);
    }

    public void Regresar()
    {
        principal.gameObject.SetActive(true);
        creditos.gameObject.SetActive(false);
    }

    public void ShowPlayButton()
    {
        playButton.SetActive(true);
    }



}
