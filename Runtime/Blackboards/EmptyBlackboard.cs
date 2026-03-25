using System.Collections;
using System.Collections.Generic;

namespace Aarthificial.Typewriter.Blackboards
{
    public class EmptyBlackboard : IBlackboard
    {
        public static readonly IBlackboard Instance = new EmptyBlackboard();

        private EmptyBlackboard() { }

        public IEnumerator<Blackboard.Pair> GetEnumerator() { yield break; }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Set(int key, int value) { }

        public void Add(int key, int value) { }

        public int Get(int key) => 0;

        public bool Test(BlackboardCriterion criterion) => false;

        public void Modify(BlackboardModification modification) { }

        public void Clear() { }

        public IBlackboard Clone() => this;

        public IBlackboard CloneWith(IBlackboard other) => other.Clone();

        public void MergeWith(IBlackboard other) { }

        public void ReplaceWith(IBlackboard other) { }
    }
}
