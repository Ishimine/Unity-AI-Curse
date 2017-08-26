using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente_EvitarParedes : Agente_Buscar
{

    public float distanciaEvacion;
    public float rayDist;

    public override void Awake()
    {
        base.Awake();
        objetivo = new GameObject();
    }



    //Se dispara un rayo por delante del agente y cuando este choca con una pared la posicion objetivo es cambiada de lugar a una nueva posicion
    //tomando en cuenta la distancia de evacion con la pared
    public override Direccion GetDireccion()
    {
        Direccion direccion = new Direccion();
        Vector3 position = transform.position;
        Vector3 rayVector = agente.velocity.normalized * rayDist;
        Vector3 direction = rayVector; RaycastHit hit;
        if (Physics.Raycast(position, direction, out hit, rayDist))
        {
            position = hit.point + hit.normal * distanciaEvacion;
            objetivo.transform.position = position;
            direccion = base.GetDireccion();
        }
        return direccion;
    }
}
