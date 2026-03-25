using System;
using UnityEngine;
using Aarthificial.Typewriter.Blackboards;

namespace Aarthificial.Typewriter.Tools
{
    [Serializable]
    public class TypewriterCriteria
    {
        [SerializeField] internal BlackboardCriterion[] List = Array.Empty<BlackboardCriterion>();

        public bool HasValue => List.Length > 0;
    }
}
