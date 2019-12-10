using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Entities shiny = new Entities();
            var lscamera = shiny.PT_CAMERA_INFO.ToList();
            Console.WriteLine("PT_CameraInfo表"+lscamera.Count()+"条数据");
            Console.ReadKey();
            shiny.SaveChanges();
        }
    }
}
