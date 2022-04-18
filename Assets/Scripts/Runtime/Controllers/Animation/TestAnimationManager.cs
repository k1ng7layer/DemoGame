using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine.Events;
using UnityEditor.Events;

namespace Assets.Scripts.Runtime.Controllers.Animation
{
    public class TestAnimationManager:MonoBehaviour
    {
        public Animator animator;
        private static TestAnimationManager _instance;
        private List<Action> _callbacks; 
        public MonoBehaviour monoBehaviour;
        [SerializeField]private UnityEvent unityEvent;
        [SerializeField] TestUnityEvent testUnityEvent;
        public static TestAnimationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<TestAnimationManager>();
                }
                return _instance;
            }
        }
        private void Awake()
        {
            _callbacks = new List<Action>();
            
        }
        private void Start()
        {


            //var clip = animator.runtimeAnimatorController.animationClips.Where(c => c.name == "Withdrawing Sword").FirstOrDefault();
            ////_callbacks.Add(callback);
            //AnimationEvent animationEvent = new AnimationEvent();
            //animationEvent.time = 0.5f;
            ////animationEvent.functionName = unityEvent.GetPersistentMethodName(0);
            //animationEvent.functionName = unityEvent.GetPersistentMethodName(0);
            ////animationEvent.functionName = "Test";
            //clip.AddEvent(animationEvent);
            //AddCallBack(Test);
            //CreateMethod();
        }
        public  void AddAnimationEvent(string clipName, float time, Action callback)
        {
            TestUnityEvent testUnityEvent = new TestUnityEvent();
            //var clip = animator.runtimeAnimatorController.animationClips.Where(c => c.name == clipName).FirstOrDefault();
            //_callbacks.Add(callback);
            //AnimationEvent animationEvent = new AnimationEvent();
            //animationEvent.time = time;
            //animationEvent.functionName = "Test";
            //clip.AddEvent(animationEvent);
            var method = unityEvent.GetPersistentMethodName(0);
        }
        //public void AddCallBack(Action action)
        //{
        //    UnityAction unityAction = new UnityAction(Test);
        //    unityEvent.AddListener(unityAction);
           
        //    _callbacks.Add(action);
        //    var clip = animator.runtimeAnimatorController.animationClips.Where(c => c.name == "Withdrawing Sword").FirstOrDefault();
        //    //_callbacks.Add(callback);
        //    AnimationEvent animationEvent = new AnimationEvent();
        //    animationEvent.time = 0.5f;
            
        //    //animationEvent.functionName = unityEvent.GetPersistentMethodName(0);
        //    animationEvent.functionName = unityEvent.GetPersistentMethodName(0);
            //    //animationEvent.functionName = "Test";
        //    clip.AddEvent(animationEvent);
        //}
        public void AddCallBack(Action action)
        {
            UnityAction unityAction = new UnityAction(Test);
            TestUnityEvent testUnityEvent = new TestUnityEvent();
            //testUnityEvent.Register(0,)
            testUnityEvent.AddListener(unityAction);
            AnimationEvent animationEvent = new AnimationEvent();
            animationEvent.time = 0.5f;
            var clip = animator.runtimeAnimatorController.animationClips.Where(c => c.name == "Withdrawing Sword").FirstOrDefault();
            //animationEvent.functionName = unityEvent.GetPersistentMethodName(0);
            animationEvent.functionName = testUnityEvent.GetPersistentMethodName(0);
            //animationEvent.functionName = "Test";
            clip.AddEvent(animationEvent);


        }
        public void CreateMethod(Action action, object target)
        {
            //UnityAction unityAction = new UnityAction(action);
            //TestUnityEvent testUnityEvent = new TestUnityEvent();
            //testUnityEvent.AddListener(unityAction);
            ////var targetInfo = UnityEvent.GetValidMethodInfo(this, nameof(action), new Type[0]);
            ////UnityAction methodDelegate = Delegate.CreateDelegate(typeof(UnityAction), target, methodInfo) as UnityAction;
            ////UnityEventTools.AddVoidPersistentListener(testUnityEvent, unityAction);
            //var method = testUnityEvent.GetPersistentMethodName(0);
        }


        public void Test()
        {
            Debug.Log("WEAPON DRAW");
        }
    }
}
