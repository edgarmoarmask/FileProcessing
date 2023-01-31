using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SpotlightBDA.Core.Utils
{
    public class ProcessSpec
    {
        public string? FileName { get; set; }
        public string? WorkingDirectory { get; set; }
        public IDictionary<string, string> EnvironmentVariables { get; set; } = new Dictionary<string, string>();
        public string? Arguments { get; set; }
        public Action<string>? OutputData { get; set; }
        public Action<string>? ErrorData { get; set; }
        public Action<int>? Exited { get; set; }
        public Action<int>? OnStart { get; set; }
        public Action<int>? OnStop { get; set; }
    }

    public static class ProcessUtil
    {
        private static readonly object _eventLock = new object();
        public static event EventHandler Exited = delegate { };
        public static event EventHandler<DataReceivedEventArgs> OutputDataReceived = delegate { };
        public static event EventHandler<DataReceivedEventArgs> ErrorDataReceived = delegate { };

        public static int Run(
            string fileName,
            string args,
            string workingDirectory = null,
            IDictionary<string, string> environmentVariables = null,
            Action<string> outputDataReceived = null,
            Action<string> errorDataReceived = null,
            Action<int> onStart = null,
            Action<int> onStop = null,
            Action<int> exited = null)
        {

            var processStartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = args,
                RedirectStandardError = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                //Verb = "runas",
                WorkingDirectory = workingDirectory ?? Path.GetDirectoryName(typeof(ProcessUtil).Assembly.Location),
                WindowStyle = ProcessWindowStyle.Hidden
            };

            var process = Process.Start(processStartInfo);
            process.EnableRaisingEvents = true;

            onStart?.Invoke(process.Id);

            process.OutputDataReceived += (sender, e) =>
            {
                if (outputDataReceived != null)
                {
                    outputDataReceived.Invoke(e.Data);
                }
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (e.Data == null)
                {
                    return;
                }
                if (errorDataReceived != null)
                {
                    errorDataReceived.Invoke(e.Data);
                }
            };

            process.Exited += (sender, e) =>
            {
                if (exited != null)
                {
                    exited.Invoke(process.Id);
                }
            };

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            return process.Id;
        }

        public static int Run(ProcessSpec processSpec)
        {
            return Run(
                processSpec.FileName,
                processSpec.Arguments,
                processSpec.WorkingDirectory,
                processSpec.EnvironmentVariables,
                processSpec.OutputData,
                processSpec.ErrorData,
                processSpec.OnStart,
                processSpec.OnStop,
                processSpec.Exited);
        }

        public static void KillProcess(int pid)
        {
            try
            {
                using var process = Process.GetProcessById(pid);
                process?.Kill();
            }
            catch (ArgumentException) { }
            catch (InvalidOperationException) { }
        }
    }
}
