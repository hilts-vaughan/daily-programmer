using System;
using System.Linq;

namespace Daily20161107
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input = @"100 120
297 90
66 110
257 113
276 191
280 129
219 163
254 193
86 153
206 147
71 137
104 40
238 127
52 146
129 197
144 59
157 124
210 59
11 54
268 119
261 121
12 189
186 108
174 21
77 18
54 90
174 52
16 129
59 181
290 123
248 132";
            var data = input.Split(Environment.NewLine.ToCharArray()).Select(x =>
            {
                var t = x.Split(' ');
                return new Tuple<int, int>(int.Parse(t[0]), int.Parse(t[1]));
            });

            var golidlocks = data.First();
            var list = data.Skip(1).ToList();
            var valid = list.Where(x => x.Item1 >= golidlocks.Item1 && x.Item2 <= golidlocks.Item2).Select(x => list.IndexOf(x) + 1);
            Console.WriteLine(string.Join(" ", valid));

        }
    }
}