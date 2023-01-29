using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogo : MonoBehaviour
{
    [SerializeField] GameObject colectavel;
    [SerializeField] Transform[] coordenadas = new Transform[5];
    [SerializeField] Text mostrador;

    private int sorteado = 0;
    private bool contaTempo = true;

    public float temporiazador = 15f;
    public bool instanciar = true;
 
    void Update()
    {   
        ContadorTemporal();
        if (instanciar){
            instanciar = false;
            Invoke("InstanciaColectavel", Random.Range(1,3));
        }
    }

    void InstanciaColectavel(){
        sorteado = Sorteio(0,4);
        Instantiate(colectavel, coordenadas[sorteado].position, Quaternion.identity);
    }

    int Sorteio(int minimo, int maximo){
        Random.InitState((int)System.DateTime.Now.Ticks);
        return minimo + (sorteado - minimo + Random.Range(1, maximo - minimo)) % (maximo - minimo);
    }

    void ContadorTemporal(){
        MostraTempo(temporiazador);
        if (contaTempo){
            if(temporiazador > 0){
                temporiazador -= Time.deltaTime;
            }
            else{
                temporiazador = 0;
                contaTempo = false;
                Interface.gameover = true;
            }
        }
    }

    void MostraTempo(float relogio){
        float minutos = Mathf.FloorToInt(relogio / 60);
        float segundos = Mathf.FloorToInt(relogio % 60);

        mostrador.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
