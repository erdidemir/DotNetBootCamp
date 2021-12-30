using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers.Field.Property.Models
{
    public class CalendarEntry
    {

        // private field (Located near wrapping "Date" property).
        private DateTime _date;

        // Public property exposes _date field safely.
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                // Set some reasonable boundaries for likely birth dates.
                if (value.Year > 1900 && value.Year <= DateTime.Today.Year)
                {
                    _date = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        // public field (Generally not recommended).
        public string Day;

        // Public method also exposes _date field safely.
        // Example call: birthday.SetDate("1975, 6, 30");
        public void SetDate(string dateString)
        {
            DateTime dt = Convert.ToDateTime(dateString);

            // Set some reasonable boundaries for likely birth dates.
            if (dt.Year > 1900 && dt.Year <= DateTime.Today.Year)
            {
                _date = dt;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public TimeSpan GetTimeSpan(string dateString)
        {
            DateTime dt = Convert.ToDateTime(dateString);

            if (dt.Ticks < _date.Ticks)
            {
                return _date - dt;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
