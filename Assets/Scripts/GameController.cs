using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameController : MonoBehaviour
{


    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject enviromentObject;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject Scann;
    [SerializeField] Animator animator;
    [SerializeField] TMP_Text[] HUDText;
    [SerializeField] private float tiempoJugado;
    private bool _mostrar;

    private static GameController instance;

    public static GameController Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Mostrar()
    {
        playerObject.SetActive(true);
        enviromentObject.SetActive(true);
        GameManager.Instance.EnviromentSpeed = 0;
        GameManager.Instance.ObstacleSpeed = 0;
        GameManager.Instance.StartGame = false;
        GameManager.Instance.Score= 0;
        _mostrar = !_mostrar;
    }

    public void Iniciar()
    {
        HUD.SetActive(true);
        Scann.SetActive(false);
        animator.SetTrigger("start");
        GameManager.Instance.EnviromentSpeed = 1;
        GameManager.Instance.ObstacleSpeed = 1;
        GameManager.Instance.StartGame = true;
        //SoundManager.PlaySound(SoundManager.Sound.music);
    }

    private void Update()
    {
        if(GameManager.Instance.StartGame)tiempoJugado += Time.deltaTime;
        int minutos = Mathf.FloorToInt((tiempoJugado % 3600) / 60);
        int segundos = Mathf.FloorToInt(tiempoJugado % 60);
        HUDText[0].text = "Time: " + minutos.ToString("00") + ":" + segundos.ToString("00");
        GameManager.Instance.Score = segundos;
        HUDText[1].text = "Score: " + segundos.ToString("000000");
        HUDText[2].text = "HighScore: " + GameManager.Instance.MaxScore.ToString("000000");
    }


}
