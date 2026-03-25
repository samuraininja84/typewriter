#if UNITY_LOCALIZATION
using UnityEngine.Localization;
using UnityEditor;
using UnityEditor.Localization;
using Aarthificial.Typewriter.Entries;
using Aarthificial.Typewriter.Editor.Localization;

namespace Aarthificial.Typewriter.Editor.Descriptors
{
    [CustomEntryDescriptor(typeof(LocalizedRuleEntry))]
    public class LocalizedRuleEntryDescriptor : RuleEntryDescriptor
    {
        public override string Name => "Text";

        public override void HandleEntryCreated(BaseEntry entry, DatabaseTable table)
        {
            base.HandleEntryCreated(entry, table);
            var rule = (LocalizedRuleEntry)entry;
            var template = (LocalizedRuleEntry)table.Rules.FindLast(previousEntry => previousEntry is LocalizedRuleEntry && previousEntry != rule);
            if (template != null)
            {
                var stringTableCollection = LocalizationEditorSettings.GetStringTableCollection(template.Text.TableReference);
                if (stringTableCollection != null)
                {
                    Undo.RecordObject(stringTableCollection.SharedData, "Create localization entry");
                    var stringEntry = stringTableCollection.SharedData.AddKey(rule.ID.ToString());
                    rule.Text = new LocalizedString(template.Text.TableReference, stringEntry.Id);
                    LocalizationEvents.RaiseTableEntryAdded(stringTableCollection,stringTableCollection.SharedData.GetEntry(stringEntry.Id));
                }
            }
        }
    }
}
#endif
