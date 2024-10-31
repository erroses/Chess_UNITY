using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    private GameManager gameManager;
    private Setting parentSetting;

    public GameObject prefab;
    private Transform parentTransform;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        parentTransform = this.transform.parent;

        if (this.tag == "Path")
        {
            Instantiate(prefab, this.transform.position, Quaternion.identity, this.transform);
        }
        else
        {
            parentTransform = parentTransform.parent;
        }
    }

    private void OnMouseDown()
    {
        parentTransform.position = this.transform.position;
        parentSetting = parentTransform.gameObject.GetComponent<Setting>();
        parentSetting.isPath = false;

        gameManager.RemovePath(this.transform);
    }
}
