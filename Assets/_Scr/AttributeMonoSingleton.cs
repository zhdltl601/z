using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class AttributeMonoSingleton : Attribute
{
    public readonly MonoSingletonFlags Flags;

    public AttributeMonoSingleton(MonoSingletonFlags flag)
    {
        Flags = flag;
    }
}