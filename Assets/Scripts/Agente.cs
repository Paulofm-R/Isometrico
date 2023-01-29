using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente : MonoBehaviour
{   
    private UnityEngine.AI.NavMeshAgent agente;
    private Camera camera;

    void Start()
    {
    agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
    camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)){
            Ray raio = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit alvo;

            if ( (Physics.Raycast(raio, out alvo)))
            {
                agente.SetDestination(alvo.point);
            }
        }
    }
}
