using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent = null;
    [SerializeField] GameState initialState = null;
    [SerializeField] GameState finalState = null;
    [SerializeField] int numReplacements = 0;

    GameState state = null;

    string[,] replacements = null;

    // Start is called before the first frame update
    void Start()
    {
        replacements = new string[numReplacements, 2];

        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void InitGame()
    {
        state = initialState;
        textComponent.text = state.GetStateStory(replacements);
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();

        for (int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.A + index))
            {
                int replaceIndex = state.GetReplaceIndex();
               
                if(replaceIndex >= 0)
                {
                    replacements[replaceIndex, 0] = state.GetKeyText();
                    replacements[replaceIndex, 1] = state.GetResultPhrase(index);
                }
                state = nextStates[index];
                textComponent.text = state.GetStateStory(replacements);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            state = finalState;
            textComponent.text = state.GetStateStory(replacements);
        }
    }
}
