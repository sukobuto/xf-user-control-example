using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Reactive.Bindings;
using System.Reactive.Linq;

namespace XFUserControl.Controls
{
    public class NumericUpDownViewModel
    {
        public ReactiveProperty<double> Value { get; } = new ReactiveProperty<double>(0.0);

        public double Minimum { get; set; } = double.MinValue;

        public double Maximum { get; set; } = double.MaxValue;

        public double Step { get; set; } = 1.0;

        public ReactiveCommand Up { get; private set; }

        public ReactiveCommand Down { get; private set; }

        public NumericUpDownViewModel()
        {
            this.Up = this.Value
                .Select(x => x < this.Maximum)
                .ToReactiveCommand();

            this.Up
                .Subscribe(_ => {
                    var value = this.Value.Value + this.Step;
                    if (value > this.Maximum) value = this.Maximum;
                    this.Value.Value = value;
                });

            this.Down = this.Value
                .Select(x => x > this.Minimum)
                .ToReactiveCommand();

            this.Down
                .Subscribe(_ => {
                    var value = this.Value.Value - this.Step;
                    if (value < this.Minimum) value = this.Minimum;
                    this.Value.Value = value;
                });
        }
    }
}