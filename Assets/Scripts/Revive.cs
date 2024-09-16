using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    public static Revive Instance;
    //private Player player;
    public int life;
    private bool revived;
    private void Awake()
    {
        //player = GetComponent<Player>();
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // public void RevivePlayer()
    // {
    //     revived = true;
    //     player.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
    // }
    public void GetARevive()
    {

    }
    private void Update()
    {
        //Debug.Log(life);
    }
}
