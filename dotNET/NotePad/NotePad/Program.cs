namespace NotePad
{
    public interface ISpellChecker
    {
        void DoSpellCheck();
    }

    public class EnglishSpellChecker : ISpellChecker
    {
        public void DoSpellCheck()
        {
            Console.WriteLine("Spell Check done for English Text");
        }
    }

    public class GermanSpellChecker : ISpellChecker {

        public void DoSpellCheck() {
            Console.WriteLine("Spell Check done for german text");
        }
    }

    public class SpanishSpellChecker : ISpellChecker
    {

        public void DoSpellCheck()
        {
            Console.WriteLine("Spell Check done for Spanish text");
        }
    }

    public class HindiSpellChecker : ISpellChecker
    {

        public void DoSpellCheck()
        {
            Console.WriteLine("Spell Check done for Hindi text");
        }
    }
    public class KlingonSpellChecker : ISpellChecker
    {

        public void DoSpellCheck()
        {
            Console.WriteLine("Spell Check done for Klingon text");
        }
    }

    public class SpellCheckerFactory
    {
        public ISpellChecker GetSomeSpellChcker(string lang) {

            return lang switch
            {
                "en" => new EnglishSpellChecker(),
                "gr" => new GermanSpellChecker(),
                "sp" => new SpanishSpellChecker(),
                _ => new EnglishSpellChecker()


            };
        }
    }
    public class Notepad
    {
        private readonly ISpellChecker _checker;

        public Notepad(ISpellChecker checker)
        {
            SpellCheckerFactory factory = new SpellCheckerFactory();
            _checker = checker ?? factory.GetSomeSpellChcker("en"); ; 
        }

        public void Cut()
        {
            Console.WriteLine("Text copy functionality done");
        }

        public void Copy() 
        {
            Console.WriteLine("Text Copy funtionality done");
        }

        public void Paste()
        {
            Console.WriteLine("Text paste functionlaty done");
        }
        public void SpellCheck()
        {
            _checker.DoSpellCheck();
        }
  
    }

    internal class peogram
    {

        static void Main(string[] args)
        {
            SpellCheckerFactory factory = new SpellCheckerFactory();
            ISpellChecker somechecker = factory.GetSomeSpellChcker("sp");

            Notepad notepad = new Notepad(somechecker); 
            notepad.Cut();
            notepad.SpellCheck();

            Notepad forhindi = new Notepad(new HindiSpellChecker());
            forhindi.SpellCheck();
            forhindi.Cut();

            Notepad kligonLang = new Notepad(new HindiSpellChecker());
            kligonLang.SpellCheck();

        }

    }

}   