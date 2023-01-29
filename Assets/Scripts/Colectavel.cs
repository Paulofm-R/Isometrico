using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectavel : MonoBehaviour
{   
    [SerializeField] float duracao = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, duracao);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(10, 30, 45) * Time.deltaTime);
    }

    private void OnDestroy(){
        GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<Jogo>().instanciar = true;
    }
}
