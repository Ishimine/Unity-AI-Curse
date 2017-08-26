using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter_Perseguir : Agente_Perseguir {

        
    public Goal GetGoal()
    {
        Goal goal = new Goal();
        goal.position = base.GetDireccion().linear;
        goal.isPosition = true;
        return goal;
    }
}
