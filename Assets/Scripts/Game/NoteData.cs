using System;
using UnityEngine.Serialization;

namespace DefaultNamespace.Game
{
    [Serializable]
    public struct NoteData
    {
        public int id;
        public int note;        // n
        public float time;      // ta (absolute time)
        public float delta;     // ts
        public float duration; // d
        public int volume;   // v
        public int lane;       // pid
    }
}