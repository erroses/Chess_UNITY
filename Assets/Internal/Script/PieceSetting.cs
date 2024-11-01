using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 추상 클래스는 게임 매니저에 통합시켜야하나
public abstract class PieceSetting : MonoBehaviour
{
    protected GameManager gameManager;
    public GameObject checkRange;
    public GameObject Path;
    public GameObject attackMark;
    protected Transform spawnTransform;

    protected Dictionary<int, string> attackable;

    public bool isPath = false;
    public int isWhite;

    protected virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spawnTransform = this.transform;

        // 공격 가능한 기물
        attackable = new Dictionary<int ,string>()
        {
            { -1, "White" },
            { 1, "Black" },
        };

        if (this.tag != "Range")
        {
            this.transform.localScale = new Vector2(0.4f, 0.4f);
            Instantiate(checkRange, transform.position, Quaternion.identity, this.transform);
        }
        else
        {
            spawnTransform = spawnTransform.parent;
        }

        isWhite = spawnTransform.tag == "White" ? 1 : -1;
    }

    protected void OnMouseDown()
    {
        // Path 프리팹 제거
        gameManager.RemovePath(spawnTransform);

        if (!isPath)
        {
            isPathOption();
        }

        isPath = !isPath;
    }

    protected abstract void isPathOption();
}
