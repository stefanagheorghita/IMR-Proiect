using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DinosaurCollectedManager : MonoBehaviour
{
    public TMP_Text instructionsText;
    private DinosaurCollectionMessage dinosaurCollected;

    private bool isInstructionsVisible = false;
    private float displayDuration = 5f; 
    private float displayTimer = 0f;
    private string currentDinosaur = "stegosaurus";

    public static DinosaurCollectedManager Instance { get; private set; }

    
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

        dinosaurCollected = Resources.Load<DinosaurCollectionMessage>("DinosaurCollectionMessage");
        if (dinosaurCollected == null)
        {
            Debug.LogError("DinosaurCollectionMessage not found.");
        }

        UpdateInstructionsPanel();
    }

    void Update()
    {
        if (isInstructionsVisible)
        {
            displayTimer += Time.deltaTime;
            if (displayTimer >= displayDuration)
            {
                isInstructionsVisible = false;
                displayTimer = 0f;
                instructionsText.gameObject.SetActive(false);
            }
        }
    }

    public void ShowInstructionsForDuration(string dinosaur, float duration)
    {
        currentDinosaur = dinosaur;
        displayDuration = duration;
        isInstructionsVisible = true;
        UpdateInstructionsPanel();
    }

    void UpdateInstructionsPanel()
    {
        instructionsText.gameObject.SetActive(isInstructionsVisible);
        print("LALAL"+currentDinosaur.ToLower());
        if (isInstructionsVisible)
        {
            switch (currentDinosaur.ToLower())
            {
                case "stegosaurus":
                    instructionsText.text = dinosaurCollected.stegosaurusInstructions;
                    break;
                case "tyrannosaurus":
                    instructionsText.text = dinosaurCollected.tyrannosaurusInstructions;
                    break;
                case "pachy":
                    instructionsText.text = dinosaurCollected.pachyInstructions;
                    break;
                case "raptor":
                    instructionsText.text = dinosaurCollected.raptorInstructions;
                    break;
                case "diplodocus":
                    instructionsText.text = dinosaurCollected.diplodocusInstructions;
                    break;
                case "pistosaur":
                    instructionsText.text = dinosaurCollected.pistosaurInstructions;
                    break;
                default:
                    instructionsText.text = "No message available.";
                    break;
            }
        }
    }
}
