using System;

namespace CodeStash3.BLL
{
    public class Snippet
    {
        public string Code { get; set; }
        public String Language { get; set; }
        public String Title { get; set; }

        public override string ToString()
        {
            //return String.Format("{0} {1} {2}", Title, Language, Code);
            return $"{Title} {Language} {Code}";
        }
        //public GenerateFormattedRichText()
        //{
        //    
        //}
    }
}
