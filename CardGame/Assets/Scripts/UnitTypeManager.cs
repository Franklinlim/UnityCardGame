using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTypeManager : MonoBehaviour
{
    public List<Unit> allUnitTypes = new List<Unit>();

    // Start is called before the first frame update
    void Start()
    {
        allUnitTypes.Add(new Unit("Swordman", 1, 1, 3, 1, AllEffects.None));
        allUnitTypes.Add(new Unit("Archer", 1, 1, 2, 2, AllEffects.None));
        allUnitTypes.Add(new Unit("Spearman", 2, 2, 3, 1, AllEffects.None));

        allUnitTypes.Add(new Unit("Mounted Swordman", 3, 2, 4, 1, AllEffects.Calvary));
        allUnitTypes.Add(new Unit("Mounted Archer", 3, 2, 3, 2, AllEffects.Calvary));
        allUnitTypes.Add(new Unit("Mounted Spearman", 4, 3, 4, 1, AllEffects.Calvary));

        allUnitTypes.Add(new Unit("Trebuchet", 3, 3, 4, 3, AllEffects.Trebuchet));
        allUnitTypes.Add(new Unit("Horse", 1, 0, 1, 0, AllEffects.Horse));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
