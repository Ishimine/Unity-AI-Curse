using System.Collections;
using UnityEngine;

public class Actuator : MonoBehaviour {

    public virtual Camino GetPath(Goal goal)
    {
        return new Camino();
    }
    public virtual Direccion GetOutput(Camino path, Goal goal)
    {
        return new Direccion();
    }
}
