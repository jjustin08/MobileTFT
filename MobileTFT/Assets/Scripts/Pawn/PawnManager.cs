using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PawnManager : MonoBehaviour
{
    [SerializeField] private TypesCountUI typesCountUI;
    //have all friendly pawns
    private List<Pawn> pawnList = new List<Pawn>();
    // have count of all types
    private List<Type> types = new List<Type>();
    private List<int> typeCount = new List<int>();
    // only update stats outside of combat
    private bool inCombat = false;


    private void Start()
    {
        foreach (Slot slot in GridUtil.Instance.GetOneSideOfSlots(true))
        {
            slot.OnPawnChange += Slot_OnPawnChange;
        }
    }

    private void Slot_OnPawnChange(object sender, System.EventArgs e)
    {
        if(inCombat)
        { return; }

        UpdatePawns();
    }
    public void UpdatePawns()
    {
        typesCountUI.UpdateUI();
        GridUtil.Instance.UpdateMaxPawnsOnBoard();


        //count all friendly pawns
        pawnList.Clear();
        foreach (Pawn p in GridUtil.Instance.GetAllPawns(true))
        {
            pawnList.Add(p);
        }
        //count types
        CountTypes();

        //calculate stats
        foreach (Pawn p in pawnList)
        {
            p.GetStats().CalculateStats(true);
        }
    }

    private void CountTypes()
    {
        // temp fix required visual to be same
        List<GameObject> countedPawns = new List<GameObject>();
        types.Clear();
        typeCount.Clear();
        foreach (Pawn p in pawnList)
        {
            
            if(countedPawns.Contains(p.GetPawnSO().placedVisual))
            {
                continue;
            }

            countedPawns.Add(p.GetPawnSO().placedVisual);

            foreach (Type t in p.GetPawnSO().types)
            {
                if (!types.Contains(t))
                {
                    types.Add(t);
                    typeCount.Add(1);
                }
                else
                {
                    int index = types.IndexOf(t);
                    typeCount[index] += 1;
                }
            }
        }
    }


    public void ToggleCombat(bool toggle)
    {
        //disable counting of pawns
        inCombat = toggle;
    }


    public bool InCombat { get { return inCombat;} }
}
