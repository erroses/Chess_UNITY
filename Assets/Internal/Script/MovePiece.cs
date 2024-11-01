using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    private GameManager gameManager;
    private PieceSetting parentSetting;

    public GameObject checkRange;
    public GameObject trail;
    private Transform parentTransform;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        parentTransform = this.transform.parent;

        if (this.tag == "Path")
        {
            Instantiate(checkRange, this.transform.position, Quaternion.identity, this.transform);
        }
        else
        {
            parentTransform = parentTransform.parent;
        }
    }

    private void OnMouseDown()
    {
        // 흔적 지우기
        gameManager.RemoveTrail();

        // 움직인 흔적
        Instantiate(trail, parentTransform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity, parentTransform);
        Instantiate(trail, 2 * parentTransform.position - this.transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity, parentTransform);

        // 기물 이동
        parentTransform.position = this.transform.position;
        parentSetting = parentTransform.gameObject.GetComponent<PieceSetting>();
        parentSetting.isPath = false;

        // 길 지우기
        gameManager.RemovePath(this.transform);
    }
}
