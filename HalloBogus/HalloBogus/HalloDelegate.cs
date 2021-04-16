using System;
using System.Collections.Generic;
using System.Linq;

namespace HalloBogus
{
    delegate void EinfacherDelegate();
    delegate void DelegateMitPara(string msg);
    delegate long CalcDelegate(int a, int b);

    class HalloDelegate
    {
        public HalloDelegate()
        {
            EinfacherDelegate meinDele = EinfacheMethode;
            Action meinDeleAlsAction = EinfacheMethode;
            EinfacherDelegate meinDeleAno = delegate () { Console.WriteLine("Hallo"); };
            EinfacherDelegate meinDeleAno2 = () => { Console.WriteLine("Hallo"); };
            EinfacherDelegate meinDeleAno3 = () => Console.WriteLine("Hallo");

            DelegateMitPara deleMitPara = MethodeMitPara;
            Action<string> deleMitParaAlsAction = MethodeMitPara;
            Action<string> deleMitParaAno = delegate (string txt) { Console.WriteLine(txt); };
            Action<string> deleMitParaAno2 = (string txt) => { Console.WriteLine(txt); };
            Action<string> deleMitParaAno3 = (string txt) => Console.WriteLine(txt);
            Action<string> deleMitParaAno4 = (txt) => Console.WriteLine(txt);
            Action<string> deleMitParaAno5 = x => Console.WriteLine(x);

            CalcDelegate calcDele = Minus;
            Func<int, int, long> calcDeleAlsFunc = Sum;
            CalcDelegate calcDeleAno = delegate (int a, int b) { return a + b; };
            CalcDelegate calcDeleAno2 = (int a, int b) => { return a + b; };
            CalcDelegate calcDeleAno3 = (a, b) => { return a + b; };
            CalcDelegate calcDeleAno4 = (a, b) => a + b;

            var result = calcDele(7, 4);

            deleMitPara.Invoke("Hallo");
            deleMitPara("Hallo");

            List<string> texte = new List<string>();
            texte.Where(x => x.StartsWith("b"));
            texte.Where(Filter);

        }

        private bool Filter(string arg)
        {
            if (arg.StartsWith("b"))
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return a - b;
        }

        private long Sum(int a, int b)
        {
            return a + b;
        }

        private void MethodeMitPara(string text)
        {
            Console.WriteLine(text);
        }

        public void EinfacheMethode()
        {
            System.Console.WriteLine("Hallo");
        }
    }
}
