using System.Collections;

namespace SolarSystem.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator load);
    }
}