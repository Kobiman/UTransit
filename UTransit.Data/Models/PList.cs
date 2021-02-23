using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTransit.Data.Models
{
    public class PList
    {
        public PList[] Next { get; set; }
        public int Heigth { get; set; }
        private int _limit;
        private int index;
        public PList(int limit)
        {
            Next = new PList[limit];
            _limit = limit;
            index = 0;
            Heigth = 0;
        }

        public void Add<T>(T voucher)
        {
            lock (voucher)
            {
                if (Heigth > _limit - 1)
                {
                    if (index == _limit) { index = 0; }
                    Next[index].Add(voucher);
                    index++;
                }
                else
                {
                    Next[Heigth] = new PList(1000);
                    Next[index].Add(voucher);
                    Heigth++;
                }
            }
        }
    }
}
