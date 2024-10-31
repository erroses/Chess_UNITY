using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceSetting : MonoBehaviour
{
    protected GameManager gameManager;
    public GameObject checkRange;
    public GameObject Path;
    protected Transform spawnTransform;

    public bool isPath = false;

    protected virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        spawnTransform = this.transform;

        if (this.tag != "Range")
        {
            this.transform.localScale = new Vector2(0.4f, 0.4f);
            Instantiate(checkRange, transform.position, Quaternion.identity, this.transform);
        }
        else
        {
            spawnTransform = spawnTransform.parent;
        }
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

    protected virtual void isPathOption()
    {
        Vector3 newPosition = spawnTransform.position + new Vector3(0, gameManager.CellSize, 0);
        Instantiate(Path, newPosition, Quaternion.identity, spawnTransform);
    }
}
