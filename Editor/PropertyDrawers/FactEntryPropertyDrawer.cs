using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using Aarthificial.Typewriter.Entries;

namespace Aarthificial.Typewriter.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(FactEntry), true)]
    public class FactEntryPropertyDrawer : BaseEntryPropertyDrawer
    {
        protected override IEnumerable<string> GetHandledFields()
        {
            return base.GetHandledFields()
              .Append(nameof(BaseEntry.Triggers))
              .Append(nameof(BaseEntry.Once))
              .Append(nameof(BaseEntry.Padding));
        }
    }
}
