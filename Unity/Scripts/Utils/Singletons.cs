using UnityEngine;

// Author: Anik Patel
// Description: Singeton parent class that handles instances between scenes
// Version: 1.0
// Changes: [N/A]
namespace Zone.Core.Utils
{
    public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
    {
        // Enable for more detail in printing
        public static bool verbose = false;
        
        // Enable to keep the attached object betweem scenes
        public bool keepAlive = false;

        private static T _instance = null;
        public static T instance
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        GameObject singletonObj = new GameObject();
                        singletonObj.name = typeof(T).ToString();
                        _instance = singletonObj.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }

        static public bool isInstanceAlive
        {
            get
            {
                return _instance != null;
            }
        }
        
        // WARNING: Make sure to run base.Awake() if need to override
        public virtual void Awake()
        {
            if (_instance != null)
            {
                if (verbose)
                {
                    print($"Multiple Instance of Singleton Detected {name} of {instance.name}");
                }
                Destroy(gameObject);
                return;
            }

            _instance = GetComponent<T>();

            if (keepAlive)
            {
                DontDestroyOnLoad(gameObject);
            }

            if (_instance == null)
            {
                if (verbose)
                {
                    print($"Singleton<{typeof(T).Name}> Instance is null");
                }
                return;
            }

            if (verbose)
            {
                print($"Singleton instance found {instance.GetType().Name}");
            }

        }

    }
}
