using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public string nome;
    public float hpAtual;
    public float hpMax;
    public float speed;
    public int nivel;

    BaseAtributos atributos;

    private void Awake()
    {
        atributos = FindAnyObjectByType<BaseAtributos>();
        atributos.GerarAtributos(4, 10);
        hpAtual = atributos.hpMax;
    }
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
