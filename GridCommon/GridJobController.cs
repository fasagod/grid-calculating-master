using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridCommon
{
   
    
    public class GridJobController : MarshalByRefObject
    {

        static readonly System.Random Random = new Random();

        /// <summary>
        /// Полчуить задание об умножении двух чисел
        /// </summary>
        /// <returns></returns>
        public Job GetJob()
        {
            var j = JobsFactory.GetJob();
            if (j != null)
                Console.WriteLine($"Клиенту дана работа! "+  j.Matrix);
            return j;
        }

        public void SetResult(Job job, JobResult result)
        {
            JobsComparer.AddJobResult(result);
            Console.WriteLine($"Клиент посчитал: Путь - {0} Расстояние - {1}", result.ResultTrack, /*result.FinalTime,*/ result.MinWay);
        }
    }
}
