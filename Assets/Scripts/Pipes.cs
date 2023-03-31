using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    //di chuyển ống và xóa ống
    //tốc độ di chuyển
    public float speed = 5f;

    //khai báo biến vị trí dìa màn mình để xóa ống
    private float leftEdge;

    public void Start()
    {
        //lấy vị trí cam

        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; //-1 để bù đi phần rộng ống => đi qua mép màn hình mới xóa

    }


    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        //xóa đối tượng ống khi ra khỏi rìa màn hình
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
