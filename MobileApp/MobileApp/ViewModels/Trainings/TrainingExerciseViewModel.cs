using MobileApp.Utills.TimeInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels.Trainings
{
    public class TrainingExerciseViewModel : BaseViewModel
    {
        private Guid id;

        public Guid Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private Guid idExcercise;

        public Guid IdExcercise
        {
            get { return idExcercise; }
            set { idExcercise = value; OnPropertyChanged(); }
        }

        public string Name { get; set; }

        private int seriesNumber = 1;
        public int SeriesNumber
        {
            get { return seriesNumber; }
            set { seriesNumber = value; OnPropertyChanged(); }
        }

        private string seriesTime;
        public string SeriesTimeSec { get { return SeriesTime.GetSecondsFromTimeString() + "s"; } }
        public string SeriesTime
        {
            get { return seriesTime; }
            set { seriesTime = value; OnPropertyChanged(); OnPropertyChanged("SeriesTimeSec"); }
        }

        private string intervalTime;
        public string IntervalTimeSec { get { return IntervalTime.GetSecondsFromTimeString() + "s"; } }
        public string IntervalTime
        {
            get { return intervalTime; }
            set { intervalTime = value; OnPropertyChanged(); OnPropertyChanged("IntervalTimeSec"); }
        }

        private string intervalBetweenExcercises;
        public string IntervalBetweenExcercisesSec { get { return IntervalBetweenExcercises.GetSecondsFromTimeString() + "s"; } }
        public string IntervalBetweenExcercises
        {
            get { return intervalBetweenExcercises; }
            set { intervalBetweenExcercises = value; OnPropertyChanged(); OnPropertyChanged("IntervalBetweenExcercisesSec"); }
        }


        public bool IsOk()
        {
            if (SeriesTime.GetSecondsFromTimeString() <= 0)
            {
                return false;
            }
            if (seriesNumber < 1)
            {
                return false;
            }
            if (IdExcercise == Guid.Empty)
            {
                return false;
            }
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            return true;
        }

    }
}
