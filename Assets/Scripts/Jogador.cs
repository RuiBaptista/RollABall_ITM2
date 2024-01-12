using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Jogador : MonoBehaviour    
{
    [SerializeField]
    private float velocidade;
    [SerializeField]
    private TMP_Text pontuacao;
    [SerializeField]
    private TMP_Text vitoria;

    private int contador;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        vitoria.text = "";
        rb = GetComponent<Rigidbody>();
        contador = 0;
        Pontuacao();
    }

    private void FixedUpdate()
    {
        float moverNaHorizontal = Input.GetAxis("Horizontal");
        float moverNaVertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(moverNaHorizontal, 0.0f, moverNaVertical);

        rb.AddForce(movimento * velocidade);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coletavel"))
        {
            other.gameObject.SetActive(false);

            contador += 1;
            Pontuacao();
            Vitoria(contador);
          
        }
    }

    void Vitoria(int contador)
    {
        if (contador == 10)
        {
            //Vitória
            vitoria.text = "Parabens Ganhou!";
        }
    }

    private void Pontuacao()
    {
        pontuacao.text = "Contador: " + contador.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
