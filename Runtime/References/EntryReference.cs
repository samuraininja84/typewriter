using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Aarthificial.Typewriter.Entries;

namespace Aarthificial.Typewriter.References
{
    [Serializable]
    public struct EntryReference : IEquatable<EntryReference>
    {
        [SerializeField] internal int InternalID;

        public int ID
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalID;
        }

        public bool HasValue
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalID != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(EntryReference other) => InternalID == other.InternalID;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly BaseEntry GetEntry()
        {
            TryGetEntry(out var entry);
            return entry;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly T GetEntry<T>() where T : BaseEntry
        {
            TryGetEntry(out T entry);
            return entry;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool TryGetEntry(out BaseEntry entry) => TypewriterDatabase.Instance.TryGetEntry(InternalID, out entry);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool TryGetEntry<T>(out T entry) where T : BaseEntry => TypewriterDatabase.Instance.TryGetEntry(InternalID, out entry);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is EntryReference other && Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => InternalID;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(EntryReference lhs, EntryReference rhs) => lhs.InternalID == rhs.InternalID;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(EntryReference lhs, EntryReference rhs) => lhs.InternalID != rhs.InternalID;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int(EntryReference reference) => reference.InternalID;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator EntryReference(int id) => new EntryReference { InternalID = id };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator EntryReference(BaseEntry entry) => new EntryReference { InternalID = entry?.ID ?? 0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator BaseEntry(EntryReference reference) => reference.GetEntry();
    }
}
