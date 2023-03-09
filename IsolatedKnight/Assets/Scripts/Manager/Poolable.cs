using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
	public bool IsUsing;


	public virtual void Spawn(Transform position)
	{
		// 이것을 상속받는 클래스가 생성될때 해야할 행동
	}
}