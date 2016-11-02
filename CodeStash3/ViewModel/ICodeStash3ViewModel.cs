using CodeStash3.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodeStash3.ViewModel
{
    public interface ICodeStash3ViewModel
    {
        ObservableCollection<Snippet> DirtySnippetsCollection { set; get; }
        Snippet SelectedSnippet { set; get; }
        List<string> Languages { set; get; }

        void AddSnippet(string name);
        void SaveSnippet();
        void DiscardChanges();
        void DeleteSnippet();
        void AddLanguage(string text);
        void ChangeLanguage(string text);
    }
}
