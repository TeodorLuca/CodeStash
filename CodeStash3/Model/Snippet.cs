using System;

namespace CodeStash3.Model
{
    public class Snippet
    {
        public string Code { get; set; }
        public string Language { get; set; }
        public string Title { get; set; }

        public Snippet()
        {
        }
        public Snippet(BLL.Snippet snippet)
        {
            Code = snippet.Code;
            Language = snippet.Language;
            Title = snippet.Title;
        }
    }
}
