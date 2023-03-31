using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prallax : MonoBehaviour
{

    //hiệu ứng thị sai
    //kĩ thuật tạo hiệu ứng xa gần cho backgroud và đối tượng

    //Khai báo
    private MeshRenderer meshRenderer;

    //khai báo tốc độ di chuyển của backgroud
    public float animationSpeed = 0.05f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }


    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
    //
}
