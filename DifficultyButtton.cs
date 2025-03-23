
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;
    private GameManager gameManager;
    private Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button.onClick.AddListener(setDifficulty);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDifficulty()
    {
        
        gameManager.StartGame(difficulty);
    }
}
