using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID._01.SRP.Wrong
{
    public class Employee
    {
        //Single responsibility principle

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        /// <summary>
        /// Employee Tablosuna kayıt. işlemi için kullanılan metod
        /// </summary>
        /// <param name="em">Employee Nesnesi</param>
        public bool InsertIntoEmployeeTable(Employee em)
        {
            // Employee Tablosuna kayıt.
            return true;
        }
        /// <summary>
        /// Rapor oluşturmak için kullanılan metod
        /// </summary>
        /// <param name="em"></param>
        public void RaporOlustur(Employee em)
        {
            // Crystal report kullanılarak rapor oluşturma.
        }
    }
}
