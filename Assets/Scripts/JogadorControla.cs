using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorControla : MonoBehaviour
{
    [SerializeField] float velocidade = 4f;
    Vector3 frontal, lateral;  // estamos a trabalhar com prespectiva isométrica, portanto iremos ter de ajustar as direções.
    [SerializeField] GameObject porta;

    Vector3 jogadorPosicaoOriginal;
    Quaternion jogadorOrientacaoOriginal;

    void Start()
    {
        frontal = transform.forward; // extraimos e guardamos a orientação do nosso jogador
        lateral = Quaternion.Euler(new Vector3(0, 90, 0)) * frontal;
        jogadorPosicaoOriginal = transform.position;
        jogadorOrientacaoOriginal = transform.rotation;
    }

    void Update()
    {   
        Vector3 horizontal = lateral * velocidade * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 vertical = frontal * velocidade * Time.deltaTime * Input.GetAxis("Vertical");
        
        Vector3 movimento = horizontal + vertical; // Somamos ambos os vectores
        transform.position += movimento;  // somamos à posição atual a nova posição
        transform.LookAt(transform.position + movimento); // o jogador orienta-se para a nova posição
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag("Respawn"))
        {   
            transform.position = jogadorPosicaoOriginal;
            transform.rotation = jogadorOrientacaoOriginal;

            porta.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Colectavel")){
            Destroy(other.gameObject);
            porta.SetActive(false);

            GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<Jogo>().temporiazador += 5f;
        }
    }

    private void OnCollisionEnter(Collision other){
         if (other.gameObject.CompareTag("Finish"))
        {   
            Interface.vitoria = true;
        }
    }
}