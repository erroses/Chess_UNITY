using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private float ChessBoardSize; // ü���� ũ��
    private float CellSize; // �� ĭ ũ��


    void Start()
    {
        ChessBoardSize = spriteRenderer.bounds.size.x;
        CellSize = ChessBoardSize / 8;

        this.transform.position = new Vector2(CellSize / 2, CellSize / 2); // ĭ ����
        this.transform.localScale = new Vector2(0.4f, 0.4f);

        // ���� ���
        this.transform.Translate(0, -3 * CellSize, 0);
    }
}
