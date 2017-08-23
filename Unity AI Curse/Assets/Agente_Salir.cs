using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente_Salir : AgenteComportamiento {
    public float radioEscape;
    public float radioPeligro;
    public float timeToTarget = 0.1f;

    public override Direccion GetDireccion()
    {
        //Calculamo velocidad Objetivo en relacion a la distancia
        Direccion direccion = new Direccion();
        Vector3 dir = transform.position - objetivo.transform.position;
        float distance = dir.magnitude;
        if (distance > radioPeligro) return direccion;
        float reduce; if (distance < radioEscape) reduce = 0f;
        else reduce = distance / radioPeligro * agente.velMax;
        float velObjetivo = agente.velMax - reduce;


        Vector3 desiredVelocity = dir;
        desiredVelocity.Normalize();
        desiredVelocity *= velObjetivo;
        direccion.linear = desiredVelocity - agente.velocity; direccion.linear /= timeToTarget;
        if (direccion.linear.magnitude > agente.acelMax)
        {
            direccion.linear.Normalize();
            direccion.linear *= agente.acelMax;
        }
        return direccion;
    }
}
