using Stride.Animations;
using Stride.Core;
using Stride.Core.Annotations;
using Stride.Core.Collections;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AnimatorExtension
{
    [DataContract]
    [ComponentCategory("Animator")]
    public class ProceduralAnimation: EntityComponent
    {
        public List<AnimationTrack> AnimationTracks { get; set; }
        public bool IsPlaying { get; private set; }
        public AnimationRepeatMode RepeatMode { get; set; }
        [DataMemberRange(0,int.MaxValue)] public float TimeFactor { get; set; }
        public float CurrentTime { get; private set; }
        public void CreateAnimationTrack(Entity entity, string trackName, EntityComponent componentName, string animatedProperty, AnimationCurve curve) 
        {
            var track = new AnimationTrack(entity.GetOrCreate<AnimationComponent>(), trackName, new AnimationClip() { Duration = TimeSpan.FromSeconds(1f) }, curve);
            track.SetAnimatedProperty(nameof(componentName), animatedProperty);
            AnimationTracks.Add(track);
        }
        private void IterateThroughPlayingAnimations(Action<PlayingAnimation> callback) 
        {
            IterateThroughPlayingAnimations((PlayingAnimation playingAnimation, AnimationTrack track) => { if (callback != null) callback(playingAnimation); });
        }
        private void IterateThroughPlayingAnimations(Action<PlayingAnimation, AnimationTrack> callback)
        {
            foreach (var track in AnimationTracks)
            {
                foreach (var playingAnimation in track.AnimationComponent.PlayingAnimations)
                {
                    if (callback != null) callback(playingAnimation, track);
                }
            }
        }
        public void PlayAnimationTracks() 
        {
            foreach (var track in AnimationTracks) 
            {
                track.AnimationComponent.Play(track.Name);
            }
        }
        public void PauseAnimationTracks()
        {
            IterateThroughPlayingAnimations((PlayingAnimation playingAnimation, AnimationTrack track) => {
                if (playingAnimation.Name.Equals(track.Name))
                {
                    playingAnimation.TimeFactor = 0f;
                }
            });
        }
        public void StopAnimationTracks()
        {
            IterateThroughPlayingAnimations((PlayingAnimation playingAnimation, AnimationTrack track) => {
                if (playingAnimation.Name.Equals(track.Name))
                {
                    playingAnimation.CurrentTime = TimeSpan.FromSeconds(0f);
                    track.AnimationComponent.Animations.Remove(track.Name);
                }
            });
        }
        public void SetPointerToTheBeginningOfAnimationTracks()
        {
            IterateThroughPlayingAnimations((PlayingAnimation playingAnimation) =>
            {
                playingAnimation.CurrentTime = TimeSpan.FromSeconds(0f);
            });
        }
        public void SetPointerToTheEndOfAnimationTracks()
        {
            IterateThroughPlayingAnimations((PlayingAnimation playingAnimation) =>
            {
                playingAnimation.CurrentTime = playingAnimation.Clip.Duration;
            });
        }
    }
}
