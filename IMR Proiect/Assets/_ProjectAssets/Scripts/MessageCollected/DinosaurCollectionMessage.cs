using UnityEngine;

[CreateAssetMenu(fileName = "DinosaurCollectionMessage", menuName = "Custom/DinosaurCollectionMessage")]
public class DinosaurCollectionMessage : ScriptableObject
{


    [TextArea(3, 10)]
    public string stegosaurusInstructions = "Congratulations! You have collected a Stegosaurus!";

    [TextArea(3, 10)]
    public string tyrannosaurusInstructions = "Congratulations! You have collected a Tyrannosaurus!";

    [TextArea(3, 10)]
    public string pachyInstructions = "Congratulations! You have collected a Pachycephalosaurus!";

    [TextArea(3, 10)]
    public string raptorInstructions = "Congratulations! You have collected a Velociraptor!";
   
}

