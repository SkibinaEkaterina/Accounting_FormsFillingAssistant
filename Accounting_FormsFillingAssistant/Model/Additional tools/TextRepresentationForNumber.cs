using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting_FormsFillingAssistant
{
    public static class TextRepresentationForNumber
    {

        //Наименования сотен
        private static List<string> ml_Hundreeds = new List<string>
        {
            "", "сто ", "двести ", "триста ", "четыреста ",
            "пятьсот ", "шестьсот ", "семьсот ", "восемьсот ", "девятьсот "
        };

        //Наименования десятков
        private static List<string> ml_Tens = new List<string>
        {
            "", "десять ", "двадцать ", "тридцать ", "сорок ", "пятьдесят ",
            "шестьдесят ", "семьдесят ", "восемьдесят ", "девяносто "
        };



        /// <summary>
        /// Перевод в строку числа с учётом падежного окончания относящегося к числу существительного
        /// </summary>
        /// <param name="val">Число</param>
        /// <param name="male">Род существительного, которое относится к числу</param>
        /// <param name="one">Форма существительного в единственном числе</param>
        /// <param name="two">Форма существительного от двух до четырёх</param>
        /// <param name="five">Форма существительного от пяти и больше</param>
        /// <returns></returns>
        public static string Str(int val, bool male, string one, string two, string five)
        {
            List<string> frac20 = new List<string>
            {
                "", "один ", "два ", "три ", "четыре ", "пять ", "шесть ",
                "семь ", "восемь ", "девять ", "десять ", "одиннадцать ",
                "двенадцать ", "тринадцать ", "четырнадцать ", "пятнадцать ",
                "шестнадцать ", "семнадцать ", "восемнадцать ", "девятнадцать "
            };

            int Value = val % 1000;
            if (Value == 0) return "";
            if (Value < 0) throw new ArgumentOutOfRangeException("val", "Параметр не может быть отрицательным");

            if (!male)
            {
                frac20[1] = "одна ";
                frac20[2] = "две ";
            }

            StringBuilder r = new StringBuilder(ml_Hundreeds[Value / 100]);

            if (Value % 100 < 20)
            {
                r.Append(frac20[Value % 100]);
            }
            else
            {
                r.Append(ml_Tens[Value % 100 / 10]);
                r.Append(frac20[Value % 10]);
            }

            r.Append(Case(Value, one, two, five));

            if (r.Length != 0) r.Append(" ");
            return r.ToString();
        }

        /// <summary>
        /// Выбор правильного падежного окончания сущесвительного.
        /// </summary>
        /// <param name="val"> Число. </param>
        /// <param name="one"> Форма существительного в единственном числе.</param>
        /// <param name="two"> Форма существительного от двух до четырёх.</param>
        /// <param name="five"> Форма существительного от пяти и больше.</param>
        /// <returns> Возвращает существительное с падежным окончанием, которое соответсвует числу.</returns>
        public static string Case(int val, string one, string two, string five)
        {
            int t = (val % 100 > 20) ? val % 10 : val % 20;

            switch (t)
            {
                case 1: return one;
                case 2: case 3: case 4: return two;
                default: return five;
            }
        }

        /// <summary>
        /// Перевод целого числа в строку.
        /// </summary>
        /// <param name="val"> Число.</param>
        /// <returns> Возвращает строковую запись числа. </returns>
        public static string Str(int val, bool male)
        {
            bool minus = false;
            if (val < 0) { val = -val; minus = true; }

            int Value = (int)val;

            StringBuilder StringBuilder = new StringBuilder();

            if (0 == Value) StringBuilder.Append("0 ");
            if (Value % 1000 != 0)
                StringBuilder.Append(Str(Value, male, "", "", ""));

            Value /= 1000;

            StringBuilder.Insert(0, Str(Value, false, "тысяча", "тысячи", "тысяч"));
            Value /= 1000;

            StringBuilder.Insert(0, Str(Value, true, "миллион", "миллиона", "миллионов"));
            Value /= 1000;

            StringBuilder.Insert(0, Str(Value, true, "миллиард", "миллиарда", "миллиардов"));
            Value /= 1000;

            StringBuilder.Insert(0, Str(Value, true, "триллион", "триллиона", "триллионов"));
            Value /= 1000;

            StringBuilder.Insert(0, Str(Value, true, "триллиард", "триллиарда", "триллиардов"));
            if (minus) StringBuilder.Insert(0, "минус ");

            //Делаем первую букву заглавной
            StringBuilder[0] = char.ToUpper(StringBuilder[0]);

            return StringBuilder.ToString();
        }
}
}
