using UnityEngine;

[CreateAssetMenu(fileName = "DinosaurInstructions", menuName = "Instructions/DinosaurInstructions")]
public class DinosaurInstructions : ScriptableObject
{
    [TextArea(3, 10)]
    public string stegosaurusInstructions;

    [TextArea(3, 10)]
    public string tyrannosaurusInstructions;

    [TextArea(3, 10)]
    public string pachyInstructions;

    [TextArea(3, 10)]
    public string raptorInstructions;

}
