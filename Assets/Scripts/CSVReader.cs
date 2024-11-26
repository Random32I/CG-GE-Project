using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CSVReader : MonoBehaviour
{
    public GameManager game;
    public EnemySpawner spawner;
    public PlayerController player;

    string csvText;

    private Dictionary<string, Dictionary<string, string>> languages;

    void Start()
    {
        Debug.Log("PluginTester has started!");

        LoadLanguagesFromCSV();

        ChangeLanguage("1", "Health");
    }

    void LoadLanguagesFromCSV()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Presets.csv");
        Debug.Log("Attempting to load CSV from: " + filePath);
        if (File.Exists(filePath))
        {
            try
            {

                string[] lines = File.ReadAllLines(filePath);
                Debug.Log("CSV file loaded. Number of lines: " + lines.Length);

                string[] headers = lines[0].Split(',');
                Debug.Log("Language codes found: " + string.Join(", ", headers.Skip(1)));

                languages = new Dictionary<string, Dictionary<string, string>>();

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] columns = lines[i].Split(',');
                    string key = columns[0].Trim();
                    Debug.Log("Found key: " + key);


                    for (int j = 1; j < headers.Length; j++)
                    {
                        string languageCode = headers[j].Trim();
                        string translation = columns[j].Trim();
                        if (!languages.ContainsKey(languageCode))
                        {
                            languages[languageCode] = new Dictionary<string, string>();
                        }
                        languages[languageCode][key] = translation;
                        Debug.Log("Added translation: " + languageCode + " -> " + key + " = " + translation);
                    }
                }
                Debug.Log("CSV file loaded and parsed successfully.");
            }
            catch (System.Exception e)
            {
                Debug.LogError("Error loading or parsing CSV file: " + e.Message);
            }
        }
        else
        {
            Debug.LogError("CSV file not found at: " + filePath);
        }
    }
    void ChangeLanguage(string languageCode, string modifier)
    {
        if (languages == null)
        {
            Debug.LogError("Languages dictionary is null! CSV might not have been loaded correctly.");
            return;
        }
        if (!languages.ContainsKey(languageCode))
        {
            Debug.LogWarning("Language code not found: " + languageCode);
            return;
        }


        if (modifier.Equals("Health"))
        {
            if (languages[languageCode].ContainsKey("Health"))
            {
                csvText = languages[languageCode]["Health"];
                Debug.Log("Language changed to: " + languageCode + " with text: " + csvText);

                ChangeMaxHealth(csvText);
            }
            else
            {
                Debug.LogWarning("Key 'Health' not found for language: " + languageCode);
            }
        }

        if (modifier.Equals("Player Speed"))
        {
            if (languages[languageCode].ContainsKey("Player Speed"))
            {
                csvText = languages[languageCode]["Player Speed"];
                Debug.Log("Language changed to: " + languageCode + " with text: " + csvText);

                ChangePlayerSpeed(csvText);
            }
            else
            {
                Debug.LogWarning("Key 'Player Speed' not found for language: " + languageCode);
            }
        }

        if (modifier.Equals("Max Enemies"))
        {
            if (languages[languageCode].ContainsKey("Max Enemies"))
            {
                csvText = languages[languageCode]["Max Enemies"];
                Debug.Log("Language changed to: " + languageCode + " with text: " + csvText);

                ChangeMaxEnemies(csvText);
            }
            else
            {
                Debug.LogWarning("Key 'Max Enemies' not found for language: " + languageCode);
            }
        }

    }

    public void OnLanguageChangeButtonClicked(string modifier)
    {
        ChangeLanguage(GetComponent<Slider>().value.ToString(), modifier);
    }


    public void ChangeMaxHealth(string PresetToHandle)
    {
        game.SetMaxHealth(int.Parse(PresetToHandle));
    }

    public void ChangePlayerSpeed(string PresetToHandle)
    {
        player.SetSpeed(int.Parse(PresetToHandle));
    }

    public void ChangeMaxEnemies(string PresetToHandle)
    {
        spawner.SetMaxEnemies(int.Parse(PresetToHandle));
    }
}
