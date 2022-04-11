using System;

namespace Builder_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            HTMLBuilder builder = new HTMLBuilder();
            builder
                .Boilerplate()
                .Title("Strona z buildera")
                .CloseHeadOpenBody()
                .Append("div", "witam", @" class = ""kontener""")
                .Append("p", "jestem paragrafem","")
                .Append("h1", "a ja jestem naglowkiem","")
                .AppendWithChildrens("div", builder.GetWholeTag("p","paragraf 1",""), builder.GetWholeTag("p", "paragraf 2", ""))
                .CloseHtml();
            Console.WriteLine(builder.ShowCode());
            Console.ReadLine();
        }
    }
}
