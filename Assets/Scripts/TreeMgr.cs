using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMgr : MonoBehaviour
{
	private static TreeMgr _inst = null;

	public static TreeMgr inst
	{
		get
		{
			if (_inst == null)
			{
				_inst = FindObjectOfType<TreeMgr>();
			}
			return _inst;
		}
	}

	public List<Treee> AllTrees= new List<Treee>();

	public void Register(Treee treee)
	{

		AllTrees.Add(treee);

	}

	public void Unregister(Treee treee)
	{
		AllTrees.Remove(treee);
	}
}
