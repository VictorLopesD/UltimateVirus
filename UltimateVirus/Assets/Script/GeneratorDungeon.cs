using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GeneratorDungeon;

public class GeneratorDungeon : MonoBehaviour
{
    // Classe que representa um prefab de sala e define as entradas disponíveis
    [System.Serializable]
    public class SalasPrefab
    {
        public GameObject prefab; // Prefab da sala
        public bool[] entrada = new bool[4]; // Entradas: Norte, Sul, Leste, Oeste
    }

    [SerializeField] private SalasPrefab[] sala; // Lista de salas disponíveis para gerar
    [SerializeField] private int numSalas = 10; // Número total de salas a serem geradas
    [SerializeField] private List<Vector2> posicoesOcupadas = new List<Vector2>(); // Lista de posições já ocupadas
    [SerializeField] private Dictionary<Vector2, GameObject> salasInstanciadas = new Dictionary<Vector2, GameObject>(); // Mapeia posições para salas geradas
    [SerializeField] private Vector2[] direcoes = { new Vector2(0, 5), new Vector2(0, -5), new Vector2(-5, 0), new Vector2(5, 0) }; // Direções possíveis para a conexão entre salas
    [SerializeField] private List<GameObject> saidasOcupadas = new List<GameObject>(); // Lista de saídas ocupadas (portas)

    void Start()
    {
        GerarMasmorra(); // Inicia a geração da masmorra
    }

    public void GerarMasmorra()
    {
        Vector2 posiAtual = Vector2.zero; // Começa na posição (0,0)
        posicoesOcupadas.Add(posiAtual); // Adiciona a posição inicial à lista de ocupadas
        InstanciarSala(posiAtual); // Cria a primeira sala

        // Encontra e adiciona as saídas (portas) ao array
        for (int j = 0; j < numSalas; j++)
        {
            saidasOcupadas.Add(GameObject.Find("Saida_" + j)); // Busca no cenário os objetos de saída
            Debug.Log(saidasOcupadas[j]); // Exibe no console para depuração
        }

        // Gera o restante das salas conectadas
        for (int i = 0; i <= numSalas; i++)
        {
            Vector2 novaPosi = ObterPosicaoAdjacente(posiAtual); // Obtém uma posição vizinha aleatória
            if (!posicoesOcupadas.Contains(novaPosi)) // Verifica se a posição ainda não foi ocupada
            {
                posicoesOcupadas.Add(novaPosi); // Marca a posição como ocupada
                InstanciarSala(novaPosi); // Instancia uma nova sala nessa posição
                ConectarSalas(posiAtual, novaPosi); // Conecta a nova sala à anterior
                posiAtual = novaPosi; // Atualiza a posição atual
            }
        }
    }

    // Instancia uma nova sala na posição especificada
    void InstanciarSala(Vector2 pos)
    {
        SalasPrefab salaEscolhida = sala[Random.Range(0, sala.Length)]; // Escolhe um prefab de sala aleatório
        GameObject novaSala = Instantiate(salaEscolhida.prefab, pos * 10, Quaternion.identity); // Instancia a sala na posição correta
        novaSala.name = "Sala " + pos; // Nomeia a sala para facilitar a identificação
        salasInstanciadas[pos] = novaSala; // Adiciona ao dicionário de salas criadas
    }

    // Retorna uma posição vizinha aleatória para expandir a masmorra
    Vector2 ObterPosicaoAdjacente(Vector2 pos)
    {
        return pos + direcoes[Random.Range(0, direcoes.Length)];
    }

    // Conecta duas salas vizinhas removendo barreiras entre elas
    void ConectarSalas(Vector2 posAntiga, Vector2 posNova)
    {
        Vector2 direcao = posNova - posAntiga; // Determina a direção da nova sala em relação à anterior

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
