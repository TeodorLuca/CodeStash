﻿using CodeStash3.BLL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodeStash3.ViewModel
{
    public interface ICodeStash3ViewModel
    {
        ObservableCollection<Snippet> Snippets { set; get; }
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
