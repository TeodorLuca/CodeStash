using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CodeStash3.BLL;
using CodeStash3.DAL;
using System.ComponentModel;
using System.Windows;

namespace CodeStash3.ViewModel
{
    public class CodeStash3ViewModel : ICodeStash3ViewModel, INotifyPropertyChanged
    {
        
        public CodeStash3ViewModel()
        {
            //SnippetRepository repo = new SnippetRepository();
            //SnippetCollection snippetCollection = new SnippetCollection(repo);
            //List<Snippet> listOfSnippets = snippetCollection.GetAllSnippets();
            //foreach(var item in listOfSnippets)
            //{
            //    _snippets.Add(item);
            //}
            _snippets = new ObservableCollection<Snippet> {
                    //new Snippet() { Title = "item1", Language = "C", Code = new StringBuilder("some C code") },
                    //new Snippet() { Title = "item2", Language = "C++", Code =  new StringBuilder("some C++ code")},
                    //new Snippet() { Title = "item3", Language = "C#", Code =  new StringBuilder("some C# code")} };
                    new Snippet() { Title = "item1", Language = "C", Code = "some C code\nnewline" },
                    new Snippet() { Title = "item2", Language = "C++", Code = "some C++ code" },
                    new Snippet() { Title = "item3", Language = "C#", Code = "some C# code" } };

            _snippetsFromDAL = new List<Snippet> {new Snippet() { Title = "item1", Language = "C", Code = "some C code\nnewline" },
                    new Snippet() { Title = "item2", Language = "C++", Code = "some C++ code" },
                    new Snippet() { Title = "item3", Language = "C#", Code = "some C# code" }  };

        }

        void AdfdsfsdCommand(object sender, ExecutedRoutedEventArgs e)
        {
            Snippet newSnippet = new Snippet() { Title = "New snippet"};
            Snippets.Add(newSnippet);
        }

        private void LoadSnippets()
        {
            
        }

        private ObservableCollection<Snippet> _snippets;
        private List<Snippet> _snippetsFromDAL;
        public ObservableCollection<Snippet> Snippets
        {
            get
            {
                return _snippets;
            }

            set
            {
                _snippets = value;
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

       
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddSnippet(string name)
        {
            Snippets.Add(new Snippet() { Title = name });
        }

        public void SaveSnippet()
        {
            _snippetsFromDAL = _snippets.ToList();
            //TODO  SaveSnippet to DAL
        }

        public void DiscardChanges()
        {
            Snippets = new ObservableCollection<Snippet>(_snippetsFromDAL);
        }
    }
}
