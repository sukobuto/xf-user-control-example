using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Reactive.Linq;

namespace XFUserControl.Controls
{
    public partial class NumericUpDown : ContentView
    {

        #region Value BindableProperty
        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(
                nameof(Value), typeof(double), typeof(NumericUpDown), 0.0,
                propertyChanged: (bindable, oldValue, newValue) => {
                    ((NumericUpDown)bindable).Value = (double)newValue;
                },
                defaultBindingMode: BindingMode.TwoWay
            );

        public double Value {
            get { return (double)GetValue(ValueProperty); }
            set {
                SetValue(ValueProperty, value);
                this.viewModel.Value.Value = value;
            }
        }
        #endregion

        #region Minimum BindableProperty
        public static readonly BindableProperty MinimumProperty =
            BindableProperty.Create(
                nameof(Minimum), typeof(double), typeof(NumericUpDown), double.MinValue,
                propertyChanged: (bindable, oldValue, newValue) => {
                    ((NumericUpDown)bindable).Minimum = (double)newValue;
                }
            );

        public double Minimum {
            get { return (double)GetValue(MinimumProperty); }
            set {
                SetValue(MinimumProperty, value);
                this.viewModel.Minimum = value;
            }
        }
        #endregion

        #region Maximum BindableProperty
        public static readonly BindableProperty MaximumProperty =
            BindableProperty.Create(
                nameof(Maximum), typeof(double), typeof(NumericUpDown), double.MaxValue,
                propertyChanged: (bindable, oldValue, newValue) => {
                    ((NumericUpDown)bindable).Maximum = (double)newValue;
                }
            );

        public double Maximum {
            get { return (double)GetValue(MaximumProperty); }
            set {
                SetValue(MaximumProperty, value);
                this.viewModel.Maximum = value;
            }
        }
        #endregion

        #region Step BindableProperty
        public static readonly BindableProperty StepProperty =
            BindableProperty.Create(
                nameof(Step), typeof(double), typeof(NumericUpDown), 1.0,
                propertyChanged: (bindable, oldValue, newValue) => {
                    ((NumericUpDown)bindable).Step = (double)newValue;
                }
            );

        public double Step {
            get { return (double)GetValue(StepProperty); }
            set {
                SetValue(StepProperty, value);
                this.viewModel.Step = value;
            }
        }
        #endregion

        public NumericUpDown()
        {
            InitializeComponent();
            this.viewModel.Value
                .Subscribe(x => this.Value = x);
        }
    }
}
