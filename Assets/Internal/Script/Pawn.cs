using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Pawn : PieceSetting
{
    // 문제 1. 폰이 뒤로가게 되는 문제
    // 문제 2. 껐다 켰다가 바로 실행이 안됨


    private float initPositionY;

    protected override void Start()
    {
        base.Start(); // 부모 클래스의 Start 메서드를 호출
        initPositionY = this.transform.position.y; // 변수를 초기화
    }

    // 클릭 시 호출되는 메서드
    protected override void isPathOption()
    {
        Vector3 newPosition = spawnTransform.position + new Vector3(0, gameManager.CellSize * isWhite, 0);
        Collider2D collider = Physics2D.OverlapPoint(newPosition);

        // 앞에 기물 있는지 확인
        if (collider == null)
        {
            Instantiate(Path, newPosition, Quaternion.identity, spawnTransform);

            if (transform.position.y == initPositionY)
            {
                newPosition += new Vector3(0, gameManager.CellSize * isWhite, 0);
                collider = Physics2D.OverlapPoint(newPosition);

                if (collider == null)
                {
                    Instantiate(Path, newPosition, Quaternion.identity, spawnTransform);
                }
            }
        }

        Attack();
    }

    private void Attack()
    {
        for (int i = -1; i <= 1; i+=2)
        {
            Vector3 newPosition = spawnTransform.position + new Vector3(i * gameManager.CellSize, gameManager.CellSize * isWhite, 0);
            Collider2D collider = Physics2D.OverlapPoint(newPosition);

            if(collider != null && (collider.tag == attackable[isWhite] || collider.transform.parent.tag == attackable[isWhite]))
            {
                Instantiate(attackMark, newPosition, Quaternion.identity, spawnTransform);
            }
        }
    }
}