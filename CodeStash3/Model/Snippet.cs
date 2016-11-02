using System;

namespace CodeStash3.Model
{
    public class Snippet
    {
        public string Code { get; set; }
        public String Language { get; set; }
        public String Title { get; set; }

        public Snippet(BLL.Snippet snippet)
        {
            //TOOD: clone
            Code = snippet.Code;
            Language = snippet.Language;
            Title = snippet.Title;
        }
    }
}
