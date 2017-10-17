using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject Prefab;
    public Vector3 spawnPos1;
    public Vector3 spawnPos2;
    public Transform Player;
    public float Timer = 0.125f;
    public bool _SpawnAlt = false;
	// Use this for initialization
	void Start () {
        Player = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Timer < 0)
        {
            if (Input.GetButton("Fire1"))
            {
                Timer = 0.109375f;
                GameObject laser = Instantiate(Prefab, Vector3.zero, Player.rotation);
                laser.transform.SetParent(Player);
                if (_SpawnAlt == false)
                {
                    laser.transform.localPosition = spawnPos1;
                    _SpawnAlt = true;
                }
                else
                {
                    laser.transform.localPosition = spawnPos2;
                    _SpawnAlt = false;
                }
                laser.transform.SetParent(null);
            }
        }
        else
        {
            Timer -= Time.deltaTime;
        }
	}
}
