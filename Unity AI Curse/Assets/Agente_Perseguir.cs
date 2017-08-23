using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente_Perseguir : Agente_Buscar
{
    public float prediccionMax;
    private GameObject objetivoAux;
    private Agente agenteObjetivo;


    public override void Awake()
    { base.Awake();
        agenteObjetivo = objetivo.GetComponent<Agente>();
        objetivoAux = objetivo;
        objetivo = new GameObject();
    }
    void OnDestroy()
    {
        Destroy(objetivoAux);
    }


    public override Direccion GetDireccion()
    { Vector3 direction = objetivoAux.transform.position - transform.position;
        float distance = direction.magnitude;
        float speed = agente.velocity.magnitude;
        float prediction;
        if (speed <= distance / prediccionMax)
            prediction = prediccionMax;
        else prediction = distance / speed;
        objetivo.transform.position = objetivoAux.transform.position;
        objetivo.transform.position += agenteObjetivo.velocity * prediction;
        return base.GetDireccion();
    }
}

