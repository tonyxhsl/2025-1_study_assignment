using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager MyUIManager;

    public GameObject Character;
    public GameObject CamObj;
    
    const float CharacterSpeed = 3f;

    public int NowScore = 0;

    void Awake()
    {
        MyUIManager.DisplayScore(NowScore);
        MyUIManager.DisplayMessage("", 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    // For smooth cam moving, it's good to use LateUpdate.
    void LateUpdate()
    {
        MoveCam();
    }

    void MoveCam()
    {
        CamObj.transform.position = new Vector3(Character.transform.position.x, Character.transform.position.y, -10);
    }

    void MoveCharacter()
    {
        Character.transform.Translate(Vector3.right * CharacterSpeed * Time.deltaTime);
    }

    public void GameOver()
    {
        Destroy(Character);
        MyUIManager.DisplayMessage("Game Over!", 3f);
        MyUIManager.RestartButton.SetActive(true);
    }

    public void GetPoint(int point)
    {
        NowScore += point;
        MyUIManager.DisplayScore(NowScore);
    }

    // Restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
