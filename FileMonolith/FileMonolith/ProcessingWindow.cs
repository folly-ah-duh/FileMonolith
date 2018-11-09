﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FileMonolith
{
    public static class ProcessingWindow
    {
        public static void Show(UnpackManager unpacker, FormProcessesingUnpack processWindow, Action WorkerFunction)
        {
            BackgroundWorker processWorker = new BackgroundWorker();

            processWorker.DoWork += (obj, var) => {
                WorkerFunction();
            };
            processWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(delegate (object sender, RunWorkerCompletedEventArgs e) 
            {
                processWindow.Invoke((MethodInvoker)delegate 
                {
                    processWindow.Close();
                });
                processWorker.Dispose();
            });

            processWorker.RunWorkerAsync();
            processWindow.ShowDialog();
        }
    }
}
