using System.Collections.Generic;

namespace SimpleMVVM
{
    public class SimpleClass
    {
        public int SoA { get; set; }
        public int SoB { get; set; }
        public int TongAB { get; set; }
 
        /// <summary>
        /// khởi tạo dũ liệu
        /// </summary>
        /// <returns></returns>
        public List<SimpleClass> khoiTaoDuLieu()
        {
            List<SimpleClass> lstResult = new List<SimpleClass>();
            lstResult.Add(new SimpleClass { SoA = 1, SoB = 2, TongAB = 3 });
            lstResult.Add(new SimpleClass { SoA = 4, SoB = 7, TongAB = 11 });
            return lstResult;
        }
    }
}