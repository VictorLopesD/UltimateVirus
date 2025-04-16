using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    TrocaCamera trocacamera;
    public int numRoom = 3;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject); 
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    void Start()
    {

       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
