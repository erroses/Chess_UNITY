using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Pawn : PieceSetting
{
    private float initPositionY;

    protected override void Start() // 'void' Ű���尡 ������ �ʵ��� ����
    {
        base.Start(); // �θ� Ŭ������ Start �޼��带 ȣ��
        initPositionY = this.transform.position.y; // ������ �ʱ�ȭ
    }

    // Ŭ�� �� ȣ��Ǵ� �޼���
    protected override void isPathOption()
    {
        base.isPathOption();

        if (!isPath)
        {
            if(transform.position.y == initPositionY)
            {
                Instantiate(Path, transform.position + new Vector3(0, 2 * gameManager.CellSize, 0), Quaternion.identity, spawnTransform);
            }
        }
    }
}