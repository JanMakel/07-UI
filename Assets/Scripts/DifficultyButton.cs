using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty; //Dificultad (1- Facil, 2- Normal, 3- Dificil)
    private Button _button; 
    private GameManager gameManager;



    private void Awake()
    {
        //Asignacion de la componente Button a nuestra variable boton
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);//Llamada a la funcion cuando se seleccione una dificultad presionando un boton
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
