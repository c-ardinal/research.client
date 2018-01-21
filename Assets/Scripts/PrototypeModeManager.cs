using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class PrototypeModeManager : MonoBehaviour, IInputClickHandler
{
    public static bool mode = false;

    private Renderer meshRenderer = null;
    private Material defaultMaterial = null;
    [SerializeField] private Material selectedMaterial = null;


    public void Awake()
    {
        this.meshRenderer = this.GetComponent<Renderer>();
        this.defaultMaterial = this.meshRenderer.material;
    }


    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(mode == false)
        {
            mode = true;
            this.meshRenderer.material = this.defaultMaterial;
        }
        else
        {
            mode = false;
            this.meshRenderer.material = this.selectedMaterial;
        }
    }
}
