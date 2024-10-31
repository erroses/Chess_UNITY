using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Pawn : PieceSetting
{
    private float initPositionY;

    protected override void Start() // 'void' 키워드가 빠지지 않도록 주의
    {
        base.Start(); // 부모 클래스의 Start 메서드를 호출
        initPositionY = this.transform.position.y; // 변수를 초기화
    }

    // 클릭 시 호출되는 메서드
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