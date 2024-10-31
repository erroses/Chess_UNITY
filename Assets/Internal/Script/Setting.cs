using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject prefab;

    private float ChessBoardSize; // ü���� ũ��
    public float CellSize; // �� ĭ ũ��

    private bool isPath = false;


    void Start()
    {
        ChessBoardSize = spriteRenderer.bounds.size.x;
        CellSize = ChessBoardSize / 8;

        this.transform.position = new Vector2(CellSize / 2, CellSize / 2); // ĭ ����
        this.transform.localScale = new Vector2(0.4f, 0.4f);

        // ���� ���
        this.transform.Translate(0, -3 * CellSize, 0);
    }

    // �̹��� Ŭ�� �� ȣ��Ǵ� �޼���
    private void OnMouseDown()
    {
        // Path ������ ����
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