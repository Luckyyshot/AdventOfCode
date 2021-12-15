using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedPolymerization
{
    class PolymerTemplate
    {
        readonly Dictionary<string,Tuple<string, string>> InsertionRules;
        readonly Dictionary<string, long> RuleOccurances;
        readonly Dictionary<char, long> Counts = new()
        {
            { 'B', 0 }, { 'C', 0 }, { 'F', 0 }, { 'H', 0 }, { 'K', 0 }, { 'N', 0 }, { 'O', 0 }, { 'P', 0 }, { 'S', 0 }, { 'V', 0 }
        };

        readonly char first, last;

        public PolymerTemplate(string template, string[] rules)
        {
            first = template[0];
            last = template[^1];

            InsertionRules = new();
            RuleOccurances = new();

            for (int i = 0; i < rules.Length; i++)
            {
                string[] temp = rules[i].Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                InsertionRules.Add(temp[0], new(temp[0][0] + temp[1], temp[1] + temp[0][1]));

                RuleOccurances.Add(temp[0], 0);
            }

            for (int i = 0; i < template.Length - 1; i++)
            {
                RuleOccurances[template.Substring(i, 2)]++;
            }
        }

        public long LeastCommonSubtractedMostCommon()
        {
            RunCount();

            long mostCommon = long.MinValue, leastCommon = long.MaxValue;
            foreach (var count in Counts)
            {
                if (count.Value != 0)
                {
                    mostCommon = Math.Max(mostCommon, count.Value);
                    leastCommon = Math.Min(leastCommon, count.Value);
                }
            }
            return mostCommon - leastCommon;
        }

        void RunCount()
        {
            foreach (var occCount in RuleOccurances)
            {
                Counts[occCount.Key[0]] += occCount.Value;
                Counts[occCount.Key[1]] += occCount.Value;
            }

            Counts[first]++;
            Counts[last]++;

            foreach (var count in new Dictionary<char, long>(Counts))
            {
                Counts[count.Key] = Counts[count.Key] / 2;
            }
        }

        public void RunInsertionRules(int loops)
        {
            for (int i = 0; i < loops; i++)
            {
                InsertionPass();
            }
        }

        void InsertionPass()
        {
            var tempRuleOccurances = new Dictionary<string, long>(RuleOccurances);
            foreach (var occCount in tempRuleOccurances)
            {
                var temp = InsertionRules[occCount.Key];
                RuleOccurances[temp.Item1] += occCount.Value;
                RuleOccurances[temp.Item2] += occCount.Value;
                RuleOccurances[occCount.Key] -= tempRuleOccurances[occCount.Key];
            }
        }
    }
}
