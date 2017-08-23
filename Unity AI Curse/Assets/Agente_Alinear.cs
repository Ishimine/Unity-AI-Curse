using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente_Alinear : AgenteComportamiento {

    public float radioObjetivo;
    public float radioBajaVel;
    public float timeToTarget = 0.1f;

    public override Direccion GetDireccion()
    {
        Direccion direccion = new Direccion();
        float objetivoOrientation = objetivo.GetComponent<Agente>().orientacion;
        float rotation = objetivoOrientation - agente.orientacion;
        rotation = MapToRange(rotation);
        float rotationSize = Mathf.Abs(rotation);
        if (rotationSize < radioObjetivo)
            return direccion;
        float objetivoRotation;
        if (rotationSize > radioBajaVel) objetivoRotation = agente.rotMax;
        else objetivoRotation = agente.rotMax * rotationSize / radioBajaVel; objetivoRotation *= rotation / rotationSize;
        direccion.angular = objetivoRotation - agente.rotacion;
        direccion.angular /= timeToTarget;
        float angularAccel = Mathf.Abs(direccion.angular); if (angularAccel > agente.acelAngularMax)
        {
            direccion.angular /= angularAccel; direccion.angular *= agente.acelAngularMax;
        }
        return direccion; }
}
    }
