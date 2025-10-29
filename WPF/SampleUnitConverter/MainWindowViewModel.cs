using Prism.Mvvm;
using Prism.Commands;
using System.Linq;

namespace SampleUnitConverter {
    class MainWindowViewModel : BindableBase {
        private double metricValue;
        private double imperialValue;

        public DelegateCommand ImperialUnitToMetric { get; }
        public DelegateCommand MetricToImperialUnit { get; }

        private MetricUnit currentMetricUnit;
        public MetricUnit CurrentMetricUnit {
            get => currentMetricUnit;
            set => SetProperty(ref currentMetricUnit, value);
        }

        private ImperialUnit currentImperialUnit;
        public ImperialUnit CurrentImperialUnit {
            get => currentImperialUnit;
            set => SetProperty(ref currentImperialUnit, value);
        }

        public double MetricValue {
            get => metricValue;
            set => SetProperty(ref metricValue, value);
        }

        public double ImperialValue {
            get => imperialValue;
            set => SetProperty(ref imperialValue, value);
        }

        public MainWindowViewModel() {
            CurrentMetricUnit = MetricUnit.Units.First();
            CurrentImperialUnit = ImperialUnit.Units.First();

            ImperialUnitToMetric = new DelegateCommand(
                () => MetricValue = CurrentMetricUnit.FormImperialUnit(
                    CurrentImperialUnit, ImperialValue));

            MetricToImperialUnit = new DelegateCommand(
                () => ImperialValue = CurrentImperialUnit.FormMetricUnit(
                    CurrentMetricUnit, MetricValue));
        }
    }
}
