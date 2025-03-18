using UnityEngine;

namespace Core
{
    public class Observables : MonoBehaviour
    {
        [field: SerializeField] public ObservableSO ResetObservableSO { get; private set; }
        [field: SerializeField] public ObservableSO AddObservableSO { get; private set; }
        [field: SerializeField] public ObservableSO RemoveObservableSO { get; private set; }
    }
}