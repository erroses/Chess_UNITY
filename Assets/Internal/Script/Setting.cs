using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject prefab;

    private float ChessBoardSize; // 체스판 크기
    public float CellSize; // 한 칸 크기

    private bool isPath = false;


    void Start()
    {
        ChessBoardSize = spriteRenderer.bounds.size.x;
        CellSize = ChessBoardSize / 8;

        this.transform.position = new Vector2(CellSize / 2, CellSize / 2); // 칸 조정
        this.transform.localScale = new Vector2(0.4f, 0.4f);

        // 폰의 경우
        this.transform.Translate(0, -3 * CellSize, 0);
    }

    // 이미지 클릭 시 호출되는 메서드
    private void OnMouseDown()
    {
        // Path 프리팹 제거
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.CompareTag("Path"))
            {
                Destroy(obj);
            }
        }
        
        if(!isPath)
        {
            Vector3 newPosition = transform.position + new Vector3(0, CellSize, 0);
            Instantiate(prefab, newPosition, Quaternion.identity);
        }

        isPath = !isPath;
    }
}