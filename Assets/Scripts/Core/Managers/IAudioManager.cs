using UnityEngine;
using Core.Definitions.Sounds;

namespace Core.Managers
{
    /// <summary>
    /// Interface for the AudioManager.
    /// AudioManager is responsible for managing the playback and volume of the game's sounds and music.
    /// </summary>
    public interface IAudioManager
    {
        /// <summary>
        /// Returns the value of the Master volume.
        /// </summary>
        public float MasterVolume { get; }

        /// <summary>
        /// Activate an Fx sound.
        /// </summary>
        /// <param name="sound">The sound to be activated.</param>
        /// <param name="loop">If it's only going to play once or is it a loop.</param>
        /// <returns>The AudioSource that will play the sound.</returns>
        public AudioSource PlayFx(Fx sound, bool loop = false, bool randomPitch = false);

        /// <summary>
        /// Stops all playing sounds and resets their AudioSources.
        /// </summary>
        public void StopAllSourcesAndReset();

        /// <summary>
        /// Changes the master volume (affects all sound types).
        /// </summary>
        /// <param name="volume">New volume that the sound should have (between 0 and 1).</param>
        public void SetVolumeMaster(float volume);
    }
}
