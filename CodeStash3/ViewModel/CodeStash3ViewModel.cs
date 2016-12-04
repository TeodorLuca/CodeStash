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
using CodeStash3.Properties;

namespace CodeStash3.ViewModel
{
    public class CodeStash3ViewModel : ICodeStash3ViewModel, INotifyPropertyChanged
    {
        private List<Snippet> _snippetsOriginal;
        private ObservableCollection<Snippet> _dirtySnippetsCollection;
        private LanguageCollection _languages;


        public CodeStash3ViewModel()
        {
            try
            {
                BLL.ISnippetRepository snippetRepository;
                BLL.SnippetCollection bllSnippetCollection;


                snippetRepository = SnippetRepositoryFactory.GetRepository(Settings.Default.repoType);
                bllSnippetCollection = new BLL.SnippetCollection(snippetRepository);

                _snippetsOriginal = new SnippetCollection(bllSnippetCollection).ToList();
                _dirtySnippetsCollection = new ObservableCollection<Snippet>(_snippetsOriginal);
                _languages = new LanguageCollection(new BLL.LanguageCollection(bllSnippetCollection).GenerateLanguageList());
            }
            catch (Exception e)
            {
                MessageBox.Show("An error has occured");
            }
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
                return _languages.ToList();
            }

            set
            {
                _languages.AddRange(value);
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
            Snippet snippet = new Snippet() { Title = name };
            DirtySnippetsCollection.Add(snippet);
            SelectedSnippet = snippet;
        }

        public void SaveSnippet()
        {
            try
            {
                BLL.ISnippetRepository snippetRepository = SnippetRepositoryFactory.GetRepository(Settings.Default.repoType);
                BLL.SnippetCollection bllSnippetCollection = new BLL.SnippetCollection();

                foreach (Snippet s in _dirtySnippetsCollection)
                {
                    BLL.Snippet snippet = new BLL.Snippet() { Code = s.Code, Title = s.Title, Language = s.Language };
                    bllSnippetCollection.Add(snippet);
                }

                snippetRepository.UpdateAllSnippets(bllSnippetCollection);

                _snippetsOriginal = _dirtySnippetsCollection.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }
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
