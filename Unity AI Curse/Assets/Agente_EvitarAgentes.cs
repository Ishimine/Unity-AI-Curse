using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente_EvitarAgentes : AgenteComportamiento {

    public float radioDeColision = 0.4f;
    GameObject[] objetivos;


    void Start()
    {
        objetivos = GameObject.FindGameObjectsWithTag("Agente");
    }


    public override Direccion GetDireccion()
    {
        //Calcula Distancia y velocidades de los agentes cercanos
        Direccion steering = new Direccion();
        float shortestTime = Mathf.Infinity;
        GameObject firstTarget = null;
        float firstMinSeparation = 0.0f;
        float firstDistance = 0.0f;
        Vector3 firstRelativePos = Vector3.zero;
        Vector3 firstRelativeVel = Vector3.zero;

        //Busca al agente mas cercano por colisionar con el agente actual
        foreach (GameObject t in objetivos)
        {
            Vector3 relativePos; Agente targetAgent = t.GetComponent<Agente>();
            relativePos = t.transform.position - transform.position;
            Vector3 relativeVel = targetAgent.velocity - agente.velocity;
            float relativeSpeed = relativeVel.magnitude;
            float timeToCollision = Vector3.Dot(relativePos, relativeVel);
            timeToCollision /= relativeSpeed * relativeSpeed * -1;
            float distance = relativePos.magnitude;
            float minSeparation = distance - relativeSpeed * timeToCollision;
            if (minSeparation > 2 * radioDeColision) continue;
            if (timeToCollision > 0.0f && timeToCollision < shortestTime)
            {
                shortestTime = timeToCollision;
                firstTarget = t;
                firstMinSeparation = minSeparation;
                firstRelativePos = relativePos;
                firstRelativeVel = relativeVel;
            }
        }
        if (firstTarget == null)
            return steering;
        if (firstMinSeparation <= 0.0f || firstDistance < 2 * radioDeColision)
            firstRelativePos = firstTarget.transform.position;
        else firstRelativePos += firstRelativeVel * shortestTime;
        firstRelativePos.Normalize();
        steering.linear = -firstRelativePos * agente.velMax;
        return steering;
    }
}
