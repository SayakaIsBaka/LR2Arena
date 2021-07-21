using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace LR2Arena
{
    class Injector
    {
        private string processName;
        private IntPtr loadThread;
        private IntPtr lr2ProcHandle;
        private IntPtr mindBaseAddress;

        public Injector(string processName)
        {
            this.processName = processName;
        }

        public int Inject(string dllPath)
        {
            Process[] lr2Processes = Process.GetProcessesByName(processName);
            if (lr2Processes.Length == 0)
            {
                Console.Error.WriteLine(processName + " process not found");
                return 1;
            }
            Console.WriteLine(processName + " process found");

            Process lr2Process = lr2Processes[0];
            uint dllPathLength = (uint)((dllPath.Length + 1) * sizeof(char));

            IntPtr lr2ProcHandle = Imports.OpenProcess(Imports.PROCESS_CREATE_THREAD | Imports.PROCESS_QUERY_INFORMATION | Imports.PROCESS_VM_OPERATION | Imports.PROCESS_VM_WRITE | Imports.PROCESS_VM_READ, false, lr2Process.Id);
            if (lr2ProcHandle == IntPtr.Zero)
            {
                Console.Error.WriteLine("error while opening process " + processName);
                return 1;
            }

            IntPtr loadLibraryAddr = Imports.GetProcAddress(Imports.GetModuleHandle("kernel32.dll"), "LoadLibraryW");
            IntPtr mindBaseAddress = Imports.VirtualAllocEx(lr2ProcHandle, IntPtr.Zero, dllPathLength, Imports.MEM_COMMIT, Imports.PAGE_EXECUTE_READWRITE);

            UIntPtr bytesWritten;
            Imports.WriteProcessMemory(lr2ProcHandle, mindBaseAddress, dllPath, dllPathLength, out bytesWritten);

            IntPtr loadThread = Imports.CreateRemoteThread(lr2ProcHandle, IntPtr.Zero, 0, loadLibraryAddr, mindBaseAddress, 0, IntPtr.Zero);
            if (loadThread == IntPtr.Zero)
            {
                Console.Error.WriteLine("error while creating thread");
                return 1;
            }

            this.loadThread = loadThread;
            this.lr2ProcHandle = lr2ProcHandle;
            this.mindBaseAddress = mindBaseAddress;

            return 0;
        }

        public int Clean()
        {
            Imports.WaitForSingleObject(loadThread, Imports.INFINITE);
            Imports.GetExitCodeThread(loadThread, out var baseAddressMind);
            Console.WriteLine("load_library_thread - detached " + baseAddressMind);

            Imports.CloseHandle(loadThread);
            Imports.VirtualFreeEx(lr2ProcHandle, mindBaseAddress, 0, Imports.MEM_RELEASE);

            IntPtr freeLibraryAddr = Imports.GetProcAddress(Imports.GetModuleHandle("kernel32.dll"), "FreeLibrary");
            IntPtr freeThread = Imports.CreateRemoteThread(lr2ProcHandle, IntPtr.Zero, 0, freeLibraryAddr, baseAddressMind, 0, IntPtr.Zero);

            Imports.WaitForSingleObject(freeThread, Imports.INFINITE);
            Imports.CloseHandle(freeThread);

            return 0;
        }
    }
}
