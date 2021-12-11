using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxScoring
{
    class SyntaxReader
    {
        public static int CalcSyntaxErrorScore(string line)
        {
            Stack<char> syntaxCheck = new ();

            foreach (var chr in line)
            {
                if (chr == '(' || chr == '[' || chr == '{' || chr == '<')
                    syntaxCheck.Push(chr);
                if (chr == ')' || chr == ']' || chr == '}' || chr == '>')
                {
                    if (chr == ')' && syntaxCheck.Peek() != chr && syntaxCheck.Peek() != '(')
                    {
                        syntaxCheck.Pop();
                        return 3;
                    }
                    if (chr == ']' && syntaxCheck.Peek() != chr && syntaxCheck.Peek() != '[')
                    {
                        syntaxCheck.Pop();
                        return 57;
                    }
                    if (chr == '}' && syntaxCheck.Peek() != chr && syntaxCheck.Peek() != '{')
                    {
                         syntaxCheck.Pop();
                        return 1197;
                    }
                    if (chr == '>' && syntaxCheck.Peek() != chr && syntaxCheck.Peek() != '<')
                    {
                        syntaxCheck.Pop();
                        return 25137;
                    }
                    syntaxCheck.Pop();
                }
            }
            return 0;
        }

        public static double CalcSyntaxCompletionScore(string line)
        {
            Stack<char> syntaxCheck = new ();
            double score = 0;

            foreach (var chr in line)
            {
                if (chr == '(' || chr == '[' || chr == '{' || chr == '<')
                    syntaxCheck.Push(chr);
                if (chr == ')' || chr == ']' || chr == '}' || chr == '>')
                {
                    char nxtChr = syntaxCheck.Pop();
                    if (chr == ')' && nxtChr != chr && nxtChr != '(')
                        return 0;
                    if (chr == ']' && nxtChr != chr && nxtChr != '[')
                        return 0;
                    if (chr == '}' && nxtChr != chr && nxtChr != '{')
                        return 0;
                    if (chr == '>' && nxtChr != chr && nxtChr != '<')
                        return 0;
                    if (chr == ')' && nxtChr == '(')
                        continue;
                    if (chr == ']' && nxtChr == '[')
                        continue;
                    if (chr == '}' && nxtChr == '{')
                        continue;
                    if (chr == '>' && nxtChr == '<')
                        continue;
                }
            }

            string completionStr = "";
            int count = syntaxCheck.Count;
            for (int i = 0; i < count; i++)
            {
                char nxtChr = syntaxCheck.Pop();
                if (nxtChr == '(')
                    score = score * 5 + 1;
                if (nxtChr == '[')
                    score = score * 5 + 2;
                if (nxtChr == '{')
                    score = score * 5 + 3;
                if (nxtChr == '<')
                    score = score * 5 + 4;
                completionStr += nxtChr;
            }
            return score;
        }
    }
}
