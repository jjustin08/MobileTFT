using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotVisual : MonoBehaviour
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private MeshRenderer mesh;



    private void Update()
    {
        // this is not great
        ToggleSelect(false);
    }

    public void ToggleSelect(bool toggle)
    {
        if(toggle)
        {
            mesh.material = selectedMaterial;
        }
        else 
        {
            mesh.material = defaultMaterial;
        }
    }
}
