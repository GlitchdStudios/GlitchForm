using UnityEngine;
using System.Collections;

public class DataSphereSlot : Utility
{
	private DataSphere dataSphereScr;
	private Transform dataSphereTrans;

	public GameObject areaPortal;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public override bool ToggleState() { isActive = (isActive == true) ? false : true; return isActive; }
	public override void CheckState(bool _isActive) {}

	public void ProcessData(DataState _dataState)
	{
		switch(_dataState)
		{
			case DataState.AREAPORTAL_DATA:
				areaPortal.SetActive(true);
			break;
		}
	}

	private void InitDataSpheres(DataSphere _dataSphereScr)
	{	
		dataSphereScr.initPos = this.collider.bounds.center;
	}

	public override bool IsActive { get { return isActive;} }

	//When receiving a triggerEnter from a DataSphere, Send data to the given slot.
	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "DataSphere")
		{
			dataSphereTrans = col.transform;
			dataSphereScr = col.GetComponent<DataSphere>();
			InitDataSpheres(dataSphereScr);
			ProcessData(dataSphereScr.GetDataState);
		}
	}

	void OnTriggerStay(Collider col)
	{
		if(col.tag == "DataSphere")
		{
			dataSphereTrans.position = this.collider.bounds.center;
		}
	}
}

