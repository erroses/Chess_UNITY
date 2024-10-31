using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Setting : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject prefab;

    public bool isPath = false;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        this.transform.localScale = new Vector2(0.4f, 0.4f);
    }

    // 이미지 클릭 시 호출되는 메서드
    private void OnMouseDown()
    {
        // Path 프리팹 제거
        gameManager.RemovePath();
        
        if(!isPath)
        {
            Vector3 newPosition = transform.position + new Vector3(0, gameManager.CellSize, 0);
            Instantiate(prefab, newPosition, Quaternion.identity, this.transform);
        }

        isPath = !isPath;
    }
}