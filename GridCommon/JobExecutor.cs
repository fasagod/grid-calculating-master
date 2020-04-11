using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridCommon
{
    public class JobExecutor
    {
        /// <summary>
        /// Выполняет работу
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        public string[] Mos(int x)
        {
            String[] at;
            x++;
            int razm = 1;
            at = new String[3];
            Random random = new Random();
            if (x > 1)
            {
                for (int i = 1; i < x; i++)
                {
                    razm *= i;
                }
                at = new String[razm];
                for (int i = 0; i < razm; i++)
                {
                    at[i] = "";
                    for (int j = 0; j < x; j++)
                    {
                        int vremgo = 0;
                        while (("" + at[i]).Contains(vremgo + ""))
                        {
                            vremgo = (int)(random.Next(1, x));
                        }
                        at[i] = at[i] + vremgo;
                    }

                    for (int u = 0; u < i; u++)
                    {
                        while (at[u].Equals(at[i]))
                        {
                            at[i] = "";
                            for (int j = 0; j < x; j++)
                            {
                                int vremgo = 0;
                                while (("" + at[i]).Contains(vremgo + ""))
                                {
                                    vremgo = (int)(random.Next(1, x));
                                }
                                at[i] = at[i] + vremgo;
                            }
                            u = 0;
                        }
                    }

                }
                return at;
            }
            else return at;
        }

        public JobResult Execute(Job job)
        {
            //DateTime tStart, tEnd;
            //double finalTime;
            string result = "";
            double minput = 10000;
            double miput;
            double[] max;

            int n = job.Matrix.GetLength(0) - 1;

            max = new double[100];
            int[][] yt = job.Matrix;
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i != j)
                    {
                        if (yt[i][j] > max[0])
                            max[0] = yt[i][j];
                    }
                }
            }

            //tStart = DateTime.Now;
            foreach (string xy in Mos(n))
            {
                string sss;
                sss = xy;
                miput = 0;
                for (int i = 1; i <= n; i++)
                {
                    miput += yt[int.Parse(sss[i - 1].ToString())][ int.Parse(sss[i].ToString())];
                }
                if (minput > miput)
                {
                    minput = miput;
                    result = sss;
                }
            }
            //tEnd = DateTime.Now;
            //finalTime = (tEnd - tStart).TotalMilliseconds;

            return new JobResult()
            {
                ResultTrack = result,
                //FinalTime = finalTime,
                MinWay = minput
            };
        }
    }
}
