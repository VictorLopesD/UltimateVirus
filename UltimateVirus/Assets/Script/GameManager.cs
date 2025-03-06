using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameManager instance;
    TrocaCamera trocacamera;

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
