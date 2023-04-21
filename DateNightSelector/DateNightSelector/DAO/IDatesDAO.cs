using DateNightSelector.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateNightSelector.DAO
{
    public interface IDatesDAO
    {
        IList<Dates> GetAllDates();
        Dates GetRandomDate();
        void AddDate(Dates dates);
        Dates DateById(int dateId);
        void UpdateCompleteDate(int dateId);
    }
}
