using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //khai báo trạng thái
    private State state;
    private enum State
    {
        waiting,
        play,
        die
    }

    //Khai báo hướng chuyển động
    private Vector3 direction;

    //lực nhảy
    private const float JUMP_STRENGTH = 7f;
    private Rigidbody2D birdRigidbody2D;


    //âm thanh
    public AudioSource soud_Point;
    public AudioSource soud_Fly;
    public AudioSource soud_Die;

    private void Awake()
    {
     
        birdRigidbody2D = GetComponent<Rigidbody2D>();

        birdRigidbody2D.bodyType = RigidbodyType2D.Static;
        //gọi sự kiện chờ
        state = State.waiting;
    }

    //đặt lại vị trí mỗi khi chơi lại
    private void OnEnable()
    {

        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;

        //đưa vận tốc trở về 0 sau khi replay
        birdRigidbody2D.Sleep();
    }

    void Update()
    {
        
        switch (state)
        {
            case State.waiting:
                //sự kiện đợi

                transform.localEulerAngles = Vector3.forward * birdRigidbody2D.velocity.y * 5f;
                //sự kiện bàn phím và chuột
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    //nếu click thì cho phép jump
                    state = State.play;
                    birdRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                    jump();

                }
                //sự kiện chạm màn hình cảm ứng

                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        //nếu click thì cho phép jump
                        state = State.play;
                        birdRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                        jump();
                    }
                }
                break;
            case State.play:

                transform.localEulerAngles = Vector3.forward * birdRigidbody2D.velocity.y * 5f;
                //sự kiện bàn phím và chuột
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    jump();

                }
                //sự kiện chạm màn hình cảm ứng

                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        jump();
                    }
                }
                break;
            case State.die:

                break;
            default:
                break;
        }

    }

    //bắt lỗi va chạm
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {

            soud_Die.Play();

            //nếu player chạm thẻ obstacle-vật cản => thực hiện hàm game over
            FindObjectOfType<MenuGame>().GameOver();

        }else if (collision.gameObject.tag == "Scoring")
        {


            soud_Point.Play();
            //nếu player chạm thẻ scoring => thực hiện hàm cộng điểm
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
    private void jump()
    {
        birdRigidbody2D.velocity = Vector3.up * JUMP_STRENGTH;
        soud_Fly.Play();

    }
}
