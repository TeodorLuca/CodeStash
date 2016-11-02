using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CodeStash3.Model;
using CodeStash3.DAL;
using System.ComponentModel;
using System.Windows;


namespace CodeStash3.ViewModel
{
    public class CodeStash3ViewModel : ICodeStash3ViewModel, INotifyPropertyChanged
    {
        private List<Snippet> _snippetsOriginal;
        private ObservableCollection<Snippet> _dirtySnippetsCollection;
        private List<string> _languages;
        

        public CodeStash3ViewModel()
        {
            SnippetRepository snippetRepository;
            BLL.SnippetCollection bllSnippetCollection;

            snippetRepository = new SnippetRepository();
            bllSnippetCollection = new BLL.SnippetCollection(snippetRepository);

            _snippetsOriginal = new SnippetCollection(bllSnippetCollection).ToList();
            _dirtySnippetsCollection = new ObservableCollection<Snippet>(_snippetsOriginal);
            _languages = new LanguageCollection(_snippetsOriginal).GenerateLanguageList();
        }

        public ObservableCollection<Snippet> DirtySnippetsCollection
        {
            get
            {
                return _dirtySnippetsCollection;
            }

            set
            {
                _dirtySnippetsCollection = value;
                RaisePropertyChanged("Snippets");
            }
        }

        private Snippet _selectedSnippet;
        public Snippet SelectedSnippet
        {
            get
            {
                return _selectedSnippet;
            }

            set
            {
                _selectedSnippet = value;
                RaisePropertyChanged("SelectedSnippet");
            }
        }

        public List<string> Languages
        {
            get
            {
                return _languages;
            }

            set
            {
                _languages = value;
                RaisePropertyChanged("Languages");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddSnippet(string name)
        {
            DirtySnippetsCollection.Add(new Snippet() { Title = name });
        }

        public void SaveSnippet()
        {
            _snippetsOriginal = _dirtySnippetsCollection.ToList();
            snippetCollection.UpdateAllSnippets(_snippetsOriginal);
        }

        public void DiscardChanges()
        {
            DirtySnippetsCollection = new ObservableCollection<Snippet>(_snippetsOriginal);
        }

        public void DeleteSnippet()
        {
            DirtySnippetsCollection.Remove(SelectedSnippet);
            SaveSnippet();
        }

        public void AddLanguage(string text)
        {
            Languages.Add(text);
        }

        public void ChangeLanguage(string text)
        {
            SelectedSnippet.Language = text;
        }
    }
}
