using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace NinfiaDSToolkit.Andi.Controls
{
    [DebuggerStepThrough]
    public static class ControlExtensions
    {
        [DebuggerStepThrough]
        public static Control FindControl(this Control parentControl, Func<Control, bool> condition)
        {
            Control control = null;
            foreach (
                Control parentControl1 in
                    parentControl.Controls.Cast<Control>().OrderBy(control_0 => control_0.TabIndex))
            {
                control = condition(parentControl1) ? parentControl1 : parentControl1.FindControl(condition);
                if (control != null)
                    break;
            }
            return control;
        }

        [DebuggerStepThrough]
        public static Control FindControl(this Control parentControl, string controlName)
        {
            Control control;
            if (parentControl.Name == controlName)
            {
                control = parentControl;
            }
            else
            {
                control = null;
                foreach (Control parentControl1 in (ArrangedElementCollection) parentControl.Controls)
                {
                    control = parentControl1.FindControl(controlName);
                    if (control != null)
                        break;
                }
            }
            return control;
        }

        [DebuggerStepThrough]
        public static void FocusFirst(this Control parentControl)
        {
            /*
            if (parentControl == null)
                return;
            Control control = parentControl.FindControl(control_0 =>
            {
                if (control_0.TabStop && !(control_0 is ContainerControl))
                    //return !(control_0 is AndiTabControl);
                return false;
            });
            if (control == null)
                return;
            control.Focus();*/
        }

        [DebuggerStepThrough]
        public static string GetFullName(this Control control)
        {
            var stringBuilder = new StringBuilder();
            for (; control != null; control = control.Parent)
            {
                if (stringBuilder.Length != 0)
                    stringBuilder.Insert(0, ".");
                stringBuilder.Insert(0, control.Name);
            }
            return stringBuilder.ToString();
        }

        [DebuggerStepThrough]
        public static bool IsDesignTime(this Control target)
        {
            bool flag;
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                flag = true;
            }
            else
            {
                flag = false;
                for (Control control = target; control != null; control = control.Parent)
                {
                    if (control.Site != null && control.Site.DesignMode)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        [DebuggerStepThrough]
        public static bool IsRunTime(this Control target)
        {
            return !target.IsDesignTime();
        }
    }
}