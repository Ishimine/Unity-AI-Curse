using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camino_Seguidor : Agente_Buscar
{
    public Camino path;
    public float desplazamientoCamino = 0.0f;
    float currentParam;


    public override void Awake()
    {
        base.Awake();
        objetivo = new GameObject();
        currentParam = 0f;
    }


    public override Direccion GetDireccion()
    {
        currentParam = path.GetParam(transform.position, currentParam);
        float targetParam = currentParam + desplazamientoCamino;
        objetivo.transform.position = path.GetPosition(targetParam);
        return base.GetDireccion();
    }


  
}

