using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridCommon
{
    [System.Serializable]
    /// <summary>
    /// Модель описания результата работы
    /// </summary>
    public class JobResult
    {

        public string ResultTrack { get; set; }

        //public double FinalTime { get; set; }

        public double MinWay { get; set; }

    }

}
