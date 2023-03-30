using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
	public bool IsUsing;

    /// <summary>
    /// 스폰시킬위치
    /// </summary>
    /// <param name="spawnTransform"> 스폰되는 위치</param>
    public virtual void Spawn(Transform spawnTransform)
	{
		// 이것을 상속받는 클래스가 생성될때 해야할 행동
	}

	public virtual void DamageTextSpawn(int damage,Transform spawnTransform)
	{

	}

	public virtual void BossSpawn(Transform spawnTransform,BossType bossType)
	{

	}

	public virtual void ExTextSpawn(string text,Transform spawnTransform)
	{

	}
}