using Assets.Scripts.Input;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player.Animations
{
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int Jump = Animator.StringToHash("IsJumping");
        private static readonly int Slide = Animator.StringToHash("Slide");

        [SerializeField] private Animator _animator;

        private ISwipeDetector _swipeDetector;

        [Inject]
        public void Construct(ISwipeDetector swipeDetector) =>
            _swipeDetector = swipeDetector;

        public void PlayRun() =>
            _animator.SetBool(IsMoving, true);

        public void PlayDie() =>
            _animator.SetTrigger(Die);

        public void PlayJump() => 
            _animator.SetBool(Jump, true);

        public void PlaySlide() =>
            _animator.SetTrigger(Slide);

        private void Awake()
        {
            PlayRun();

            _swipeDetector.OnSwipeUp += PlayJump;
            _swipeDetector.OnSwipeDown+= PlaySlide;
        }
    }
}