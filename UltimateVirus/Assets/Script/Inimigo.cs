using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public string nome;
    public float hpAtual;
    public float hpMax;
    public float speed;
    public int nivel;
    public int dano;

    BaseAtributos atributos;

    private void Awake()
    {
        
    }
    void Start()
    {

        atributos = FindAnyObjectByType<BaseAtributos>();
        //atributos.GerarAtributos(4, 10);
        hpAtual = atributos.hpMax;
        speed = atributos.speed;
        nivel = atributos.nivel;
        dano = atributos.dano;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
