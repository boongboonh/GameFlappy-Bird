using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject gameStartScreen;
    [SerializeField] private GameObject gameTutorialScreen;
    [SerializeField] private GameObject PauseButton;
    [SerializeField] private GameObject PlayerObject;
    [SerializeField] private Text Score;
    [SerializeField] private Text ScoreGameOver;
    [SerializeField] private Text ScoreBest;
    [SerializeField] private GameObject NewScore;
    [SerializeField] private GameObject Swaper;
    [SerializeField] private GameObject Trang;
    [SerializeField] private GameObject Dong;
    [SerializeField] private GameObject Bac;
    [SerializeField] private GameObject Vang;


    private int NumberPlay;
    private int BestScoreInt;

    public void Start()
    {
        PauseButton.SetActive(false);
    
    }
    public void Update()
    {
       
    }
    public void PlayGame()
    {
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
        gameStartScreen.SetActive(false);
        Score.enabled = true;
        Swaper.SetActive(true);
        PauseButton.SetActive(true);
    }
    public void Pause()
    {//chua xong

        PauseButton.SetActive(false);
        Time.timeScale = 0f;
        gameTutorialScreen.SetActive(true);
        gameStartScreen.SetActive(true);
    }

    

    public void GameOver()
    {

        int diem = int.Parse(Score.text);
        //chua xong
        
        PauseButton.SetActive(false);

        PlayerObject.SetActive(false);
        Score.enabled = false;
  
        

        //huy hiệu

        checkMedal();
        //diem

        ScoreGameOver.text =diem.ToString();

        if (checkBestScore())
        {
            ScoreBest.text= diem.ToString();
            NewScore.SetActive(true);
            PlayerPrefs.SetInt("BestScore", diem);
        }
        else
        {
            ScoreBest.text = PlayerPrefs.GetInt("BestScore").ToString();
        }

        gameOverScreen.SetActive(true);

        Time.timeScale = 0f;
    }


   

    private void checkMedal()
    {
        int diem = int.Parse(Score.text);

        if (diem <=1)
        {

        }else if (diem > 1 && diem <= 5)
        {
            Trang.SetActive(true);
        }else if(diem>5 && diem <= 10)
        {
            Dong.SetActive(true);
        }else if(diem>10 && diem <= 20)
        {
            Bac.SetActive(true);
        }else if (diem > 20)
        {
            Vang.SetActive(true);
        }

    }
    private bool checkBestScore()
    {
        int diem = int.Parse(Score.text);
        NumberPlay = PlayerPrefs.GetInt("FirstPlay");

        //lay diem
        if (NumberPlay == 0)
        {
            PlayerPrefs.SetInt("BestScore", 0);
            PlayerPrefs.SetInt("FirstPlay", -1);
        }
        else
        {
            BestScoreInt = PlayerPrefs.GetInt("BestScore");
        }

        //kiem tra diem
        if ( diem > BestScoreInt)
        {

            return true;
        }
        else
        {
            return false;
        }

    }

    public void LoadMenu()
    {
        //ok
        SceneManager.LoadScene("Menu");

    }

    public void ReplayGame()
    {
        //ok
        SceneManager.LoadScene("Game");
    }
}
