using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jello : MonoBehaviour
{
	public bool IsLevel2orMore = true;
    public KeyCode UpKey;
    public KeyCode DownKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;
	public KeyCode Jump;

	public Treee BeingHauled = null;

	public float MyTemp = 10.0f;
	public float tempDelta = 0f;

	public bool IsNextToFire = false;
	public bool IsNextToOther = false;
	public bool AmIFrozen = false;
	public bool AmIToasty = false;



	void Start()
    {
        JelloMgr.inst.Register(this);
    }

    void Update()
    {
		MovementLogic();
		TemperatureLogic();
		ChopTrees();

		if (BeingHauled !=null)
        {
			HaulTrees();
		}

		if (IsLevel2orMore)
        {
			StackJello();
        }

    }

	void MovementLogic()
	{

		Vector3 speed = Vector3.zero;

		if (Input.GetKey(UpKey))
		{
			speed.y = 1;

		}

		if (Input.GetKey(DownKey))
		{
			speed.y = -1;

		}

		if (Input.GetKey(LeftKey))
		{
			speed.x = -1;

		}

		if (Input.GetKey(RightKey))
		{
			speed.x = 1;

		}

		if (Input.GetKey(Jump))
		{
			speed.y = 10;

		}

		transform.position = transform.position + speed * Time.deltaTime;
	}

	void ChopTrees()
	{
		if (BeingHauled != null)
		{
			return;
		}

		foreach (Treee treee in TreeMgr.inst.AllTrees)
		{
			Vector3 toTreee = treee.transform.position - transform.position;
			float distance = toTreee.magnitude;

			if (distance <= 1.5f)
			{
				treee.GetChopped();
				BeingHauled = treee;
			}
		}
	}

	void HaulTrees()
	{
		Vector3 toWood = BeingHauled.transform.position - transform.position;

		float distance = toWood.magnitude;
		float followDistance = 1.25f;

		if (distance > followDistance)
		{
			Vector3 toWood2 = ((toWood * followDistance) / distance);
			Vector3 woodPos2 = transform.position + toWood2;
			BeingHauled.transform.position = woodPos2;
			PutWoodInFire();
		}
	}

	void PutWoodInFire()
	{
		Vector3 toFire = Fire.inst.transform.position - transform.position;

		float distanceToFire = toFire.magnitude;

		if (distanceToFire <= 1.25f)
		{
			Fire.inst.ReceiveWood(BeingHauled);
			BeingHauled = null;
		}
	}

	void StackJello()
    {
		
    }

	void TemperatureLogic()
    {
		tempDelta = 0;
		float maxTemp = 8f;

		Vector3 toFire = Fire.inst.transform.position - transform.position;
		float distanceToFire = toFire.magnitude;

		if (distanceToFire < 3)
		{
			IsNextToFire = true;
		}
		else
		{
			IsNextToFire = false;
		}

		IsNextToOther = false;

		foreach (Jello jello in JelloMgr.inst.AllJellos)
		{
			if (jello != this)
			{
				Vector3 toJello = jello.transform.position - transform.position;
				float distance = toJello.magnitude;
				if (distance <= 2.25f)
				{
					IsNextToOther = true;
				}
			}
		}

		Debug.Log("Is next to other?");
		Debug.Log(IsNextToOther);
		Debug.Log("Is Next to FIREEEEEEE?");
		Debug.Log(IsNextToFire);
	}







}
