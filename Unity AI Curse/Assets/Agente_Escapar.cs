using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente_Escapar : AgenteComportamiento
{
    public override Direccion GetDireccion()
    {
        Direccion direccion = new Direccion();
        direccion.linear = transform.position - objetivo.transform.position;
        direccion.linear.Normalize();
        direccion.linear = direccion.linear * agente.acelMax;
        return direccion;
    }
}

