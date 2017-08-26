using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente_PlayerSimple : AgenteComportamiento
{
    Vector3 dir = Vector3.zero;




    public override Direccion GetDireccion()
    {
        dir = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            dir.z += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            dir.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            dir.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            dir.x += 1;
        }

        dir.Normalize();

        Direccion direccion = new Direccion();
        direccion.linear = dir*agente.acelMax;

        return direccion;
    }
}

