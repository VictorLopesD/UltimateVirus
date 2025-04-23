using UnityEngine;

public class BaseAtributos : MonoBehaviour
{
    public string nome;
    public int hpAtual;
    public int hpMax;
    public float speed;
    public int nivel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nivel = 1;
        GerarAtributos(5, 10);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GerarAtributos(int valorMin, int valorMax)
    {

        hpMax =  100 * Random.Range(valorMin, valorMax) * nivel;
        speed = 2 * Random.Range(valorMin,valorMax) * nivel;

    }

}
