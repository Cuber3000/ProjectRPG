using UnityEngine;

public class NPC : MonoBehaviour, Interactable
{
    private string toolTip = "";

    private void Start()
    {
        toolTip = $"Press {KeyBinds.keys["Interact"].ToString()} to talk";
    }
    public void OnInteraction()
    {
        Debug.Log("Talk to NPC");
    }

    public string ToolTip()
    {
        return toolTip;
    }
}
