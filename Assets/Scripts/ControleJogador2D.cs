using UnityEngine;

public class ControleJogador2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveHorizontal; // Esta variável é usada por toda a classe

    [Header("Configurações de Movimento")]
    public float velocidade = 5f;
    public float forcaPulo = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // CORREÇÃO: Removemos a palavra "float" daqui para atualizar a variável global da classe
        moveHorizontal = Input.GetAxis("Horizontal");

        // Pulo: Checa se a velocidade vertical está próxima de zero (personagem parado no chão)
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Agora o FixedUpdate consegue ler o valor correto atualizado pelo Update
        rb.linearVelocity = new Vector2(moveHorizontal * velocidade, rb.linearVelocity.y);
    }
}