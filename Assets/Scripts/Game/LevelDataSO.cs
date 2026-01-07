using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace DefaultNamespace.Game
{
    [CreateAssetMenu(fileName = "new Level Data", menuName = "Game/ Level Data")]
    public class LevelDataSO: ScriptableObject
    {
        [SerializeField] private int startTileAtLane = 2;
        [SerializeField] private float offsetFromStart = 0.3f;
        [SerializeField] private int distanceFromHitLine = 100; // px
        [SerializeField] private float offsetDurationForTap = 0.02f;
        [SerializeField, ReadOnly] private float minTileDuration = 0.3f;
        [SerializeField, ReadOnly] private int laneCount = 4;
        [SerializeField] private float heightForTap = 240; // px
        [SerializeField] private float delayFromStart = 1f; // seconds
        [SerializeField] private float scaleHoldTileLengthFactor = 1f;
        [SerializeField] private float holdScorePerSecond = 10f;
        [SerializeField] private List<NoteData> levelData;
        
        
        public List<NoteData> LevelData => levelData;
        public float TilesVelocity => distanceFromHitLine / delayFromStart; // ignore first start tile
        public int LaneCount => laneCount;
        public float DistanceFromHitLine(int noteIndex) => GetDelayedTimeHit(noteIndex) * TilesVelocity;
        public float GetDelayedTimeHit(int noteIndex) => levelData[noteIndex].time + delayFromStart;
        public float TapDurationThreshold => minTileDuration + offsetDurationForTap; // note has duration < TapDurationThreshold -> tap tile
        public float ScaledDuration(int noteIndex) => levelData[noteIndex].duration * scaleHoldTileLengthFactor;
        public int HoldScore(float holdTime) => Mathf.FloorToInt(holdTime * holdScorePerSecond);
        public float TileHeight(int noteIndex)
        {
            if (levelData[noteIndex].duration <= 0)
                return heightForTap;
            return Mathf.Max(heightForTap / minTileDuration * levelData[noteIndex].duration * scaleHoldTileLengthFactor, heightForTap);
        }
        
        public float HeightForTap => heightForTap;

#if UNITY_EDITOR
        [ContextMenu("Initialize config from midi")]
        private void InitConfigInEditor()
        {
            FindMinTileDurationInEditor();
            FindLaneCountInEditor();
        }    
        
        [ContextMenu("Find lane Count")]
        private void FindLaneCountInEditor()
        {
            HashSet<int> set = new HashSet<int>(4);
            foreach (var noteData in levelData)
            {
                if (!set.Contains(noteData.lane))
                    set.Add(noteData.lane);
            }

            laneCount = set.Count;
        } 
        
        [ContextMenu("Find min tile duration")]
        private void FindMinTileDurationInEditor()
        {
            var min = float.MaxValue;
            foreach (var noteData in levelData)
            {
                if (noteData.duration <= 0)
                    continue;
                
                if (noteData.duration < min)
                {
                    min = noteData.duration;
                }
            }

            if (min < float.MaxValue)
                minTileDuration = min;
        } 
        
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
            var startNoteData = new NoteData();
            startNoteData.lane = startTileAtLane;
            result.Add(startNoteData);

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
                            note.id = int.Parse(value) + 1; // we always auto insert start tile at index 0
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