﻿using System;
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
        private List<Snippet> _snippetsFromDAL;
        private ObservableCollection<Snippet> _snippets;
        private List<string> _languages;
        SnippetRepository repo;
        SnippetCollection snippetCollection;
        

        public CodeStash3ViewModel()
        {
            repo = new SnippetRepository();
            snippetCollection = new SnippetCollection(repo);
            _snippetsFromDAL = snippetCollection.GetAllSnippets();
            _snippets = new ObservableCollection<Snippet>(_snippetsFromDAL);
            _languages = new LanguageCollection(_snippetsFromDAL).GenerateLanguageList();
        }

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
            Snippets.Add(new Snippet() { Title = name });
        }

        public void SaveSnippet()
        {
            _snippetsFromDAL = _snippets.ToList();
            snippetCollection.UpdateAllSnippets(_snippetsFromDAL);
        }

        public void DiscardChanges()
        {
            Snippets = new ObservableCollection<Snippet>(_snippetsFromDAL);
        }

        public void DeleteSnippet()
        {
            Snippets.Remove(SelectedSnippet);
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
