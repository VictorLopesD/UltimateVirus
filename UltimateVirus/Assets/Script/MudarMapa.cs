using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudarMapa : MonoBehaviour
{
    [System.Serializable]
    public class SalasPrefab
    {
        public GameObject prefab;
        public List<Transform> saidasOcupadas = new List<Transform>();
        
        
    }

    public SalasPrefab[] salas;
    [SerializeField] private Dictionary<Vector2, GameObject> salasInstanciadas = new Dictionary<Vector2, GameObject>();
    public int qntSalas = 5;
    [SerializeField] private Vector2[] direcoes = { new Vector2(0, 5), new Vector2(0, -5), new Vector2(-5, 0), new Vector2(5, 0) }; // Direções possíveis para a conexão entre salas
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector2 ObterPosicaoAdjacente(Vector2 pos)
    {
        return pos + direcoes[Random.Range(0, direcoes.Length)];
    }

    public void GerarSalas()
    {
        Vector2 posiatual = Vector2.zero;
        for (int i = 0; i < qntSalas; i++)
        {
            InstanciarSala(posiatual);
        }
    }

    void InstanciarSala(Vector2 pos)
    {
        SalasPrefab salaEscolhida = salas[Random.Range(0, salas.Length)];
        GameObject novaSala = Instantiate(salaEscolhida.prefab, pos * 30, Quaternion.identity);
        novaSala.name = "Sala " + pos;
        salasInstanciadas[pos] = novaSala;
    }



}
