using UnityEngine;
using System.Collections;

public class MachineGun : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject[] clone;
	
	public int lastBullet;
	
    private Transform thisTransform;
	
	private bool locked;

    void Awake()
    {
		WeaponManager.Instance.SetWeaponStats(gameObject);
        clone = new GameObject[WeaponManager.Instance.Ammo];
        thisTransform = transform;
		lastBullet = 0;
        InstantiateProjectiles();
    }

    // Update is called once per frame
    void Update ()
    {
        if(Input.GetKey(KeyCode.Space))
        {   
            if(IsInputLocked()){}

            else
            {
				SetNextBullet();
                ActivateProjectiles();
                Lock();
            }
        }
    }


    private void InstantiateProjectiles()
    {
        for(int i = 0; i < clone.Length; i++)
        {
            clone[i] = (Instantiate(projectilePrefab, thisTransform.position, thisTransform.rotation) as GameObject);
            clone[i].SetActive(false);
        }

    }

    private void ActivateProjectiles()
	{
        if(clone[GetNextBullet()].activeSelf == false)
        {
			//clone[GetLastBullet()].rigidbody.velocity.Set(Vector3.zero);  //Use if isKinematic causes problems
            clone[GetNextBullet()].SetActive(true);
            clone[GetNextBullet()].GetComponent<Bullet>().Activate();
            clone[GetNextBullet()].transform.position = thisTransform.position;
        }   
    }

    private void Lock()
    {
        locked = true;

        Invoke("Unlock", WeaponManager.Instance.RoF);
    }

    private void Unlock()
    {
        locked = false;
    }

    private bool IsInputLocked()
    {
        return locked;
    }	
	
	private void SetNextBullet()
	{
		lastBullet += 1;
        if(lastBullet >= WeaponManager.Instance.Ammo -1)
        {
            lastBullet = 0;//reset the loop
        }

       // Debug.Log("LastBullet = " + lastBullet);
	}
	
    private int GetNextBullet()
    {
        return lastBullet;
    }
}


