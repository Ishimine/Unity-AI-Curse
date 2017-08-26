using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour {




    public virtual Goal GetGoal()
    {
        return new Goal();
    }
}

