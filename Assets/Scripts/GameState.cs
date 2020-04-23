using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameState")]
public class GameState : ScriptableObject
{

    [TextArea(10, 14)] [SerializeField] string storyText = "";
    [SerializeField] int replaceIndex = -1;
    [SerializeField] string keyText = "";
    [SerializeField] string[] resultPhrases = null;

    [SerializeField] GameState[] nextStates = null;

    public string GetStateStory(string[,] replacements)
    {
        string result = storyText;

//        Debug.Log("replacements.length = " + replacements.GetLength(0));

        for (int index = 0; index < replacements.GetLength(0); index++)
        {
//            Debug.Log("replacements[" + index + ", 0] = " + replacements[index, 0]);
            if (replacements[index, 0] != null && replacements[index, 0].Length > 0)
            {
//                Debug.Log("replacements[" + index + ", 1] = " + replacements[index, 1]);
                result = result.Replace(replacements[index, 0], replacements[index, 1]);
            }
        }

        return result;
    }

    public GameState[] GetNextStates()
    {
        return nextStates;
    }
    
    public int GetReplaceIndex()
    {
        return replaceIndex;
    }
    public string GetKeyText()
    {
        return keyText;
    }
    public string GetResultPhrase(int index)
    {
        return resultPhrases[index];
    }
}
