using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.others
{
    [Serializable]
    public class Sound
    {
        [SerializeField]
        private string name;
        public string GetName()
        {
            return name;
        }

        [SerializeField]
        private AudioClip clip; 
        public AudioClip GetClip()
        {
            return clip;
        }
        [Range(0f, 1f)]
        [SerializeField]
        private float volume = 1f;
        public float GetVolume()
        {
            return volume;
        }
        [Range(.1f,3f)]
        [SerializeField]
        private float pitch = 1f;
        public float Getpitch()
        {
            return pitch;
        }

        [SerializeField]
        private bool loop;
        public bool GetLoop()
        {
            return loop;
        }

        [SerializeField]
        private SoundType type;
        public AudioSource Source { get; set; }
    }
}
