using System;
using UnityEngine.Serialization;

namespace DefaultNamespace.Game
{
    [Serializable]
    public class NoteData
    {
        public int id = -1;
        public int note;        // n
        public float time;      // ta (absolute time)
        public float delta;     // ts
        public float duration; // d
        public int volume;   // v
        public int lane;       // pid
    }
}