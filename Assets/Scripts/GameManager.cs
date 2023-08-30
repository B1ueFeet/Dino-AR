using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [SerializeField] private int jumpForce;
    [SerializeField] private int obstacleSpeed;
    [SerializeField] private int enviromentSpeed;
    [SerializeField] private bool startGame = false;
    [SerializeField] private bool pause;
    [SerializeField] private int score;
    [SerializeField] private int maxScore;

    public  int JumpForce { get { return jumpForce; } }
    public  int ObstacleSpeed { get { return obstacleSpeed; } set { obstacleSpeed = value; } }
    public  int EnviromentSpeed { get { return enviromentSpeed; } set{ enviromentSpeed = value; } }
    public  bool StartGame { get { return startGame; } set { startGame = value; } }
    public  bool Pause { get { return pause; } }
    public  int Score { get { return score; } set { score = value; } }
    public  int MaxScore { get { return maxScore; } set { maxScore = value; } }

    //CREAR EL SINGELTON
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance != null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(GameManager).Name;
                    _instance = go.AddComponent<GameManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return _instance;
        }
    }



    private void Awake()
    {
        var dontDestroy = FindObjectsOfType<GameManager>();
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void actualizarMaxScore()
    {
        if (this.maxScore < score)
        {
            maxScore = score;
        }
    }

    public void sumarPuntos()
    {
        score += 1;
    }
}
