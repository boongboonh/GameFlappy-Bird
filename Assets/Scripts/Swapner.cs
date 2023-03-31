using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swapner : MonoBehaviour
{
    //sinh ống ngẫu nhiên

    public GameObject prefab;

    //thời gian sinh(giây)
    public float spawnRate = 1.3f;

    //giới hạn dao động ống sinh ra
    public float minHeight = -1.5f;
    public float maxHeight = 3f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    private void Spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position,Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);

    }

    //hủy sinh ống
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

}
