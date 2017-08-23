using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente_Llegar : AgenteComportamiento
{

    public float radioObjetivo;
    public float radioBajaVel;
    public float timeToTarget = 0.1f;

    public override Direccion GetDireccion()
    {
        //Calculamo velocidad Objetivo en relacion a la distancia
        Direccion direccion = new Direccion();
        Vector3 dir = objetivo.transform.position - transform.position;
        float distance = dir.magnitude;
        float velObjetivo; if (distance < radioObjetivo)
            return direccion;
        if (distance > radioBajaVel) velObjetivo = agente.velMax;
        else velObjetivo = agente.velMax * distance / radioBajaVel;


        Vector3 desiredVelocity = dir; desiredVelocity.Normalize();
        desiredVelocity *= velObjetivo;
        direccion.linear = desiredVelocity - agente.velocity; direccion.linear /= timeToTarget;
        if (direccion.linear.magnitude > agente.acelMax) { direccion.linear.Normalize();
            direccion.linear *= agente.acelMax; }
        return direccion;
    }
}
