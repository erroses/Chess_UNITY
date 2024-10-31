using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private float ChessBoardSize; // 체스판 크기
    private float CellSize; // 한 칸 크기


    void Start()
    {
        ChessBoardSize = spriteRenderer.bounds.size.x;
        CellSize = ChessBoardSize / 8;

        this.transform.position = new Vector2(CellSize / 2, CellSize / 2); // 칸 조정
        this.transform.localScale = new Vector2(0.4f, 0.4f);

        // 폰의 경우
        this.transform.Translate(0, -3 * CellSize, 0);
    }
}
