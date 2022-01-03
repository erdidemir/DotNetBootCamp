using SOLID._01.SRP.Right;
using SOLID._02.OCP.Right;
using SOLID._03.LSP.Right;
using System;

namespace SOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region OCP

            //02 OCP

            //var employee = new Employee();
            //employee.EmployeeId = 1;
            //employee.EmployeeName = "Ahmet";

            //Rapor pdfRapor = new PDFRaporOlustur();
            //pdfRapor.RaporOlustur(employee);

            //Rapor crystalRapor = new CrystalReportOlustur();
            //crystalRapor.RaporOlustur(employee);

            #endregion

            #region LSP

            //03 LSP

            //var f16 = new F16();

            //f16.KesifYap();
            //f16.HedefiVur();

            //var siha = new Siha();

            //siha.KesifYap();
            //siha.HedefiVur();

            //var iha = new Iha();

            //iha.KesifYap();
            //siha.HedefiVur();//Dummy Code 

            #endregion


            #region ISP

            #endregion

            #region DIP

            #endregion


            Console.ReadLine();
        }
    }
}
