using Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class Signals : MonoSingleton<Signals>
    {
        public UnityAction<string> OnSkillUse = delegate {  };
    }
}
