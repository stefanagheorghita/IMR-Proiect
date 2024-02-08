using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InstructionsManager : MonoBehaviour
{
    public TMP_Text instructionsText;
    public KeyCode toggleKey = KeyCode.I;

    private bool isInstructionsVisible = true;
    private DinosaurInstructions dinosaurInstructions;

    public static InstructionsManager Instance { get; private set; }

    private string currentDinosaur = "stegosaurus";

    void Start()
    {
         if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        dinosaurInstructions = Resources.Load<DinosaurInstructions>("DinosaurInstructions");
        if (dinosaurInstructions == null)
        {
            Debug.LogError("DinosaurInstructions not found.");
        }
       
        UpdateInstructionsPanel();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(toggleKey))
        {
            isInstructionsVisible = !isInstructionsVisible;
            UpdateInstructionsPanel();
        }
    }

    public string GetCurrentDinosaur()
    {
        return currentDinosaur;
    }
     public void ChangeDinosaur(string newDinosaur)
    {
        currentDinosaur = newDinosaur;
        UpdateInstructionsPanel();
    }
    void UpdateInstructionsPanel()
    {
       
        instructionsText.gameObject.SetActive(isInstructionsVisible);
        
        if (isInstructionsVisible)
        {
           

            switch (currentDinosaur.ToLower())
            {
                case "stegosaurus":
                    instructionsText.text = dinosaurInstructions.stegosaurusInstructions;
                    break;
                case "tyrannosaurus":
                    instructionsText.text = dinosaurInstructions.tyrannosaurusInstructions;
                    break;
                case "pachy":
                    instructionsText.text = dinosaurInstructions.pachyInstructions;
                    break;
                case "raptor":
                    instructionsText.text = dinosaurInstructions.raptorInstructions;
                    break;
                case "diplodocus":
                    instructionsText.text = dinosaurInstructions.diplodocusInstructions;
                    break;
                case "pistosaur":
                    instructionsText.text = dinosaurInstructions.pistosaurInstructions;
                    break;
                default:
                    instructionsText.text = "You have collected all the dinosaurs! Find the hidden gems and have fun!";
                    break;
            }
        }
    }
}
