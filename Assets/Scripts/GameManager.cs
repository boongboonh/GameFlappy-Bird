using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    
    //điểm
    private int score;

    //cac đối tượng ui
    public Text scoreText;

    private void Awake()
    {
        //đặt tốc độ khung hình 60/s
        Application.targetFrameRate = 60;
    }


    private void Start()
    {
        Time.timeScale = 1;
        scoreText.enabled = false;
    }
    public void WaitStart() //bắt đầu lại game nếu người chơi tương tác(ấn, click) thì game mới chạy
    {
        //reset điểm
        score = 0;
        scoreText.text = score.ToString();

        //xóa ống
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
