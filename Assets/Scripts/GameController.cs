using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject enviromentObject;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject Scann;
    [SerializeField] Animator animator;
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
        GameManager.Instance.StartGame = false;
        _mostrar = !_mostrar;
    }

    public void Iniciar()
    {
        HUD.SetActive(true);
        Scann.SetActive(false);
        animator.SetTrigger("start");
        GameManager.Instance.EnviromentSpeed = 1;
        GameManager.Instance.StartGame = true;
    }
}
