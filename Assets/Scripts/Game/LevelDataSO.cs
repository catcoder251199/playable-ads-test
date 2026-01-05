using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace DefaultNamespace.Game
{
    [CreateAssetMenu(fileName = "new Level Data", menuName = "Game/ Level Data")]
    public class LevelDataSO: ScriptableObject
    {
        [SerializeField] private List<NoteData> levelData;
        public List<NoteData> LevelData => levelData;

#if UNITY_EDITOR
        [SerializeField, Header("Editor - only")]
        private string midiString;

        [ContextMenu("Parse Midi string")]
        private void ParseMidiInEditor()
        {
            levelData = ParseMidiString(midiString);
        } 
        
        private List<NoteData> ParseMidiString(string raw)
        {
            var result = new List<NoteData>();

            var noteChunks = raw.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var chunk in noteChunks)
            {
                var note = new NoteData();
                var fields = chunk.Split('-', StringSplitOptions.RemoveEmptyEntries);

                foreach (var field in fields)
                {
                    var pair = field.Split(':', 2);
                    if (pair.Length != 2)
                        continue;

                    string key = pair[0];
                    string value = pair[1];

                    switch (key)
                    {
                        case "id":
                            note.id = int.Parse(value);
                            break;
                        case "n":
                            note.note = int.Parse(value);
                            break;
                        case "ta":
                            note.time = float.Parse(value, CultureInfo.InvariantCulture);
                            break;
                        case "ts":
                            note.delta = float.Parse(value, CultureInfo.InvariantCulture);
                            break;
                        case "d":
                            note.duration = float.Parse(value, CultureInfo.InvariantCulture);
                            break;
                        case "v":
                            note.volume = int.Parse(value);
                            break;
                        case "pid":
                            note.lane = int.Parse(value);
                            break;
                    }
                }

                result.Add(note);
            }

            return result;
        }
#endif
        
    }
}