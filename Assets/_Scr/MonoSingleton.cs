using UnityEngine;
using System.Reflection;

[DefaultExecutionOrder(-200)]// �̰� ����� �˾ƿ��� ��������� ����� ����
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static readonly MonoSingletonFlags singletonFlag = typeof(T).GetCustomAttribute<AttributeMonoSingleton>()?.Flags ?? MonoSingletonFlags.None;
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (!instance)
            {
                instance = Initialize();
            }
            return instance;
        }
    }

    private static T Initialize()
    {
        print("Init");
        //singletonFlag = typeof(T).GetCustomAttribute<AttributeSingleton>()?.Flags ?? SingletonFlags.None;
        if (singletonFlag.HasFlag(MonoSingletonFlags.NoAutoInstance))
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().isLoaded)
            {
                print("�ε��̵Ƴ�..");
                return FindObjectOfType<T>();
            }
            return null;
        }

        //AutoInstance
        GameObject gameObject = new GameObject(typeof(T).FullName);
        T result = gameObject.AddComponent<T>();
        if (singletonFlag.HasFlag(MonoSingletonFlags.DontDestroy))
        {
            DontDestroyOnLoad(gameObject);
        }

        return result;
    }

    protected virtual void Awake()
    {
        //print("-AwakeInit-");
        //print((bool)instance);
        print("��");
        if (instance)
        {
            Debug.LogError("twoSingletons");
            Destroy(gameObject);
        }
        else
        {
            instance = (T)this;
            print(instance.gameObject.name);
        }
    }
    protected virtual void OnDestroy()
    {
        instance = null;
        //print("����" + typeof(T).FullName); 
    }

}