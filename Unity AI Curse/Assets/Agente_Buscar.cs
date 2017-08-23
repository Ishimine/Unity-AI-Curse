using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agente_Buscar : AgenteComportamiento {
    public override Direccion GetDireccion()
    {
        Direccion direccion = new Direccion();
        direccion.linear = objetivo.transform.position - transform.position;
        direccion.linear.Normalize();
        direccion.linear = direccion.linear * agente.acelMax;
        return direccion;
    }
}
