using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject[] Pieces = new GameObject[6];

    private float ChessBoardSize; // 체스판 크기
    public float CellSize; // 한 칸 크기

    // Start is called before the first frame update
    void Start()
    {
        ChessBoardSize = spriteRenderer.bounds.size.x;
        CellSize = ChessBoardSize / 8;

        Setting();
    }

    public void RemovePath(Transform parent)
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Path"))
        {
            if (obj.transform.parent != parent)
            {
                obj.transform.parent.GetComponent<PieceSetting>().isPath = false;
            }

            Destroy(obj);
        }
    }

    public void RemoveTrail()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Trail"))
        {
            Destroy(obj);
        }
    }

    private void Setting()
    {
        Vector3 newPosition = new Vector3(7 * CellSize / 2, -7 * CellSize / 2, 0) ; // 우측 하단 끝

        for (int i = 0; i < 8; i++) { //폰
            Instantiate(Pieces[0], newPosition + new Vector3(-i * CellSize, CellSize, 0), Quaternion.identity);
        }
    }
}
