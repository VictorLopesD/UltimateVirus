using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject[] imagemMapa;
    public int valormapa;
    
     // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        valormapa = Random.Range(0, imagemMapa.Length - 1);
        Instantiate(imagemMapa[valormapa], this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
