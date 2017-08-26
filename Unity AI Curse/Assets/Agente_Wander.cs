using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente_Wander : Agente_Encarar
{

    public float desplazamiento;
    public float radio;
    public float ratio;


    public override Direccion GetDireccion()
    {
        Direccion steering = new Direccion();
        float wanderOrientation = Random.Range(-1.0f, 1.0f) * ratio;
        float targetOrientation = wanderOrientation + agente.orientacion;
        Vector3 orientationVec = GetOriAsVec(agente.orientacion);

        Vector3 targetPosition = (desplazamiento * orientationVec) + transform.position;
        targetPosition = targetPosition + (GetOriAsVec(targetOrientation) * radio);
        objetivoAux.transform.position = targetPosition; steering = base.GetDireccion();
        steering.linear = objetivoAux.transform.position - transform.position;
        steering.linear.Normalize(); steering.linear *= agente.acelMax;
        return steering;
    }


}

