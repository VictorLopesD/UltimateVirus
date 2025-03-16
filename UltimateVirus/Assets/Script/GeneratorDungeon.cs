using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GeneratorDungeon;

public class GeneratorDungeon : MonoBehaviour
{
    // Classe que representa um prefab de sala e define as entradas dispon�veis
    [System.Serializable]
    public class SalasPrefab
    {
        public GameObject prefab; // Prefab da sala
        public bool[] entrada = new bool[4]; // Entradas: Norte, Sul, Leste, Oeste
    }

    [SerializeField] private SalasPrefab[] sala; // Lista de salas dispon�veis para gerar
    [SerializeField] private int numSalas = 10; // N�mero total de salas a serem geradas
    [SerializeField] private List<Vector2> posicoesOcupadas = new List<Vector2>(); // Lista de posi��es j� ocupadas
    [SerializeField] private Dictionary<Vector2, GameObject> salasInstanciadas = new Dictionary<Vector2, GameObject>(); // Mapeia posi��es para salas geradas
    [SerializeField] private Vector2[] direcoes = { new Vector2(0, 5), new Vector2(0, -5), new Vector2(-5, 0), new Vector2(5, 0) }; // Dire��es poss�veis para a conex�o entre salas
    [SerializeField] private List<GameObject> saidasOcupadas = new List<GameObject>(); // Lista de sa�das ocupadas (portas)

    void Start()
    {
        GerarMasmorra(); // Inicia a gera��o da masmorra
    }

    public void GerarMasmorra()
    {
        Vector2 posiAtual = Vector2.zero; // Come�a na posi��o (0,0)
        posicoesOcupadas.Add(posiAtual); // Adiciona a posi��o inicial � lista de ocupadas
        InstanciarSala(posiAtual); // Cria a primeira sala

        // Encontra e adiciona as sa�das (portas) ao array
        for (int j = 0; j < numSalas; j++)
        {
            saidasOcupadas.Add(GameObject.Find("Saida_" + j)); // Busca no cen�rio os objetos de sa�da
            Debug.Log(saidasOcupadas[j]); // Exibe no console para depura��o
        }

        // Gera o restante das salas conectadas
        for (int i = 0; i <= numSalas; i++)
        {
            Vector2 novaPosi = ObterPosicaoAdjacente(posiAtual); // Obt�m uma posi��o vizinha aleat�ria
            if (!posicoesOcupadas.Contains(novaPosi)) // Verifica se a posi��o ainda n�o foi ocupada
            {
                posicoesOcupadas.Add(novaPosi); // Marca a posi��o como ocupada
                InstanciarSala(novaPosi); // Instancia uma nova sala nessa posi��o
                ConectarSalas(posiAtual, novaPosi); // Conecta a nova sala � anterior
                posiAtual = novaPosi; // Atualiza a posi��o atual
            }
        }
    }

    // Instancia uma nova sala na posi��o especificada
    void InstanciarSala(Vector2 pos)
    {
        SalasPrefab salaEscolhida = sala[Random.Range(0, sala.Length)]; // Escolhe um prefab de sala aleat�rio
        GameObject novaSala = Instantiate(salaEscolhida.prefab, pos * 10, Quaternion.identity); // Instancia a sala na posi��o correta
        novaSala.name = "Sala " + pos; // Nomeia a sala para facilitar a identifica��o
        salasInstanciadas[pos] = novaSala; // Adiciona ao dicion�rio de salas criadas
    }

    // Retorna uma posi��o vizinha aleat�ria para expandir a masmorra
    Vector2 ObterPosicaoAdjacente(Vector2 pos)
    {
        return pos + direcoes[Random.Range(0, direcoes.Length)];
    }

    // Conecta duas salas vizinhas removendo barreiras entre elas
    void ConectarSalas(Vector2 posAntiga, Vector2 posNova)
    {
        Vector2 direcao = posNova - posAntiga; // Determina a dire��o da nova sala em rela��o � anterior

        if (salasInstanciadas.ContainsKey(posAntiga) && salasInstanciadas.ContainsKey(posNova))
        {
            GameObject salaA = salasInstanciadas[posAntiga]; // Sala original
            GameObject salaB = salasInstanciadas[posNova]; // Sala nova

            // Remove barreiras entre salas adjacentes para conectar corretamente
            if (direcao == Vector2.up)
            {
                salaA.transform.Find("Saida_N").gameObject.SetActive(false);
                salaB.transform.Find("Saida_S").gameObject.SetActive(false);
            }
            else if (direcao == Vector2.down)
            {
                salaA.transform.Find("Saida_S").gameObject.SetActive(false); 
                salaB.transform.Find("Saida_N").gameObject.SetActive(false);
            }
            else if (direcao == Vector2.left)
            {
                salaA.transform.Find("Saida_O").gameObject.SetActive(false);
                salaB.transform.Find("Saida_L").gameObject.SetActive(false);
            }
            else if (direcao == Vector2.right)
            {
                salaA.transform.Find("Saida_L").gameObject.SetActive(false);
                salaB.transform.Find("Saida_O").gameObject.SetActive(false);
            }
        }
    }
}
