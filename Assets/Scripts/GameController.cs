using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject enviromentObject;
    private bool _mostrar;
    public void Mostrar()
    {
            playerObject.SetActive(true);
            enviromentObject.SetActive(true);
        _mostrar = !_mostrar;
    }

    public void Ocultar()
    {
    _mostrar = !_mostrar;
    playerObject.SetActive(false);
    enviromentObject.SetActive(false);
}
}
