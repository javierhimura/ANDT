using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Andi.Libs
{
    /*
     * 
     *  Script Buat mengeset working set ditiap waktu
     *  This Script is for resetting workingset size Memory on every time
     *  
     *  Kemungkinan tidak stabil ....
     *  Maybe is unstable right now ... but idk
     * 
     */

  public class MemoryManager
  {
        private long Timetick = DateTime.Now.Ticks;
        private static MemoryManager Memman;

        private MemoryManager()
        {
            Application.Idle += new EventHandler(this.TimerSet);
            this.SetWorkingSet();
        }

        [DllImport("kernel32", EntryPoint = "SetProcessWorkingSetSize")]

        private static extern int SetProcessWorkingSetSize(IntPtr intptr_0, int int_0, int int_1);

        private void SetWorkingSet()
        {
            try
            {
                using (Process currentProcess = Process.GetCurrentProcess())
                MemoryManager.SetProcessWorkingSetSize(currentProcess.Handle, -1, -1);
            }
            catch
            {
            }
        }

        private void TimerSet(object sender, EventArgs e)
        {
            try
            {
                long ticks = DateTime.Now.Ticks;
                if (ticks - this.Timetick <= 10000000L)
                    return;
                this.Timetick = ticks;
                this.SetWorkingSet();
            }
            catch
            {
            }
        }

        public static void AttachApp()
        {
            try
            {
                if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                    return;
                MemoryManager.Memman = new MemoryManager();
            }
            catch
            {
            }
        }
  }
}
