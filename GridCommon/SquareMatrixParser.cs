using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridCommon
{
    public class SquareMatrixParser
    {
        public int[][] ParseStream(Stream stream)
        {
            using(StreamReader r = new StreamReader(stream))
            {
                List<int[]> data = new List<int[]>();

                string line = null;
                while((line = r.ReadLine()) != null)
                {
                    List<int> curr = new List<int>();
                    var values = line.Split(',');
                    foreach (var val in values)
                    {
                        curr.Add(int.Parse(val.Trim()));
                    }
                    data.Add(curr.ToArray());
                }

                return data.ToArray();
            }
        }
    }
}
