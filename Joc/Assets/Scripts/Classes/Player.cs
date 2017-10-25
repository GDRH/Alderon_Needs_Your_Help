using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A player's ship stats.
/// </summary>
public class Player :MonoBehaviour {

    public int Health { get; set; }
    public Vector3 Position { get; set; }
    public GameObject Object { get; set; }
    private void Start()
    {
        Health = 10;
        Position = this.transform.position;
        Object = this.gameObject;
    }
}
