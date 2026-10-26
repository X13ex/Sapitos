using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Setas : MonoBehaviour, IPointerClickHandler
{
    [Header("Cenários desta seta (objetos da cena)")]
    [SerializeField] private List<GameObject> cenarios;

    [Header("Outros cenários para esconder no início (opcional)")]
    [SerializeField] private List<GameObject> outrosParaEsconder;

    // Compartilhado entre todas as setas: guarda o cenário que está visível
    private static GameObject cenarioAtual;

    private void Awake()
    {
        // Reseta ao iniciar (evita guardar referência de uma partida anterior)
        cenarioAtual = null;

        EsconderLista(cenarios);
        EsconderLista(outrosParaEsconder);
    }

    private void EsconderLista(List<GameObject> lista)
    {
        if (lista == null) return;

        foreach (GameObject cenario in lista)
        {
            if (cenario != null)
                cenario.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
         Debug.Log("Clique recebido em: " + gameObject.name);
        if (cenarios == null || cenarios.Count == 0)
        {
            Debug.LogWarning($"Seta '{gameObject.tag}' está sem cenários.");
            return;
        }

        GameObject sorteado = cenarios[Random.Range(0, cenarios.Count)];

        if (cenarioAtual != null)
            cenarioAtual.SetActive(false);

        sorteado.SetActive(true);
        cenarioAtual = sorteado;

        Debug.Log($"Seta '{gameObject.tag}' → {sorteado.name}");
    }
}