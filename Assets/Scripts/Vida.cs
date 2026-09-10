using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    [Header("Configurações de Vida")]
    [SerializeField] private int vidaMaxima = 100;
    private int vidaAtual;
    public TextMeshProUGUI textoVidaAtual;

    public SpriteRenderer spriteRenderer;
    public Color corDano = Color.red;
    public float duracaoFlash = 0.15f;

    private Color corOriginal;
    private float timerFlash;
    private bool piscando;





    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        corOriginal = spriteRenderer.color;
        
        vidaAtual = vidaMaxima;
        textoVidaAtual.text = ($"VIDA RESTANTE {vidaAtual}");

    }

    private void Update()
    {
        if (piscando)
        {
            timerFlash += Time.deltaTime;

            if (timerFlash >= duracaoFlash)
            {
                spriteRenderer.color = corOriginal; // Volta a cor normal
                piscando = false;
            }
        }
    }




    public void ReceberDano(int quantidadeDano)
    {
        
        vidaAtual -= quantidadeDano;
        Debug.Log($"{gameObject.name} recebeu {quantidadeDano} de dano! Vida restante: {vidaAtual}");
        textoVidaAtual.text = ($"VIDA RESTANTE {vidaAtual}");
        if (vidaAtual <= 0)
        {
            vidaAtual = 0;
            Morrer();
        }
        spriteRenderer.color = corDano;
        timerFlash = 0f;
        piscando = true;




    }

    private void Morrer()
    {
        Debug.Log($"{gameObject.name} morreu!");

        
        gameObject.SetActive(false);
        SceneManager.LoadScene("GamePlay");

    }

}