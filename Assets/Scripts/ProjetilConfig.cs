using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjetilConfig : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidade = 5f;
    [SerializeField] private int quantidadeDano = 10;
    [SerializeField] private bool destruirAoColidir = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        rb.linearVelocity = transform.up * velocidade;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Busca o componente Vida diretamente no objeto colidido
        Vida componenteVida = collision.GetComponent<Vida>();

        // Se encontrar o componente Vida, aplica o dano
        if (componenteVida != null)
        {
            componenteVida.ReceberDano(quantidadeDano);

            // Destrói o objeto atual se for um projétil
            if (destruirAoColidir)
            {
                Destroy(gameObject);
            }
        }


    }

}
